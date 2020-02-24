using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Account
{
    public class AccountManager : IAccountManager
    {
        IAccountManager accountManager;
        public bool ForgetPassWord(User user)
        {
            return accountManager.ForgetPassWord(user);
        }

        public bool Login(User user)
        {
            return accountManager.Login(user);
        }

        public bool ResetPassword(User user)
        {
            return accountManager.ResetPassword(user);
        }
    }
}
