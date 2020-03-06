/////------------------------------------------------------------------------
////<copyright file="ILabelRepo.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace Repository.IRepo
{
    using System.Collections;
    using System.Threading.Tasks;
    using Model.Account;

    /// <summary>
    /// This is the label repository interface
    /// </summary>
    public interface ILabelRepo
    {
        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>status of the add label</returns>
        Task<string> AddLabel(LabelModel labelModel);

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>status of the delete label</returns>
        Task<string> DeleteLabel(string labelName);

        /// <summary>
        /// Gets all labels.
        /// </summary>
        /// <returns>All available labels</returns>
        Task<IEnumerable> GetAllLabels();

        /// <summary>
        /// Gets the label by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>label by id</returns>
        Task<LabelModel> GetLabelById(int id);

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="labelModel">The label model.</param>
        /// <returns>status of the update label</returns>
        Task<string> UpdateLabel(int id, string labelName, LabelModel labelModel);

        /// <summary>
        /// Renames the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>status of the rename label</returns>
        Task<int> RenameLabel(string currentLabelName, string newLabelName);

        /// <summary>
        /// Deletes the note from label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>status of the Delete note from Label</returns>
        Task<string> DeleteNoteFromLabel(int id);
    }
}
