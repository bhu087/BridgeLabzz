using Model.Account;
using Repository.Context;
using Repository.IRepo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{

    public class LabelRepo : ILabelRepo
    {
        public readonly UserDBContext context;
        public LabelRepo(UserDBContext context)
        {
            this.context = context;
        }
        public bool FindById(int id)
        {
            try
            {
                var result = this.context.Lables.Where(labelId => labelId.LabelId == id).SingleOrDefault();
                if (result.LabelId == id)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
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
                var result = await this.context.SaveChangesAsync();
                return "Saved";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<string> DeleteLabel(int id)
        {
            try
            {
                if (!this.FindById(id))
                {
                    return "Not Deleted";
                }
                else
                {
                    var removeLabel = this.context.Lables.Where(labelId => labelId.LabelId == id).SingleOrDefault();
                    this.context.Lables.Remove(removeLabel);
                    var result = await this.context.SaveChangesAsync();
                    return "Deleted";
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable> GetAllLabels()
        {
            try
            {
                var list = this.context.Lables.ToList();
                return list;
            }
            catch (Exception)
            {
                List<string> list = new List<string>();
                return list;
            }
        }

        public async Task<LabelModel> GetLabelById(int id)
        {
            try
            {
                if (this.FindById(id))
                {
                    var label = this.context.Lables.Where(labelId => labelId.LabelId == id).SingleOrDefault();
                    return label;
                }
                return new LabelModel();
            }
            catch (Exception)
            {
                return new LabelModel();
            }
        }

        public async Task<string> UpdateLabel(LabelModel labelModel)
        {
            try
            {
                if (this.FindById(labelModel.LabelId))
                {
                    LabelModel add = new LabelModel()
                    {
                        LabelId = labelModel.LabelId,
                        LabelName = labelModel.LabelName
                    };
                    var label = this.context.Lables.Where(labelId => labelId.LabelId == labelModel.LabelId).SingleOrDefault();
                    label.LabelId = labelModel.LabelId;
                    label.LabelName = labelModel.LabelName;
                    var result = await this.context.SaveChangesAsync();
                    return "Updated";
                }
                return "";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
