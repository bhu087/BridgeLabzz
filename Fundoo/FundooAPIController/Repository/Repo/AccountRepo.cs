using Microsoft.IdentityModel.Tokens;
using Model.Account;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Repository.Repo
{
    public class AccountRepo : IAccountRepo
    {
        public readonly UserDBContext context;
        public AccountRepo(UserDBContext userDBContext)
        {
            this.context = userDBContext;
        }

        public Task<int> Delete(int id)
        {
            try 
            {
                var removeUser = this.context.Registers.Where(userId => userId.Id == id).SingleOrDefault();
                this.context.Registers.Remove(removeUser);
                var result = this.context.SaveChangesAsync();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<int> Register(Registration register)
        {
            try
            {
                Registration add = new Registration()
                {
                    //Id = register.Id,
                    Name = register.Name,
                    Email = register.Email,
                    Password = register.Password
                };
                this.context.Registers.Add(add);
                var result = this.context.SaveChangesAsync();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<int> Update(Registration register)
        {
            try 
            {
                var updateUser = this.context.Registers.Where(userId => userId.Id == register.Id).SingleOrDefault();
                updateUser.Name = register.Name;
                updateUser.Email = register.Email;
                updateUser.Password = register.Password;
                var result = this.context.SaveChangesAsync();
                return result;
            } 
            catch (Exception e) 
            { 
                throw new Exception(e.Message); 
            }
        }
        public IEnumerable<Registration> GetAll()
        {
            try
            {
                //List<Registration> registrations = new List<Registration>();
                var allUser = this.context.Registers.ToList() ;
                return allUser;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Registration GetById(int id)
        {
            try
            {
                var singleUser = this.context.Registers.Where(userId => userId.Id == id).SingleOrDefault();
                return singleUser;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<string> Login(Login loginModel)
        {
            var userCheck = this.context.Registers.Where(userId => userId.Email == loginModel.Email).SingleOrDefault();
            //var userCheck = this.context.Registers.Where(userId => userId.Email == loginModel.Email).SingleOrDefault();
            if (userCheck != null && this.CheckUser(loginModel.Email, loginModel.Password))
            {
                try
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Id",userCheck.Id.ToString()),
                            new Claim("Name",userCheck.Name.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var securityTokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                    var token = securityTokenHandler.WriteToken(securityToken);
                    //var cacheKey = loginModel.Id;
                    return token;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return "Email Not Present";
        }
        public static void AppSettings(out string UserID, out string Password, out string SMTPPort, out string Host)
        {
            UserID = ConfigurationManager.AppSettings.Get("UserID");
            Password = ConfigurationManager.AppSettings.Get("Password");
            SMTPPort = ConfigurationManager.AppSettings.Get("SMTPPort");
            Host = ConfigurationManager.AppSettings.Get("Host");
        }
        public async Task<string> ResetPassword(string email)
        {
            var userCheck = this.context.Registers.Where(userId => userId.Email == email).SingleOrDefault();
            if (userCheck != null && CheckUserByEmail(email))
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(email);
                    //mail.CC.Add("ccid@hotmail.com");
                    mail.From = new MailAddress("bhush087@gmail.com");
                    mail.Subject = "Reset Account";
                    string Body = "https://www.w3schools.com/js/js_htmldom_animate.asp";
                    mail.Body = Body;
                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("bhush087@gmail.com", "Bhushan087***");
                    smtp.Send(mail);
                    return "Success";
                }
                catch (Exception)
                {
                    return "ex";
                }
                //return "OK";
            }
            else
            {
                return "This email address does not match our records.";
            }
        }
        public async Task<string> ForgetPassword(string email)
        {
            var userCheck = this.context.Registers.Where(userId => userId.Email == email).SingleOrDefault();
            if (userCheck != null && CheckUserByEmail(email))
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(email);
                    //mail.CC.Add("ccid@hotmail.com");
                    mail.From = new MailAddress("bhush087@gmail.com");
                    mail.Subject = "Reset Account : our Password is";
                    mail.Body = userCheck.Password;
                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("bhush087@gmail.com", "Bhushan087***");
                    smtp.Send(mail);
                    return "Success";
                }
                catch (Exception)
                {
                    return "ex";
                }
            }
            else
            {
                return "This email address does not match our records.";
            }
        }
        public bool CheckUserByEmail(string email)
        {
            var userCheck = this.context.Registers.Where(userId => userId.Email == email).SingleOrDefault();
            if (userCheck.Email.Equals(email))
            {
                return true;
            }
            return false;
        }
        public bool CheckUser(string email,string password)
        {
            var userCheck = this.context.Registers.Where(userId => userId.Email == email).SingleOrDefault();
            if(userCheck.Email.Equals(email) && userCheck.Password == password)
            {
                return true;
            }
            return false;
        }
        public async Task<string> LoginByGoogle(string email)
        {
            var userCheck = this.context.Registers.Where(userId => userId.Email == email).SingleOrDefault();
            //var userCheck = this.context.Registers.Where(userId => userId.Email == loginModel.Email).SingleOrDefault();
            if (userCheck != null && this.CheckUserByEmail(email))
            {
                try
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Email",userCheck.Email.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var securityTokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                    var token = securityTokenHandler.WriteToken(securityToken);
                    //var cacheKey = loginModel.Id;
                    return token;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return "Email Not Present";
        }
    }
}
