using Microsoft.IdentityModel.Tokens;
using Model.Account;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<Registration> Login(Login loginModel)
        {
            var userCheck = this.context.Registers.Where(userId => userId.Id == loginModel.Id).SingleOrDefault();
            if (userCheck != null && this.CheckName(loginModel.Id, loginModel.Name))
            {
                try
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                       new Claim("Id",userCheck.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello this is Radis Cache")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    var cacheKey = loginModel.Id;
                    return userCheck;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return new Registration();
        }
        public bool CheckName(int id,string name)
        {
            var userCheck = this.context.Registers.Where(userId => userId.Id == id).SingleOrDefault();
            if(userCheck.Name.Equals(name) && userCheck.Id == id)
            {
                return true;
            }
            return false;
        }
    }
}
