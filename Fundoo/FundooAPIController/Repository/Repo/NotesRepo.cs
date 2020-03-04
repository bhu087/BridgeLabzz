using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.IdentityModel.Tokens;
using Model.Account;
using Repository.Context;
using Repository.IRepo;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public class NotesRepo : INotesRepo
    {
        public const string CloudName = "bhu087";
        public const string APIKey = "354171364155512";
        public const string APISecret = "ZtRMv8zmp1hqFjyFAeOpNNj2p3A";
        public readonly UserDBContext context;
        public NotesRepo(UserDBContext userDBContext)
        {
            this.context = userDBContext;
        }
        public bool DuplicateEmails(string email)
        {
            var emails = this.context.Notes.Where(notesEmail => notesEmail.Email == email).ToList();
            foreach (var dataBaseEmail in emails)
            {
                if (dataBaseEmail.Email.Equals(email))
                {
                    return true;
                }
            }
            return false;
        }
        public bool DuplicateEmailsUpdate(NotesModel notesModel)
        {
            var emails = this.context.Notes.Where(notesEmail => notesEmail.Email == notesModel.Email).ToList();
            foreach (var dataBaseEmail in emails)
            {
                if (dataBaseEmail.Email.Equals(notesModel.Email) && dataBaseEmail.NotesId1 != notesModel.NotesId1)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<string> AddNotes(NotesModel notesModel)
        {
            try
            {
                if (this.DuplicateEmails(notesModel.Email))
                {
                    return "Email already Exist";
                }
                NotesModel add = new NotesModel()
                {
                    Email = notesModel.Email,
                    Title = notesModel.Title,
                    Description = notesModel.Description,
                    CreatedTime = notesModel.CreatedTime,
                };
                this.context.Notes.Add(add);
                var result = this.context.SaveChangesAsync();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Id", add.ToString())
                        }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                };
                var securityTokenHandler = new JwtSecurityTokenHandler();
                var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                var token = securityTokenHandler.WriteToken(securityToken);
                var cacheKey = "Add";
                ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                IDatabase database = connectionMultiplexer.GetDatabase();
                database.StringSet(cacheKey, token.ToString());
                database.StringGet(cacheKey);
                return "Saved";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> UpdateNotes(NotesModel notesModel)
        {
            try
            {
                if (this.DuplicateEmailsUpdate(notesModel))
                {
                    return "Email already Exist";
                }
                if (this.FindById(notesModel.NotesId1))
                {
                    var notesCheck = this.context.Notes.Where(notesId => notesId.NotesId1 == notesModel.NotesId1).SingleOrDefault();
                    notesCheck.Email = notesModel.Email;
                    notesCheck.Title = notesModel.Title;
                    notesCheck.Description = notesModel.Description;
                    notesCheck.ModifiedTime = notesModel.ModifiedTime;
                    var result = this.context.SaveChangesAsync();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Id", notesModel.NotesId1.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var securityTokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                    var token = securityTokenHandler.WriteToken(securityToken);
                    var cacheKey = notesModel.NotesId1 + " Update";
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(cacheKey, token.ToString());
                    database.StringGet(cacheKey);
                    return "Saved";
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> EditTitle(NotesModel notesModel)
        {
            try
            {
                if (this.FindById(notesModel.NotesId1))
                {
                    var notesCheck = this.context.Notes.Where(notesId => notesId.NotesId1 == notesModel.NotesId1).SingleOrDefault();
                    notesCheck.Title = notesModel.Title;
                    notesCheck.ModifiedTime = notesModel.ModifiedTime;
                    var result = this.context.SaveChangesAsync();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Id", notesModel.NotesId1.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var securityTokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                    var token = securityTokenHandler.WriteToken(securityToken);
                    var cacheKey = notesModel.NotesId1 + " Edit";
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(cacheKey, token.ToString());
                    database.StringGet(cacheKey);
                    return "Title Updated";
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool FindById(int id)
        {
            try
            {
                var notesCheck = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                if (notesCheck.NotesId1 == id)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public Task<int> DeleteNotes(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                    note.IsTrash = true;
                    var result = this.context.SaveChangesAsync();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Id", id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var securityTokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                    var token = securityTokenHandler.WriteToken(securityToken);
                    var cacheKey = id + " Delete";
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(cacheKey, token.ToString());
                    database.StringGet(cacheKey);
                    return result;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> DeleteTrash(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(noteId => noteId.NotesId1 == id).SingleOrDefault();
                    if (note.IsTrash)
                    {
                        this.context.Notes.Remove(note);
                        var result = this.context.SaveChangesAsync();
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Id", id.ToString())
                        }),
                            Expires = DateTime.UtcNow.AddDays(1),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var securityTokenHandler = new JwtSecurityTokenHandler();
                        var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                        var token = securityTokenHandler.WriteToken(securityToken);
                        var cacheKey = id + " DeleteTrash";
                        ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                        IDatabase database = connectionMultiplexer.GetDatabase();
                        database.StringSet(cacheKey, token.ToString());
                        database.StringGet(cacheKey);
                        return "Deleted from Trash";
                    }
                    return "This Note is Not Trash";
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Task<int> ArchieveNotes(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                    note.IsArchive = true;
                    var result = this.context.SaveChangesAsync();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Id", id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var securityTokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                    var token = securityTokenHandler.WriteToken(securityToken);
                    var cacheKey = id + " Archieve";
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(cacheKey, token.ToString());
                    database.StringGet(cacheKey);
                    return result;
                }
                return null; 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> DeleteArchievedNote(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                    if (note.IsArchive)
                    {
                        note.IsTrash = true;
                        var result = this.context.SaveChangesAsync();
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Id", id.ToString())
                        }),
                            Expires = DateTime.UtcNow.AddDays(1),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var securityTokenHandler = new JwtSecurityTokenHandler();
                        var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                        var token = securityTokenHandler.WriteToken(securityToken);
                        var cacheKey = id + " DeleteArchieve";
                        ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                        IDatabase database = connectionMultiplexer.GetDatabase();
                        database.StringSet(cacheKey, token.ToString());
                        database.StringGet(cacheKey);
                        return "Deleted";
                    }
                    return "No";
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Task<int> SetRemainder(int id, string time)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                    note.Remainder = time;
                    var result = this.context.SaveChangesAsync();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Id", id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var securityTokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                    var token = securityTokenHandler.WriteToken(securityToken);
                    var cacheKey = id + " SetRemainder";
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(cacheKey, token.ToString());
                    database.StringGet(cacheKey);
                    return result;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Task<int> DeleteRemainder(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                    if (!note.Remainder.Equals(string.Empty))
                    {
                        note.Remainder = string.Empty;
                        var result = this.context.SaveChangesAsync();
                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Id", id.ToString())
                        }),
                            Expires = DateTime.UtcNow.AddDays(1),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var securityTokenHandler = new JwtSecurityTokenHandler();
                        var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                        var token = securityTokenHandler.WriteToken(securityToken);
                        var cacheKey = id + " DeleteRemainder";
                        ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                        IDatabase database = connectionMultiplexer.GetDatabase();
                        database.StringSet(cacheKey, token.ToString());
                        database.StringGet(cacheKey);
                        return result;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> SetColor(int id, string color)
        {
            try
            {
                if (this.FindById(id))
                {
                    var notesCheck = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                    notesCheck.Color = color;
                    var result = this.context.SaveChangesAsync();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Id", id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var securityTokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                    var token = securityTokenHandler.WriteToken(securityToken);
                    var cacheKey = id + " SetColor";
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(cacheKey, token.ToString());
                    database.StringGet(cacheKey);
                    return "Color Changed";
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IEnumerable<NotesModel> GetAllNotes()
        {
            try
            {
                var allNotes = this.context.Notes.ToList();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Id", allNotes.ToString())
                        }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                };
                var securityTokenHandler = new JwtSecurityTokenHandler();
                var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                var token = securityTokenHandler.WriteToken(securityToken);
                var cacheKey = "AllNotes";
                ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                IDatabase database = connectionMultiplexer.GetDatabase();
                database.StringSet(cacheKey, token.ToString());
                database.StringGet(cacheKey);
                return allNotes;
            }
            catch (Exception) 
            {
                throw new Exception();
            }
        }
        public async Task<NotesModel> GetNotesById(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Id", note.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var securityTokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                    var token = securityTokenHandler.WriteToken(securityToken);
                    var cacheKey = id + " GetById";
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(cacheKey, token.ToString());
                    database.StringGet(cacheKey);
                    return note;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        
        public async Task<ImageUploadResult> UploadImage(int id, string imagePath)
        {
            if (this.FindById(id))
            {
                var note = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                Account account = new Account(CloudName, APIKey, APISecret);
                Cloudinary cloudinary = new Cloudinary(account);
                try
                {
                    var uploadparams = new ImageUploadParams()
                    {
                        File = new FileDescription(imagePath)
                    };
                    var uploadResult = cloudinary.Upload(uploadparams);
                    note.Image = string.Empty;
                    note.Image = uploadResult.Uri.ToString();
                    note.ModifiedTime = DateTime.Now;
                    var result = this.context.SaveChangesAsync();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Id", uploadparams.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var securityTokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                    var token = securityTokenHandler.WriteToken(securityToken);
                    var cacheKey = "Upload";
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(cacheKey, token.ToString());
                    database.StringGet(cacheKey);
                    return uploadResult;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return null;
        }
        public IQueryable<NotesModel> Search(string searchParameter)
        {
            try
            {
                var results = this.context.Notes.AsQueryable();

                foreach (var values in searchParameter)
                {
                    results = results.Where(emailId => emailId.Email.Contains(values) || emailId.Description.Contains(values) || 
                    emailId.Title.Contains(values));
                }
                foreach (var singleResult in results)
                {
                    if (singleResult.Email.Equals(searchParameter))
                    {
                        return results.Where(singleSearch => singleSearch.Email == searchParameter || singleSearch.Description == searchParameter ||
                        singleSearch.Title == searchParameter);
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<string> AddCollaborator(int noteId, string collaboratorEmail)
        {
            try
            {
                if (this.FindById(noteId))
                {
                    var note = this.context.Notes.Where(notesId => notesId.NotesId1 == noteId).SingleOrDefault();
                    note.Collaboratator = collaboratorEmail;
                    MailMessage mail = new MailMessage();
                    mail.To.Add(collaboratorEmail);
                    mail.From = new MailAddress("bhush087@gmail.com");
                    mail.Subject = "Title :" + note.Title;
                    string Body = "(" + note.Email+ ") shared a note with you. " + "Description :" + note.Description;
                    mail.Body = Body;
                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("bhush087@gmail.com", "Bhushan087***");
                    smtp.Send(mail);
                    var result = await this.context.SaveChangesAsync();
                    return "Collabrator added and Note sent successfully";
                }
                return "Id Not available";
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<string> DeleteCollaborator(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                    if (note.Collaboratator.Equals(string.Empty) || note.Collaboratator == null)
                    {
                        return "No Collaborators available";
                    }
                    note.Collaboratator = string.Empty;
                    await this.context.SaveChangesAsync();
                    return "Deleted";
                }
                return "Id Is invalid";
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
