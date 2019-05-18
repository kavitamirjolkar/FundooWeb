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
    using Microsoft.AspNetCore.Http;
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
        [Route("notes/{id}")]
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
        [Route("notesbyId")]
        public IActionResult Get(Guid userId)
        {
            IList<NotesModel> notes = this.notesBusiness.GetNotes(userId);
            if (notes == null)
            {
                return this.NotFound("The note couldn't be found.");
            }

            return this.Ok(notes);
        }

        /// <summary>
        /// Images the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>returns response</returns>
        [HttpPost]
        [Route("image/{id}")]
        public IActionResult Image(IFormFile file, int id)
        {
            if (file == null)
            {
                return this.NotFound("The file couldn't be found");
            }

            var result = this.notesBusiness.Image(file, id);
            return this.Ok(new { result });
        }

        /// <summary>
        /// Reminders the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns response</returns>
        [HttpGet]
        [Route("reminder/{userId}")]
        public IActionResult Reminder(Guid userId)
        {
            IList<NotesModel> result = this.notesBusiness.Reminder(userId);
            if (result == null)
            {
                return this.NotFound("no reminder");
            }

            return this.Ok(new { result });
        }
        
        /// <summary>
        /// Reminders the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns response</returns>
        [HttpGet]
        [Route("archive/{userId}")]
        public IActionResult Archive(Guid userId)
        {
            IList<NotesModel> result = this.notesBusiness.Archive(userId);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(new { result });
        }

        /// <summary>
        /// Adds the labels.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns>returns result</returns>
        [HttpPost]
        [Route("label")]
        public IActionResult AddLabels(LabelModel label)
        {
            var result = this.notesBusiness.AddLabels(label);
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
        /// <returns>returns result</returns>
        [HttpGet]
        [Route("label/{userId}")]
        public IActionResult GetLabel(Guid userId)
        {
            IList<LabelModel> result = this.notesBusiness.GetLabels(userId);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(new { result });
        }

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>returns result</returns>
        [HttpPut]
        [Route("label/{id}")]
        public IActionResult UpdateLabel(LabelModel label, int id)
        {
            var result = this.notesBusiness.UpdateLabels(label, id);
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
        /// <returns>returns result</returns>
        [HttpDelete]
        [Route("label/{id}")]
        public IActionResult Deletelabel(int id)
        {
            var result = this.notesBusiness.DeleteLabel(id);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(new { result });
        }

        /// <summary>
        /// Adds the note label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns>returns result</returns>
        [HttpPost]
        [Route("notelabel")]
        public IActionResult AddNoteLabel(NoteLabelModel label)
        {
            var result = this.notesBusiness.AddNotesLabel(label);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(new { result });
        }

        /// <summary>
        /// Gets the note label.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns result</returns>
        [HttpGet]
        [Route("notelabel/{userId}")]
        public IActionResult GetNoteLabel(Guid userId)
        {
            IList<NoteLabelModel> result = this.notesBusiness.GetNotesLabel(userId);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(new { result });
        }

        /// <summary>
        /// Deletes the note label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns result</returns>
        [HttpDelete]
        [Route("notelabel/{id}")]
        public IActionResult DeleteNotelabel(int id)
        {
            var result = this.notesBusiness.DeleteNotesLabel(id);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(new { result });
        }

        /// <summary>
        /// Adds the collaborator to note.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns result</returns>
        [HttpPost]
        [Route("collaborator")]
       public IActionResult AddCollaboratorToNote(CollaboratorModel model)
       {
            var result = this.notesBusiness.AddCollaboratorToNote(model);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(new { result });
       }

        /// <summary>
        /// Removes the collaborator to note.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns result</returns>
        [HttpDelete]
        [Route("collaborator/{id}")]
        public IActionResult RemoveCollaboratorToNote(int id)
        {
            var result = this.notesBusiness.RemoveCollaboratorToNote(id);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(new { result });
        }

        /// <summary>
        /// Collaborators the note.
        /// </summary>
        /// <param name="receiverEmail">The receiver email.</param>
        /// <returns>returns result</returns>
        [HttpGet]
        [Route("collaborator/{receiverEmail}")]
        public IActionResult CollaboratorNote(string receiverEmail)
        {
            var result = this.notesBusiness.CollaboratorNote(receiverEmail);
            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(new { result });
        }
    }   
}