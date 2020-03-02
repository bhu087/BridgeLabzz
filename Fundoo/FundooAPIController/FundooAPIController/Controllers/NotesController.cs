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
    }
}