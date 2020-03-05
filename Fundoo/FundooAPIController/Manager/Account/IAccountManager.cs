using Model.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Account
{
    public interface IAccountManager
    {
        Task<int> Register(Registration register);
        Task<int> Delete(int id);
        Task<int> Update(Registration register);
        IEnumerable<Registration> GetAll();
        Registration GetById(int id);
        Task<string> Login(Login loginModel);
        Task<string> ResetPassword(string email);
        Task<Registration> LoginByGoogle(Login loginModel);
        Task<string> ForgetPassword(string email);
        Task<string> LogOutFromSocialAccount();
    }
}
