/////------------------------------------------------------------------------
////<copyright file="LabelsController.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace FundooAPIController.Controllers
{
    using System;
    using Manager.Labels;
    using Microsoft.AspNetCore.Mvc;
    using Model.Account;

    /// <summary>
    /// this is the labels controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class LabelsController : ControllerBase
    {
        /// <summary>
        /// The label manager
        /// </summary>
        public readonly ILabelManager labelManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelsController"/> class.
        /// </summary>
        /// <param name="labelManager">The label manager.</param>
        public LabelsController(ILabelManager labelManager)
        {
            this.labelManager = labelManager;
        }

        /// <summary>
        /// Adds the label.
        /// it expect LabelId(NoteId), Label Name
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>result for Add Label</returns>
        /// <exception cref="System.Exception">Throw Exception</exception>
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

                return this.BadRequest(result.Result);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Updates the label.
        /// it expect Id of Label(NoteId), Label name, and New label Name in label Model.
        /// its working like a move from one label to other, even if label not available
        /// it creates a new label with respect to user new Label entry.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="labelModel">The label model.</param>
        /// <returns>result for update</returns>
        /// <exception cref="System.Exception">Throw Exception</exception>
        [HttpPut]
        [Route("updateLabel")]
        public ActionResult UpdateLabel(int id, string labelName, LabelModel labelModel)
        {
            try
            {
                var result = this.labelManager.UpdateLabel(id, labelName, labelModel);
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

        /// <summary>
        /// Deletes the label.
        /// it expect label name to delete, and it delete all the entries in the name of label Name.
        /// </summary>
        /// <param name="labelName">Name of the label.</param>
        /// <returns>result for Delete label</returns>
        /// <exception cref="System.Exception">Throw Exception</exception>
        [HttpDelete]
        [Route("deleteLabel")]
        public ActionResult DeleteLabel(string labelName)
        {
            try
            {
                var result = this.labelManager.DeleteLabel(labelName);
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

        /// <summary>
        /// Deletes the note from label.
        /// it expect label Id.
        /// </summary>
        /// <param name="labelId">The label identifier.</param>
        /// <returns>result for delete single note from label</returns>
        /// <exception cref="System.Exception">Throw Exception</exception>
        [HttpDelete]
        [Route("deleteNoteFromLabel")]
        public ActionResult DeleteNoteFromLabel(int labelId)
        {
            try
            {
                var result = this.labelManager.DeleteNoteFromLabel(labelId);
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

        /// <summary>
        /// Gets all labels.
        /// </summary>
        /// <returns>result for all labels</returns>
        /// <exception cref="System.Exception">Throw Exception</exception>
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

        /// <summary>
        /// Gets the label by identifier.
        /// it expect label id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>result for single ID</returns>
        /// <exception cref="System.Exception">Throw Exception</exception>
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

        /// <summary>
        /// Renames the label.
        /// </summary>
        /// <param name="currentLabelName">Name of the current label.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// /// <returns>result rename Label</returns>
        /// <exception cref="System.Exception">Throw Exception</exception>
        [HttpPut]
        [Route("renameLabel")]
        public ActionResult RenameLabel(string currentLabelName, string newLabelName)
        {
            try
            {
                var result = this.labelManager.RenameLabel(currentLabelName, newLabelName);
                if (result.Result != 0)
                {
                    return this.Ok("Renamed");
                }

                return this.BadRequest("Not Renamed/Check user ID");
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}