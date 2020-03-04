using Model.Common.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo.AccountRepository
{
    public interface IAccountRepository
    {
        Task<int> Register(Register register);
        Task<int> Update(Register register);
    }
}
