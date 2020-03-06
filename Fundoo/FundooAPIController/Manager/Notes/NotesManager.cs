/////------------------------------------------------------------------------
////<copyright file="NotesManager.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace Manager.Notes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet.Actions;
    using Model.Account;
    using Repository.IRepo;

    /// <summary>
    /// This is the Notes Manager
    /// </summary>
    /// <seealso cref="Manager.Notes.INotesManager" />
    public class NotesManager : INotesManager
    {
        /// <summary>
        /// The notes repo
        /// </summary>
        public readonly INotesRepo notesRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesManager"/> class.
        /// </summary>
        /// <param name="notesRepo">The notes repo.</param>
        public NotesManager(INotesRepo notesRepo)
        {
            this.notesRepo = notesRepo;
        }

        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<int> AddNotes(NotesModel notesModel)
        {
            try
            {
                return this.notesRepo.AddNotes(notesModel);
            }
            catch (Exception)
            {
                throw new Exception();
            } 
        }

        /// <summary>
        /// Deletes the trash.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<string> DeleteTrash(int id)
        {
            try
            {
                return this.notesRepo.DeleteTrash(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Deletes the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<int> DeleteNotes(int id)
        {
            try
            {
                return this.notesRepo.DeleteNotes(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Archives the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<int> ArchiveNotes(int id)
        {
            try
            {
                return this.notesRepo.ArchiveNotes(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Deletes the archived note.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<string> DeleteArchivedNote(int id)
        {
            try
            {
                return this.notesRepo.DeleteArchivedNote(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Sets the remainder.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="time">The time.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<int> SetRemainder(int id, string time)
        {
            try
            {
                return this.notesRepo.SetRemainder(id, time);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<string> UpdateNotes(NotesModel notesModel)
        {
            try
            {
                return this.notesRepo.UpdateNotes(notesModel);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Deletes the remainder.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<int> DeleteRemainder(int id)
        {
            try
            {
                return this.notesRepo.DeleteRemainder(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Edits the title.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<string> EditTitle(NotesModel notesModel)
        {
            try
            {
                return this.notesRepo.EditTitle(notesModel);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Sets the color.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="color">The color.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<string> SetColor(int id, string color)
        {
            try
            {
                return this.notesRepo.SetColor(id, color);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets all notes.
        /// </summary>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public IEnumerable<NotesModel> GetAllNotes()
        {
            try
            {
                return this.notesRepo.GetAllNotes();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets the notes by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<NotesModel> GetNotesById(int id)
        {
            try
            {
                return this.notesRepo.GetNotesById(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Uploads the image.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="imagePath">The image path.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<ImageUploadResult> UploadImage(int id, string imagePath)
        {
            try
            {
                return this.notesRepo.UploadImage(id, imagePath);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gives the all search results
        /// </summary>
        /// <param name="searchParameter">List of search results</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public IQueryable<NotesModel> Search(string searchParameter)
        {
            try
            {
                return this.notesRepo.Search(searchParameter);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        /// <param name="collaboratorEmail">The collaborator email.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<string> AddCollaborator(int noteId, string collaboratorEmail)
        {
            try
            {
                return this.notesRepo.AddCollaborator(noteId, collaboratorEmail);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="receiverEmail">The receiver email.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<string> DeleteCollaborator(int id, string receiverEmail)
        {
            try
            {
                return this.notesRepo.DeleteCollaborator(id, receiverEmail);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Sets the pin.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<string> SetPin(int id)
        {
            try
            {
                return this.notesRepo.SetPin(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Removes the pin.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns status
        /// </returns>
        /// <exception cref="Exception">Throw exception</exception>
        public Task<string> RemovePin(int id)
        {
            try
            {
                return this.notesRepo.RemovePin(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
