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
        [HttpPost]
        [Route("updateLabel")]
        public ActionResult UpdateLabel(int id, LabelModel labelModel)
        {
            try
            {
                var result = this.labelManager.UpdateLabel(id, labelModel);
                if (result.Result.Equals("Updated"))
                {
                    return this.Ok("Updated");
                }
                return this.BadRequest("Not Updated");
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
        [HttpGet]
        [Route("getAllLabels")]
        public ActionResult GetAllLabels()
        {
            try
            {
                var result = this.labelManager.GetAllLabels();
                if (result != null)
                {
                    return this.Ok(result.Result);
                }
                return this.BadRequest("Labels not Available");
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        [HttpGet]
        [Route("getByLabelId")]
        public ActionResult GetLabelById(int id)
        {
            try
            {
                var result = this.labelManager.GetLabelById(id);
                if (result != null)
                {
                    return this.Ok(result.Result);
                }
                return this.BadRequest("Labels not Available");
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}