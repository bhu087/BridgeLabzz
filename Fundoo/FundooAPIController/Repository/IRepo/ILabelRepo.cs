using Model.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepo
{
    public interface ILabelRepo
    {
        Task<int> AddNotes(LabelModel labelModel);
    }
}
