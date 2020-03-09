/////------------------------------------------------------------------------
////<copyright file="NotesRepo.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace Repository.Repo
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.IdentityModel.Tokens;
    using Model.Account;
    using Model.Notes;
    using Repository.Context;
    using Repository.IRepo;
    using StackExchange.Redis;
    using UtilityProject;

    /// <summary>
    /// /This is the Notes repository
    /// </summary>
    /// <seealso cref="Repository.IRepo.INotesRepo" />
    public class NotesRepo : INotesRepo
    {
        /// <summary>
        /// The cloud name
        /// </summary>
        public const string CloudName = "bhu087";

        /// <summary>
        /// The API key
        /// </summary>
        public const string APIKey = "354171364155512";

        /// <summary>
        /// The API secret
        /// </summary>
        public const string APISecret = "ZtRMv8zmp1hqFjyFAeOpNNj2p3A";

        /// <summary>
        /// The context
        /// </summary>
        public readonly UserDBContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepo"/> class.
        /// </summary>
        /// <param name="userDBContext">The user database context.</param>
        public NotesRepo(UserDBContext userDBContext)
        {
            this.context = userDBContext;
        }

        /// <summary>
        /// Duplicates the emails.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>return duplicate emails status</returns>
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

        /// <summary>
        /// Duplicates the emails update.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>returns status for duplicates while update</returns>
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

        /// <summary>
        /// Duplicates the emails with note identifier.
        /// </summary>
        /// <param name="collaborator">The collaborator.</param>
        /// <returns>Returns duplicate status with email and id</returns>
        public bool DuplicateEmailsWithNoteId(CollaboratorModel collaborator)
        {
            var emailsAndNoteId = this.context.Collaborator.Where(notesEmail => notesEmail.ReceiverEmail1 == collaborator.ReceiverEmail1).ToList();
            foreach (var dataBaseEmail in emailsAndNoteId)
            {
                if (dataBaseEmail.ReceiverEmail1.Equals(collaborator.ReceiverEmail1) && dataBaseEmail.SenderEmail.Equals(collaborator.SenderEmail)
                    && dataBaseEmail.NoteId == collaborator.NoteId)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">throw Exception</exception>
        public async Task<int> AddNotes(NotesModel notesModel)
        {
            try
            {
                if (!this.DuplicateEmails(notesModel.Email))
                {
                    this.context.Notes.Add(notesModel);
                    var result = this.context.SaveChangesAsync();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                            {
                            new Claim("Email", notesModel.Email),
                            new Claim("Title", notesModel.Title),
                            new Claim("Description", notesModel.Description),
                            new Claim("CreatedTime", notesModel.CreatedTime.ToString())
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
                    database.StringSet(cacheKey, token);
                    return await result;
                }

                return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
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
                    var cacheKey = "Update";
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(cacheKey, token.ToString());
                    database.StringGet(cacheKey);
                    return await Task.Run(() => "Saved");
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Edits the title.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
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
                    var cacheKey = "Edit";
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(cacheKey, token.ToString());
                    database.StringGet(cacheKey);
                    return await Task.Run(() => "Title Updated");
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>status of note by Id</returns>
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

        /// <summary>
        /// Finds the collaborator by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Finds Collaborator by Id</returns>
        public bool FindCollaboratorById(int id)
        {
            try
            {
                var collaboratorCheck = this.context.Collaborator.Where(colaboratorNoteId => colaboratorNoteId.NoteId == id).ToList();
                foreach (var collaborator in collaboratorCheck)
                {
                    if (collaborator.NoteId == id)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
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
                    var cacheKey = "Delete";
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

        /// <summary>
        /// Deletes the trash.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
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
                        var cacheKey = "DeleteTrash";
                        ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                        IDatabase database = connectionMultiplexer.GetDatabase();
                        database.StringSet(cacheKey, token.ToString());
                        database.StringGet(cacheKey);
                        return await Task.Run(() => "Deleted from Trash");
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

        /// <summary>
        /// Archive the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
        public async Task<int> ArchiveNotes(int id)
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
                    var cacheKey = "Archieve";
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(cacheKey, token.ToString());
                    database.StringGet(cacheKey);
                    return await Task.Run(() => result);
                }

                return 0; 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Deletes the archive note.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
        public async Task<string> DeleteArchivedNote(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                    if (note.IsArchive)
                    {
                        note.IsArchive = false;
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
                        var cacheKey = "DeleteArchieve";
                        ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                        IDatabase database = connectionMultiplexer.GetDatabase();
                        database.StringSet(cacheKey, token.ToString());
                        database.StringGet(cacheKey);
                        return await Task.Run(() => "Deleted");
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

        /// <summary>
        /// Sets the remainder.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="time">The time.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
        public async Task<int> SetRemainder(int id, string time)
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
                    var cacheKey = "SetRemainder";
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(cacheKey, token.ToString());
                    database.StringGet(cacheKey);
                    return await Task.Run(() => result);
                }

                return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Deletes the remainder.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
        public async Task<int> DeleteRemainder(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(notesId => notesId.NotesId1 == id).SingleOrDefault();
                    var res = await Task.Run(() => note.Remainder);
                    if (res != null && !res.Equals(string.Empty))
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
                        var cacheKey = "DeleteRemainder";
                        ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                        IDatabase database = connectionMultiplexer.GetDatabase();
                        database.StringSet(cacheKey, token.ToString());
                        database.StringGet(cacheKey);
                        return await Task.Run(() => result);
                    }

                    return 0;
                }

                return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Sets the color.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="color">The color.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
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
                    var cacheKey = "SetColor";
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(cacheKey, token.ToString());
                    database.StringGet(cacheKey);
                    return await Task.Run(() => "Color Changed");
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets all notes.
        /// </summary>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
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

        /// <summary>
        /// Gets the notes by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
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
                    var cacheKey = "GetById";
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(cacheKey, token.ToString());
                    database.StringGet(cacheKey);
                    return await Task.Run(() => note);
                }

                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Uploads the image.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="imagePath">The image path.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
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
                    var result = this.context.SaveChangesAsync();
                    return  uploadResult;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }

            return null;
        }

        /// <summary>
        /// Search result
        /// </summary>
        /// <param name="searchParameter">List of search results</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
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

        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="collaboratorEmail">The collaborator email.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
        public async Task<string> AddCollaborator(int noteId, string collaboratorEmail)
        {
            try
            {
                if (this.FindById(noteId))
                {
                    var note = this.context.Notes.Where(notesId => notesId.NotesId1 == noteId).SingleOrDefault();
                    CollaboratorModel collaborator = new CollaboratorModel()
                    {
                        NoteId = noteId,
                        SenderEmail = note.Email,
                        ReceiverEmail1 = collaboratorEmail
                    };
                    if (this.DuplicateEmailsWithNoteId(collaborator))
                    {
                        this.context.Collaborator.Add(collaborator);
                        bool connectivity = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                        string body = "(" + note.Email + ") shared a note with you. " + "Description :" + note.Description;
                        if (connectivity)
                        {
                            MailMessage mail = new MailMessage();
                            mail.To.Add(collaboratorEmail);
                            mail.From = new MailAddress("bhush087@gmail.com");
                            mail.Subject = "Title :" + note.Title;
                            mail.Body = body;
                            mail.IsBodyHtml = false;
                            SmtpClient smtp = new SmtpClient
                            {
                                Host = "smtp.gmail.com",
                                EnableSsl = true,
                                Credentials = new NetworkCredential("bhush087@gmail.com", "Bhushan087***")
                            };
                            smtp.Send(mail);
                            var result = await this.context.SaveChangesAsync();
                            return "Collabrator added and Note sent successfully";
                        }
                        else
                        {
                            ToSendMSMQ utilityProject = new ToSendMSMQ();
                            utilityProject.StoreToMSMQ(collaboratorEmail, "Title :" + note.Title, body);
                            return "Check Internet Messages are in QUEUE";
                        }
                    }

                    return "Duplicate Receiver found";
                }

                return "Id Not available";
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="receiverEmail">The receiver email.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
        public async Task<string> DeleteCollaborator(int id, string receiverEmail)
        {
            try
            {
                if (this.FindById(id) && this.FindCollaboratorById(id))
                {
                    var collaboratorList = this.context.Collaborator.Where(CollaboratorNoteId => CollaboratorNoteId.ReceiverEmail1 == receiverEmail).ToList();
                    foreach (var collaboratorEmail in collaboratorList)
                    {
                        if (collaboratorEmail.ReceiverEmail1 == receiverEmail)
                        {
                            this.context.Collaborator.Remove(collaboratorEmail);
                            await this.context.SaveChangesAsync();
                            return "Deleted";
                        }
                    }

                    return "This Collaborator not available";
                }

                return "Id Is invalid";
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Sets the pin.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
        public async Task<string> SetPin(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(noteId => noteId.NotesId1 == id).SingleOrDefault();
                    if (note.IsPin == true)
                    {
                        return "Already Pinned";
                    }

                    note.IsPin = true;
                    await Task.Run(() => this.context.SaveChangesAsync());
                    return "Pinned";
                }

                return "Note not Available in this ID";
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Removes the pin.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw Exception</exception>
        public async Task<string> RemovePin(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var note = this.context.Notes.Where(noteId => noteId.NotesId1 == id).SingleOrDefault();
                    if (note.IsPin == true)
                    {
                        note.IsPin = false;
                        await Task.Run(() => this.context.SaveChangesAsync());
                        return "UnPinned";
                    }

                    return "Not Pinned Yet";
                }

                return "Note not Available in this ID";
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
