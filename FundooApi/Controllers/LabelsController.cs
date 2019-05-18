namespace FundooApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using Common.Model;
    using FundooBusiness.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// this is controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class LabelsController : ControllerBase
    {
        /// <summary>
        /// The labels business
        /// </summary>
        private readonly ILabelsBusiness labelsBusiness;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelsController"/> class.
        /// </summary>
        /// <param name="labelsBusiness">The labels business.</param>
        public LabelsController(ILabelsBusiness labelsBusiness)
        {
            this.labelsBusiness = labelsBusiness;
        }

        /// <summary>
        /// Adds the labels.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns>returns response</returns>
        [HttpPost]
        [Route("label")]
        public IActionResult AddLabels(LabelModel label)
        {
            var result = this.labelsBusiness.AddLabels(label);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(new { result });
        }

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns response</returns>
        [HttpGet]
        [Route("label/{userId}")]
        public IActionResult GetLabel(Guid userId)
        {
            IList<LabelModel> result = this.labelsBusiness.GetLabels(userId);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(new { result });
        }

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newlabel">The newlabel.</param>
        /// <returns>returns response</returns>
        [HttpPut]
        [Route("label/{id}")]
        public IActionResult UpdateLabel(int id, string newlabel)
        {
            var result = this.labelsBusiness.UpdateLabels(id, newlabel);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(new { result });
        }

        /// <summary>
        /// Deletelabels the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns response</returns>
        [HttpDelete]
        [Route("label/{id}")]
        public IActionResult Deletelabel(int id)
        {
            var result = this.labelsBusiness.DeleteLabel(id);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(new { result });
        }
    }
}