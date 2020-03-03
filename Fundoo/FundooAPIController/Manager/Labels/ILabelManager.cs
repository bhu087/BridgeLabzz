using Model.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Labels
{
   public interface ILabelManager
    {
        Task<string> AddLabel(LabelModel labelModel);
        Task<string> DeleteLabel(int id);
    }
}
