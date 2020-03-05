/////------------------------------------------------------------------------
////<copyright file="AccountRepo.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace Repository.Repo
{
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
    using StackExchange.Redis;

    /// <summary>
    /// This is the account repository
    /// </summary>
    /// <seealso cref="Repository.Repo.IAccountRepo" />
    public class AccountRepo : IAccountRepo
    {
        /// <summary>
        /// The context
        /// </summary>
        public readonly UserDBContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepo"/> class.
        /// </summary>
        /// <param name="userDBContext">The user database context.</param>
        public AccountRepo(UserDBContext userDBContext)
        {
            this.context = userDBContext;
        }

        /// <summary>
        /// Finds the account by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns presense of ID</returns>
        public bool FindAccountById(int id)
        {
            try
            {
                var account = this.context.Registers.Where(accountId => accountId.Id == id).SingleOrDefault();
                if (account.Id == id)
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
        /// Deletes the specified identifier.
        /// </summary>
        /// It delete the registered account if it is available.
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// status of delete
        /// </returns>
        /// <exception cref="Exception">throw an exception</exception>
        public async Task<string> Delete(int id)
        {
            try 
            {
                var removeUser = this.context.Registers.Where(userId => userId.Id == id).SingleOrDefault();
                if (this.FindAccountById(id))
                {
                    this.context.Registers.Remove(removeUser);
                    var result = await Task.Run(() => this.context.SaveChangesAsync());
                    return result.ToString();
                }

                return "";
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Registers the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>
        /// returns status of register which is registered
        /// </returns>
        /// <exception cref="Exception">throw exceptions</exception>
        public async Task<int> Register(Registration register)
        {
            try
            {
                if (!this.CheckUserByEmail(register.Email))
                {
                    Registration add = new Registration()
                    {
                        //Id = register.Id,
                        Name = register.Name,
                        Email = register.Email,
                        Password = register.Password
                    };
                    this.context.Registers.Add(add);
                    var result = await Task.Run(() => this.context.SaveChangesAsync());
                    return result;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Updates the specified register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>
        /// status of update if email id and register id available
        /// </returns>
        /// <exception cref="Exception">throw the exception</exception>
        public async Task<int> Update(string email, int id, Registration register)
        {
            try 
            {
                if (this.CheckUserByEmailForUpdate(email, id))
                {
                    var updateUser = context.Registers.Find(id);
                    updateUser.Name = register.Name;
                    updateUser.Email = register.Email;
                    updateUser.Password = register.Password;
                    var result = this.context.SaveChangesAsync();
                    return await result;
                }
                return 0;
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
            var userCheck =  this.context.Registers.Where(userId => userId.Email == loginModel.Email).SingleOrDefault();
            if (userCheck != null && await Task.Run(() => this.CheckUser(loginModel.Email, loginModel.Password)))
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
                    SmtpClient smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        EnableSsl = true,
                        Credentials = new NetworkCredential("bhush087@gmail.com", "Bhushan087***")
                    };
                    smtp.Send(mail);
                    return await Task.Run(() => "Success");
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
                    SmtpClient smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        EnableSsl = true,
                        Credentials = new NetworkCredential("bhush087@gmail.com", "Bhushan087***")
                    };
                    smtp.Send(mail);
                    return await Task.Run(() => "Success");
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
            try
            {
                var userCheck = this.context.Registers.Where(userId => userId.Email == email).SingleOrDefault();
                if (userCheck.Email.Equals(email))
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
        public bool CheckUserByEmailForUpdate(string email, int id)
        {
            try
            {
                var userCheck = this.context.Registers.Where(user => user.Email == email).SingleOrDefault();
                if (userCheck.Email.Equals(email) && userCheck.Id == id)
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
        public bool CheckUser(string email,string password)
        {
            var userCheck = this.context.Registers.Where(userId => userId.Email == email).SingleOrDefault();
            if(userCheck.Email.Equals(email) && userCheck.Password == password)
            {
                return true;
            }
            return false;
        }
        public async Task<Registration> LoginByGoogle(Login loginModel)
        {
            var userCheck = this.context.Registers.Where(userId => userId.Email == loginModel.Email).SingleOrDefault();
            //var userCheck = this.context.Registers.Where(userId => userId.Email == loginModel.Email).SingleOrDefault();
            if (userCheck != null && this.CheckUserByEmail(loginModel.Email))
            {
                try
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Id", userCheck.Id.ToString()),
                            new Claim("Name", userCheck.Name.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var securityTokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                    var token = securityTokenHandler.WriteToken(securityToken);
                    var cacheKey = "GoogleLogin";////loginModel.Email;
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(cacheKey, token.ToString());
                    database.StringGet(cacheKey);
                    // return new JwtSecurityTokenHandler().WriteToken(token) + "    expiration:" + token.ValidTo;
                    return await Task.Run(() => userCheck);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Email", loginModel.Email)
                        }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                };
                var securityTokenHandler = new JwtSecurityTokenHandler();
                var securityToken = securityTokenHandler.CreateToken(tokenDescriptor);
                var token = securityTokenHandler.WriteToken(securityToken);
                var cacheKey = loginModel.Email;
                ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                IDatabase database = connectionMultiplexer.GetDatabase();
                database.StringSet(cacheKey, token.ToString());
                database.StringGet(cacheKey);
                return new Registration {
                    Name = "Visitor",
                    Email = loginModel.Email
                };
            }
        } 

        public async Task<string> LogOutFromSocialAccount()
        {
            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            IDatabase database = connectionMultiplexer.GetDatabase();
            if (database.KeyExists("GoogleLogin"))
            {
                await Task.Run(() => database.KeyDelete("GoogleLogin"));
                return "LoggedOut form Google Account";
            }
            return "You are not loged in through social Account";
        }
    }
}
