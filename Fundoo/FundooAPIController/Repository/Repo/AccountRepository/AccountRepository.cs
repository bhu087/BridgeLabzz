﻿using Model.Common.Account;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        public readonly UserDBContext userDBContext;
        public AccountRepository(UserDBContext userDBContext)
        {
            this.userDBContext = userDBContext;
        }
        public Task<int> Register(Register register)
        {
            Register add = new Register()
            {
                Name = register.Name,
                Email = register.Email,
                Password = register.Password
            };
            this.userDBContext.Registers.Add(add);
            var result = this.userDBContext.SaveChangesAsync();
            return result;
        }
    }
}
