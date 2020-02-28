using Model.Account;
using Repository.Repo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Account
{
    public class AccountManager : IAccountManager
    {
        public readonly IAccountRepo accountRepository;
        public AccountManager(IAccountRepo accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Task<int> Delete(int id)
        {
            try 
            {
                var result = this.accountRepository.Delete(id);
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
                var list = this.accountRepository.GetAll();
                return list;
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
                var singleUser = this.accountRepository.GetById(id);
                return singleUser;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<string> Login(Login loginModel)
        {
            try
            {
                var result = accountRepository.Login(loginModel);
                return result;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<int> Register(Registration register)
        {
            try
            {
                var result = accountRepository.Register(register);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<string> ResetPassword(string email)
        {
            try
            {
                var result = accountRepository.ResetPassword(email);
                return result;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<int> Update(Registration register)
        {
            try
            {
                var result = accountRepository.Update(register);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
