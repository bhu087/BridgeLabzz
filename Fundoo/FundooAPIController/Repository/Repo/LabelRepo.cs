using Model.Account;
using Repository.Context;
using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{

    class LabelRepo : ILabelRepo
    {
        public readonly UserDBContext context;
        public LabelRepo(UserDBContext context)
        {
            this.context = context;
        }
        public async Task<string> AddLabel(LabelModel labelModel)
        {
            try
            {
                LabelModel add = new LabelModel()
                {
                    LabelId = labelModel.LabelId,
                    LabelName = labelModel.LabelName
                };
                this.context.Lables.Add(add);
                var result = this.context.SaveChangesAsync();
                return "Saved";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
