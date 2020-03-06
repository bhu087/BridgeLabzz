/////------------------------------------------------------------------------
////<copyright file="NotesController.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace FundooAPIController.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Manager.Notes;
    using Microsoft.AspNetCore.Mvc;
    using Model.Account;

    /// <summary>
    /// This is the Notes Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// The notes manager
        /// </summary>
        public readonly INotesManager notesManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="notesManager">The notes manager.</param>
        public NotesController(INotesManager notesManager)
        {
            this.notesManager = notesManager;
        }

        /// <summary>
        /// Adds the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>Add Note result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpPost]
        [Route("addNote")]
        public ActionResult AddNotes(NotesModel notesModel)
        {
            try
            {
                var result = this.notesManager.AddNotes(notesModel);
                if (result.Result != 0)
                {
                    return this.Ok(result);
                }

                return this.BadRequest("Email already Exist");                
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
        /// <returns>Upload Note Result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpPost]
        [Route("updateNote")]
        public ActionResult UpdateNotes(NotesModel notesModel)
        {
            try
            {
                var result = this.notesManager.UpdateNotes(notesModel);
                if (result != null)
                {
                    return this.Ok(result);
                }

                return this.BadRequest("Something wrong");
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
        /// <returns>Edit Tile Result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpPost]
        [Route("EditTitle")]
        public ActionResult EditTitle(NotesModel notesModel)
        {
            try
            {
                var result = this.notesManager.EditTitle(notesModel);
                if (result != null)
                {
                    return this.Ok(result);
                }

                return this.BadRequest("Something wrong");
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
        /// <returns>Delete note result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpPost]
        [Route("delete")]
        public ActionResult DeleteNotes(int id)
        {
            try
            {
                var result = this.notesManager.DeleteNotes(id);
                if (result != null)
                {
                    return this.Ok("Notes moved to trash");
                }

                return this.BadRequest("Notes Not found");
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
        /// <returns>Delete from trash result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpDelete]
        [Route("deleteTrash")]
        public ActionResult DeleteTrash(int id)
        {
            try
            {
                var result = this.notesManager.DeleteTrash(id);
                Debug.WriteLine(result.Result);
                if (result.Result.Equals("Deleted from Trash"))
                {
                    return this.Ok("Notes Deleted from Trash");
                }

                return this.BadRequest("Notes Not Available in Trash");
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
        /// <returns>Archive note result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpPost]
        [Route("archive")]
        public ActionResult ArchiveNotes(int id)
        {
            try
            {
                var result = this.notesManager.ArchiveNotes(id);
                if (result.Result != 0)
                {
                    return this.Ok("Notes is Archieved");
                }

                return this.BadRequest("Notes Not found");
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
        /// <returns>Delete archive result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpDelete]
        [Route("deleteArchive")]
        public ActionResult DeleteArchivedNote(int id)
        {
            try
            {
                var result = this.notesManager.DeleteArchivedNote(id);
                Debug.WriteLine(result.Result);
                if (result.Result.Equals("Deleted"))
                {
                    return this.Ok("Archieved Notes Deleted");
                }

                return this.BadRequest("Notes Not Available in Archieve");
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
        /// <returns>Set remainder result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpPost]
        [Route("setRemainder")]
        public ActionResult SetRemainder(int id, string time)
        {
            try
            {
                var result = this.notesManager.SetRemainder(id, time);
                if (result.Result != 0)
                {
                    return this.Ok("Remainder SET");
                }

                return this.BadRequest("Notes Not found");
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Resets the remainder.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="time">The time.</param>
        /// <returns>Reset remainder result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpPost]
        [Route("resetRemainder")]
        public ActionResult ResetRemainder(int id, string time)
        {
            try
            {
                return this.SetRemainder(id, time);
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
        /// <returns>Delete remainder Result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpPost]
        [Route("deleteRemainder")]
        public ActionResult DeleteRemainder(int id)
        {
            try
            {
                var result = this.notesManager.DeleteRemainder(id);
                if (result.Result != 0)
                {
                    return this.Ok("Remainder Deleted");
                }

                return this.BadRequest("Notes Not found");
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
        /// <returns>Set color result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpPost]
        [Route("setColor")]
        public ActionResult SetColor(int id, string color)
        {
            try
            {
                var result = this.notesManager.SetColor(id, color);
                if (result != null)
                {
                    return this.Ok("Color Changed");
                }

                return this.BadRequest("Notes Not found");
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
        /// <returns>Set pin result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpPost]
        [Route("setPin")]
        public ActionResult SetPin(int id)
        {
            try
            {
                var result = this.notesManager.SetPin(id);
                if (result.Result.Equals("Pinned"))
                {
                    return this.Ok(result.Result);
                }

                return this.BadRequest(result.Result);
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
        /// <returns>Remove pin result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpPost]
        [Route("removePin")]
        public ActionResult RemovePin(int id)
        {
            try
            {
                var result = this.notesManager.RemovePin(id);
                if (result.Result.Equals("UnPinned"))
                {
                    return this.Ok(result.Result);
                }

                return this.BadRequest(result.Result);
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
        /// <returns>upload image result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpPost]
        [Route("uploadImage")]
        public ActionResult UploadImage(int id, string imagePath)
        {
            try
            {
                var result = this.notesManager.UploadImage(id, imagePath);
                if (result != null)
                {
                    return this.Ok(result);
                }

                return this.BadRequest("Not Uploaded");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets all notes.
        /// </summary>
        /// <returns>get all notes</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpGet]
        [Route("getAllNotes")]
        public ActionResult GetAllNotes()
        {
            var result = this.notesManager.GetAllNotes();
            try
            {
                if (result != null)
                {
                    return this.Ok(result.ToArray());
                }

                return this.BadRequest("Notes Not Available");
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
        /// <returns>get note by id</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpGet]
        [Route("getNotesById")]
        public ActionResult GetNotesById(int id)
        {
            var result = this.notesManager.GetNotesById(id);
            try
            {
                if (result != null)
                {
                    return this.Ok(result.Result);
                }

                return this.BadRequest("Notes Not Available");
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Searches the specified search parameter.
        /// </summary>
        /// <param name="searchParameter">The search parameter.</param>
        /// <returns>search result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpGet]
        [Route("search")]
        public ActionResult Search(string searchParameter)
        {
            var result = this.notesManager.Search(searchParameter);
            try
            {
                if (result.Count() > 0)
                {
                    return this.Ok(result);
                }

                return this.BadRequest("No search results are Available");
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
        /// <returns>add collaborator result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpPost]
        [Route("addCollaborator")]
        public ActionResult AddCollaborator(int noteId, string collaboratorEmail)
        {
            var result = this.notesManager.AddCollaborator(noteId, collaboratorEmail);
            try
            {
                if (!result.Result.Equals("Id Not available"))
                {
                    return this.Ok(result.Result);
                }

                return this.BadRequest("Id Not available");
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
        /// <returns>Delete collaborator result</returns>
        /// <exception cref="Exception">Throw exception</exception>
        [HttpDelete]
        [Route("deleteCollaborator")]
        public ActionResult DeleteCollaborator(int id, string receiverEmail)
        {
            try
            {
                var result = this.notesManager.DeleteCollaborator(id, receiverEmail);
                if (result.Result.Equals("Deleted"))
                {
                    return this.Ok("Collaborator Deleted");
                }

                return this.BadRequest("Collaborator Not Available in this id");
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}