using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Manager.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Model.Account;
using Manager.Notes;
using static System.Net.Mime.MediaTypeNames;

namespace FundooAPIController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        public readonly INotesManager notesManager;
        public NotesController(INotesManager notesManager)
        {
            this.notesManager = notesManager;
        }
        [HttpPost]
        [Route("addNote")]
        public ActionResult AddNotes(NotesModel notesModel)
        {
            try
            {
                var result = this.notesManager.AddNotes(notesModel);
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
        [HttpPost]
        [Route("delete")]
        public ActionResult DeleteNotes(int id)
        {
            try
            {
                var result = this.notesManager.DeleteNotes(id);
                if (result != null)
                {
                    return this.Ok("Notes is Archieved");
                }
                return this.BadRequest("Notes Not found");
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }
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
        [HttpPost]
        [Route("archieve")]
        public ActionResult ArchieveNotes(int id)
        {
            try
            {
                var result = this.notesManager.ArchieveNotes(id);
                if (result != null)
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
        [HttpDelete]
        [Route("deleteArchieve")]
        public ActionResult DeleteArchievedNote(int id)
        {
            try
            {
                var result = this.notesManager.DeleteArchievedNote(id);
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
        [HttpPost]
        [Route("setRemainder")]
        public ActionResult SetRemainder(int id, string time)
        {
            try
            {
                var result = this.notesManager.SetRemainder(id, time);
                if (result != null)
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
        [HttpPost]
        [Route("deleteRemainder")]
        public ActionResult DeleteRemainder(int id)
        {
            try
            {
                var result = this.notesManager.DeleteRemainder(id);
                if (result != null)
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
        //public static string GetBase64StringForImage(string imgPath)
        //{
        //    byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
        //    string base64String = Convert.ToBase64String(imageBytes);
        //    return base64String;
        //}
        //[HttpPost]
        //[Route("uploadImage")]
        //public ActionResult UploadImage(int id)
        //{
        //    string path = @"D:\Abc\Fundu.png";
        //    string image = GetBase64StringForImage(path);
        //    var result = this.notesManager.SaveImage(id, image);
        //    try
        //    {
        //        if (result != null)
        //        {
        //            return this.Ok(result);
        //        }
        //        return this.BadRequest("Notes Not Available");
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception();
        //    }
        //}
        //[HttpGet]
        //[Route("DownloadImage")]
        //public ActionResult DownlaodImage(int id)
        //{
        //    var result = this.notesManager.DownloadImage(id);
        //    try
        //    {
        //        if (result != null)
        //        {
        //            return this.Ok(result.Result);
        //        }
        //        return this.BadRequest("Notes Not Available");
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception();
        //    }
        //}
        [HttpPost]
        [Route("uploadImage")]
        public ActionResult UploadImage(int id, string imagePath)
        {
            var result = this.notesManager.UploadImage(id, imagePath);
            if (result != null)
            {
                return this.Ok(result);
            }
            return this.BadRequest("Not Uploaded");
        }
        [HttpGet]
        [Route("getAllNotes")]
        public ActionResult GetAllNotes()
        {
            var result = this.notesManager.GetAllNotes();
            try
            {
                if(result != null)
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
    }
}