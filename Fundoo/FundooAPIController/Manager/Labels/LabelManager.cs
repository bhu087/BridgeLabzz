/////------------------------------------------------------------------------
////<copyright file="LabelManager.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace Manager.Labels
{
    using System;
    using System.Collections;
    using System.Threading.Tasks;
    using Model.Account;
    using Repository.IRepo;

    /// <summary>
    /// this is the Label manager class
    /// </summary>
    /// <seealso cref="Manager.Labels.ILabelManager" />
    public class LabelManager : ILabelManager
    {
        /// <summary>
        /// The label repo
        /// </summary>
        public readonly ILabelRepo labelRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelManager"/> class.
        /// </summary>
        /// <param name="labelRepo">The label repo.</param>
        public LabelManager(ILabelRepo labelRepo)
        {
            this.labelRepo = labelRepo;
        }

        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>
        /// status of add label
        /// </returns>
        /// <exception cref="System.Exception">Throw Exception</exception>
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

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>
        /// status of Delete label
        /// </returns>
        /// <exception cref="System.Exception">Throw Exception</exception>
        public Task<string> DeleteLabel(string labelName)
        {
            try
            {
                var result = this.labelRepo.DeleteLabel(labelName);
                return result;
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
        /// status of the delete only one note from label
        /// </returns>
        /// <exception cref="System.Exception">Throw Exception</exception>
        public Task<string> DeleteNoteFromLabel(int id)
        {
            try
            {
                var result = this.labelRepo.DeleteNoteFromLabel(id);
                return result;
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
        /// return all the labels
        /// </returns>
        /// <exception cref="System.Exception">Throw Exception</exception>
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

        /// <summary>
        /// Gets the label by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// return label by id
        /// </returns>
        /// <exception cref="System.Exception">Throw Exception</exception>
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

        /// <summary>
        /// Renames the label.
        /// </summary>
        /// <param name="currentLabelName">Current name of label</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>
        /// Rename label status
        /// </returns>
        /// <exception cref="System.Exception">Throw Exception</exception>
        public Task<int> RenameLabel(string currentLabelName, string newLabelName)
        {
            try
            {
                var result = this.labelRepo.RenameLabel(currentLabelName, newLabelName);
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Updates the label.
        /// its working like move from one label to other.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="labelModel">The label model.</param>
        /// <returns>
        /// status of update
        /// </returns>
        /// <exception cref="System.Exception">Throw Exception</exception>
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
