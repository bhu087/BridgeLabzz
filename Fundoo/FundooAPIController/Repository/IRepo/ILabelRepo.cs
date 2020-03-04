using Model.Account;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepo
{
    public interface ILabelRepo
    {
        Task<string> AddLabel(LabelModel labelModel);
        Task<string> DeleteLabel(int id);
        Task<IEnumerable> GetAllLabels();
        Task<LabelModel> GetLabelById(int id);
        Task<string> UpdateLabel(int id, string labelName, LabelModel labelModel);
    }
}
