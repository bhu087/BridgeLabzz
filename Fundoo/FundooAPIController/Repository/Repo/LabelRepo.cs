﻿using Model.Account;
using Repository.Context;
using Repository.IRepo;
using System;
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
                    var result = this.context.SaveChanges();
                    return "Deleted";
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
