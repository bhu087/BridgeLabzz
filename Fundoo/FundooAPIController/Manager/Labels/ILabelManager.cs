/////------------------------------------------------------------------------
////<copyright file="ILabelManager.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace Manager.Labels
{
    using Model.Account;
    using System.Collections;
    using System.Threading.Tasks;

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
        /// <returns></returns>
        Task<IEnumerable> GetAllLabels();

        /// <summary>
        /// Gets the label by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<LabelModel> GetLabelById(int id);

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="labelModel">The label model.</param>
        /// <returns></returns>
        Task<string> UpdateLabel(int id, string labelName, LabelModel labelModel);

        /// <summary>
        /// Renames the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns></returns>
        Task<int> RenameLabel(int id, string newLabelName);

        /// <summary>
        /// Deletes the note from label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<string> DeleteNoteFromLabel(int id);
    }
}
