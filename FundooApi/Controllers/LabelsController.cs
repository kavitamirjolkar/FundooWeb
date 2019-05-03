using System;
using System.Collections.Generic;
using Common.Model;
using FundooBusiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FundooApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelsController : ControllerBase
    {
        private readonly ILabelsBusiness labelsBusiness;
        public LabelsController(ILabelsBusiness labelsBusiness)
        {
            this.labelsBusiness = labelsBusiness;
        }

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

        [HttpPut]
        [Route("label/{id}")]
        public IActionResult UpdateLabel(int id, string newlabel)
        {
            var result = this.labelsBusiness.UpdateLabels(id, newlabel);
            if (result == null)
            {
                return this.NotFound();
            }

            return Ok(new { result });
        }

        [HttpDelete]
        [Route("label/{id}")]
        public IActionResult Deletelabel(int id)
        {
            var result = this.labelsBusiness.DeleteLabel(id);
            if (result == null)
            {
                return this.NotFound();
            }

            return Ok(new { result });
        }
    }
}