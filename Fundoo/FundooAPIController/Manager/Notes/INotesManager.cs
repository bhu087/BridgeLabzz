/////------------------------------------------------------------------------
////<copyright file="INotesManager.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace Manager.Notes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet.Actions;
    using Model.Account;

    /// <summary>
    /// Notes Manager
    /// </summary>
    public interface INotesManager
    {
        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>returns status</returns>
        Task<int> AddNotes(NotesModel notesModel);

        /// <summary>
        /// Deletes the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns status</returns>
        Task<int> DeleteNotes(int id);

        /// <summary>
        /// Deletes the trash.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns status</returns>
        Task<string> DeleteTrash(int id);

        /// <summary>
        /// Archives the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns status</returns>
        Task<int> ArchiveNotes(int id);

        /// <summary>
        /// Deletes the archived note.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns status</returns>
        Task<string> DeleteArchivedNote(int id);

        /// <summary>
        /// Sets the remainder.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="time">The time.</param>
        /// <returns>returns status</returns>
        Task<int> SetRemainder(int id, string time);

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>returns status</returns>
        Task<string> UpdateNotes(NotesModel notesModel);

        /// <summary>
        /// Deletes the remainder.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns status</returns>
        Task<int> DeleteRemainder(int id);

        /// <summary>
        /// Edits the title.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>returns status</returns>
        Task<string> EditTitle(NotesModel notesModel);

        /// <summary>
        /// Sets the color.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="color">The color.</param>
        /// <returns>returns status</returns>
        Task<string> SetColor(int id, string color);

        /// <summary>
        /// Gets all notes.
        /// </summary>
        /// <returns>returns status</returns>
        IEnumerable<NotesModel> GetAllNotes();

        /// <summary>
        /// Gets the notes by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns status</returns>
        Task<NotesModel> GetNotesById(int id);

        /// <summary>
        /// Uploads the image.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="imagePath">The image path.</param>
        /// <returns>returns status</returns>
        Task<ImageUploadResult> UploadImage(int id, string imagePath);

        /// <summary>
        /// Gives the all search results
        /// </summary>
        /// <param name="searchParameter">List of search results</param>
        /// <returns>returns status</returns>
        IQueryable<NotesModel> Search(string searchParameter);

        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="collaboratorEmail">The collaborator email.</param>
        /// <returns>returns status</returns>
        Task<string> AddCollaborator(int noteId, string collaboratorEmail);

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="receiverEmail">The receiver email.</param>
        /// <returns>returns status</returns>
        Task<string> DeleteCollaborator(int id, string receiverEmail);

        /// <summary>
        /// Sets the pin.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns status</returns>
        Task<string> SetPin(int id);

        /// <summary>
        /// Removes the pin.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns status</returns>
        Task<string> RemovePin(int id);
    }
}
