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
                var result = this.context.Lables.Where(labelId => labelId.LabelId == id).ToList();
                //if (result.LabelId == id)
                //{
                //    return true;
                //}
                foreach (var availableId in result)
                {
                    if (availableId.LabelId == id)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool FindByIdAndName(LabelModel labelModel)
        {
            try
            {
                var result = this.context.Lables.Where(labelId => labelId.LabelId == labelModel.LabelId).ToList();
                foreach (var availableId in result)
                {
                    if (availableId.LabelId == labelModel.LabelId && availableId.LabelName.Equals(labelModel.LabelName))
                    {
                        return false;
                    }
                }
                return true;
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
                var note = this.context.Notes.Where(noteId => noteId.NotesId1 == labelModel.LabelId).SingleOrDefault();
                if (note == null)
                {
                    return "Note not available";
                }
                //if (this.FindById(labelModel.LabelId))
                //{
                //    return "This note available in anethor label";
                //}
                if (this.FindByIdAndName(labelModel))
                {
                    LabelModel add = new LabelModel()
                    {
                        LabelId = labelModel.LabelId,
                        LabelName = labelModel.LabelName
                    };
                    this.context.Lables.Add(add);
                    var result = await Task.Run(() => this.context.SaveChangesAsync());
                    return "Saved";
                }
                return "Not saved"; 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<string> DeleteLabel(string labelName)
        {
            try
            {
                var removeLabel = this.context.Lables.Where(labelId => labelId.LabelName == labelName).ToList();
                if (removeLabel.Count > 0)
                {
                    foreach (var label in removeLabel)
                    {
                        this.context.Lables.Remove(label);
                    }
                    var result = await Task.Run(() => this.context.SaveChangesAsync());
                    return "Deleted";
                }
                return "Label Not available"; 
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<string> DeleteNoteFromLabel(int id)
        {
            try
            {
                var removeLabel = this.context.Lables.Where(labelId => labelId.LabelId == id).SingleOrDefault();
                if (removeLabel != null)
                {
                    this.context.Lables.Remove(removeLabel);
                    var result = await Task.Run(() => this.context.SaveChangesAsync());
                    return "Deleted";
                }
                return "Id Not available in Labels";
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
                var list = await Task.Run(() => this.context.Lables.ToList());
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
                    var label = await Task.Run(() => this.context.Lables.Where(labelId => labelId.LabelId == id).SingleOrDefault());
                    return label;
                }
                return new LabelModel();
            }
            catch (Exception)
            {
                return new LabelModel();
            }
        }

        public async Task<string> UpdateLabel(int id, string labelName, LabelModel labelModel)
        {
            try
            {
                if (this.FindById(id))
                {
                    var label = this.context.Lables.Where(labelId => labelId.LabelId == id).ToList();
                    foreach (var labels in label)
                    {
                        if (labels.LabelName == labelName)
                        {
                            labels.LabelId = labelModel.LabelId;
                            labels.LabelName = labelModel.LabelName;
                            var result = this.context.SaveChangesAsync();
                            return await Task.Run(() => "Updated");
                        }
                    }
                    return "";
                }
                return "";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<int> RenameLabel(int id, string newLabelName)
        {
            try
            {
                var label = this.context.Lables.Where(labelId => labelId.LabelId == id).SingleOrDefault();
                if (label != null)
                {
                    label.LabelName = newLabelName;
                    var result = await Task.Run(() => this.context.SaveChangesAsync());
                    return result;
                }
                return 0;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
