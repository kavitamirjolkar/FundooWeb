// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesController.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Common.Model;
    using FundooBusiness.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// this is notes controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// The notes business
        /// </summary>
        private readonly INotesBusinessManager notesBusiness;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="notesBusiness">The notes business.</param>
        public NotesController(INotesBusinessManager notesBusiness)
        {
            this.notesBusiness = notesBusiness;
        }

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>return response</returns>
        [HttpPost]
        [Route("note")]
        public async Task<IActionResult> Add(NotesModel model)
        {
            var result = await this.notesBusiness.AddNotesAsync(model);
            if (result == 1)
            {
                return this.Ok();
            }
            else
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns response</returns>
        [HttpDelete]
        [Route("note/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.notesBusiness.DeleteAsync(id);
            if (result == 1)
            {
                return this.Ok();
            }
            else
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Gets all notes.
        /// </summary>
        /// <returns>returns response</returns>
        [HttpGet]
        [Route("allnotes")]
      
        public IEnumerable<NotesModel> GetAllNotes()
        {
            return this.notesBusiness.GetAllNotesAsync();             
        }
      
        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>returns response</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateNotes(NotesModel model, int id)
        {
            try
            {
                await this.notesBusiness.UpdateAsync(model, id);
                return this.Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Gets the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns response</returns>
        [HttpGet]       
        public IActionResult Get(Guid userId)
        {
            IList<NotesModel> notes = this.notesBusiness.GetNotes(userId);
            if (notes == null)
            {
                return this.NotFound("The note couldn't be found.");
            }

            return this.Ok(notes);
        }
    }   
}
