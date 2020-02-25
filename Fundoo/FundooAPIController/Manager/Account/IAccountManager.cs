using Model.Common.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Account
{
    public interface IAccountManager
    {
        Task<bool> LoginAsync(Login loginModel);
    }
}
