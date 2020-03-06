/////------------------------------------------------------------------------
////<copyright file="ILabelManager.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace Manager.Labels
{
    using System.Collections;
    using System.Threading.Tasks;
    using Model.Account;

    /// <summary>
    /// This is the Label manager interface
    /// </summary>
    public interface ILabelManager
    {
        /// <summary>
        /// Adds the label.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>status of add label</returns>
        Task<string> AddLabel(LabelModel labelModel);

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>status of Delete label</returns>
        Task<string> DeleteLabel(string labelName);

        /// <summary>
        /// Gets all labels.
        /// </summary>
        /// <returns>return all the labels</returns>
        Task<IEnumerable> GetAllLabels();

        /// <summary>
        /// Gets the label by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>return label by id</returns>
        Task<LabelModel> GetLabelById(int id);

        /// <summary>
        /// Updates the label.
        /// its working like move from one label to other.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="labelModel">The label model.</param>
        /// <returns>status of update</returns>
        Task<string> UpdateLabel(int id, string labelName, LabelModel labelModel);

        /// <summary>
        /// Renames the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>Rename label status</returns>
        Task<int> RenameLabel(string currentLabelName, string newLabelName);

        /// <summary>
        /// Deletes the note from label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>status of the delete only one note from label</returns>
        Task<string> DeleteNoteFromLabel(int id);
    }
}
