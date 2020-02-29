using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Notes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Account;

namespace FundooAPIController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        INotesManager notesManager;
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
    }
}