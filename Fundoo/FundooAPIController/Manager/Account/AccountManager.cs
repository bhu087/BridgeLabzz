using Model.Common.Account;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Repository.Repo.AccountRepository;

namespace Manager.Account
{
    public class AccountManager : IAccountManager
    {
        public readonly IAccountRepository accountRepository;
        public AccountManager(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public Task<int> LoginAsync(Login loginModel)
        {
            //UserAction userAction = new UserAction();
            //var flag = userAction.LoginAsync(loginModel);
            return default;
        }

        public Task<int> RegisterAsync(Register register)
        {
            return accountRepository.Register(register);
        }
    }
}
