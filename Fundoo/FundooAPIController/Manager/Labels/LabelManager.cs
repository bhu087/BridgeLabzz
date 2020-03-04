using Model.Account;
using Repository.IRepo;
using System;
using System.Collections;
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

        public Task<string> DeleteLabel(int id)
        {
            try
            {
                var result = this.labelRepo.DeleteLabel(id);
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Task<IEnumerable> GetAllLabels()
        {
            try
            {
                var result = this.labelRepo.GetAllLabels();
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Task<LabelModel> GetLabelById(int id)
        {
            try
            {
                var result = this.labelRepo.GetLabelById(id);
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Task<string> UpdateLabel(int id, string labelName, LabelModel labelModel)
        {
            try
            {
                var result = this.labelRepo.UpdateLabel(id, labelName, labelModel);
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
