/////------------------------------------------------------------------------
////<copyright file="LabelRepo.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace Repository.Repo
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Model.Account;
    using Repository.Context;
    using Repository.IRepo;

    /// <summary>
    /// this is the Label repository
    /// </summary>
    /// <seealso cref="Repository.IRepo.ILabelRepo" />
    public class LabelRepo : ILabelRepo
    {
        /// <summary>
        /// The context
        /// </summary>
        public readonly UserDBContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelRepo"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public LabelRepo(UserDBContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>status of label in database</returns>
        public bool FindById(int id)
        {
            try
            {
                var result = this.context.Lables.Where(labelId => labelId.LabelId == id).ToList();
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

        /// <summary>
        /// Finds the name of the by identifier and.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>status of the label by ID and Name</returns>
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

        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>
        /// status of the add label
        /// </returns>
        /// <exception cref="System.Exception">throw exception</exception>
        public async Task<string> AddLabel(LabelModel labelModel)
        {
            try
            {
                var note = this.context.Notes.Where(noteId => noteId.NotesId1 == labelModel.LabelId).SingleOrDefault();
                if (note == null)
                {
                    return "Note not available";
                }

                var labelId = this.context.Lables.Where(label => label.LabelId == labelModel.LabelId).SingleOrDefault();
                if (labelId != null)
                {
                    return "Label already in other Label";
                }
                    LabelModel add = new LabelModel()
                    {
                        LabelId = labelModel.LabelId,
                        LabelName = labelModel.LabelName
                    };
                    this.context.Lables.Add(add);
                    var result = await Task.Run(() => this.context.SaveChangesAsync());
                    return "Saved";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>
        /// status of the delete label
        /// </returns>
        /// <exception cref="System.Exception">throw exception</exception>
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

        /// <summary>
        /// Deletes the note from label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// status of the Delete note from Label
        /// </returns>
        /// <exception cref="System.Exception">throw exception</exception>
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

        /// <summary>
        /// Gets all labels.
        /// </summary>
        /// <returns>
        /// All available labels
        /// </returns>
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

        /// <summary>
        /// Gets the label by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// label by id
        /// </returns>
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

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="labelModel">The label model.</param>
        /// <returns>
        /// status of the update label
        /// </returns>
        /// <exception cref="System.Exception">throw exception</exception>
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

                    return string.Empty;
                }

                return string.Empty;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Renames the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>
        /// status of the rename label
        /// </returns>
        /// <exception cref="System.Exception">throw exception</exception>
        public async Task<int> RenameLabel(string currentLabelName, string newLabelName)
        {
            try
            {
                var labelList = this.context.Lables.Where(labelName => labelName.LabelName == currentLabelName).ToList();
                if (labelList.Count > 0)
                {
                    foreach (var label in labelList)
                    {
                        label.LabelName = newLabelName;
                    }
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
