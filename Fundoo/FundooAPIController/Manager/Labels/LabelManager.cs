using Model.Account;
using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Labels
{
    public class LabelManager : ILabelManager
    {
        public readonly ILabelRepo labelRepo;
        public LabelManager(ILabelRepo labelRepo)
        {
            this.labelRepo = labelRepo;
        }
        public Task<string> AddLabel(LabelModel labelModel)
        {
            try
            {
                var result = this.labelRepo.AddLabel(labelModel);
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
