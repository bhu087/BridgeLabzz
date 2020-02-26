using Model.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public interface IAccountRepo
    {
        Task<int> Register(Registration register);
        Task<int> Delete(int id);
        Task<int> Update(Registration register);
        IEnumerable<Registration> GetAll();
        Registration GetById(int id);
        Task<Registration> Login(Login loginModel);
    }
}
