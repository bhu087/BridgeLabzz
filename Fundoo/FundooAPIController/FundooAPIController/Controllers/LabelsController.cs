using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Labels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Account;

namespace FundooAPIController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelsController : ControllerBase
    {
        public readonly ILabelManager labelManager;
        public LabelsController(ILabelManager labelManager)
        {
            this.labelManager = labelManager;
        }
        [HttpPost]
        [Route("addLabel")]
        public ActionResult AddLabel(LabelModel labelModel)
        {
            try
            {
                var result = this.labelManager.AddLabel(labelModel);
                if (result.Result.Equals("Saved"))
                {
                    return this.Ok("Saved");
                }
                return this.BadRequest("Not Saved");
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        [HttpDelete]
        [Route("deleteLabel")]
        public ActionResult DeleteLabel(int id)
        {
            try
            {
                var result = this.labelManager.DeleteLabel(id);
                if (result.Result.Equals("Deleted"))
                {
                    return this.Ok("Deleted");
                }
                return this.BadRequest("No Label Available");
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}