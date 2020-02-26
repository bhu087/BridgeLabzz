using Model.Account;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
