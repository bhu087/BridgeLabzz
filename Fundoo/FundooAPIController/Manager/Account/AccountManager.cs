using Model.Common.Account;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Account
{
    class AccountManager : IAccountManager
    {
        public Task<bool> LoginAsync(Login loginModel)
        {
            UserDBContext userDBContext;
            var flag = LoginAsync(loginModel);
            return flag;
        }
    }
}
