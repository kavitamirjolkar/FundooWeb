// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesBusinessManager.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooBusiness.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Common.Model;
    using FundooBusiness.Interfaces;
    using FundooRepository.Interfaces;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// This class is implementing an interface
    /// </summary>
    /// <seealso cref="FundooBusiness.Interfaces.INotesBusinessManager" />
    public class NotesBusinessManager : INotesBusinessManager
    {
        /// <summary>
        /// The notes repository
        /// </summary>
        private readonly INotesRepository notesRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesBusinessManager"/> class.
        /// </summary>
        /// <param name="notesRepository">The notes repository.</param>
        public NotesBusinessManager(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        /// <summary>
        /// Adds the notes asynchronous.
        /// </summary>
        /// <param name="notes">The notes.</param>
        /// <returns>
        /// returns int value
        /// </returns>
        public Task<int> AddNotesAsync(NotesModel notes)
        {
            this.notesRepository.Add(notes);
            var result = this.notesRepository.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns int value
        /// </returns>
        public Task<int> DeleteAsync(int id)
        {  
                var result = this.notesRepository.Remove(id);
                return result;           
        }
      
        /// <summary>
        /// Gets all notes asynchronous.
        /// </summary>
        /// <returns>
        /// returns list
        /// </returns>
        public IEnumerable<NotesModel> GetAllNotesAsync()
        {
            var list = new List<NotesModel>();
            var result = this.notesRepository.GetAllNotesAsync();
            foreach (var data in result)
            {
                list.Add(data);
            }

            return list;        
        }

        /// <summary>
        /// Gets the notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns list</returns>
        public IList<NotesModel> GetNotes(Guid userId)
        {
            return this.notesRepository.GetNotesAsync(userId);
        }

        /// <summary>
        /// Images the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns string value
        /// </returns>
        public string Image(IFormFile file, int id)
        {
            var result = this.notesRepository.Image(file, id);
            return result;
        }

        /// <summary>
        /// Reminders the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// returns list
        /// </returns>
        public IList<NotesModel> Reminder(Guid userId)
        {
            return this.notesRepository.Reminder(userId);
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns response
        /// </returns>
        public Task UpdateAsync(NotesModel model, int id)
        {
            this.notesRepository.UpdateNotes(model, id);
           var result = this.notesRepository.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Archives the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// returns list
        /// </returns>
        public IList<NotesModel> Archive(Guid userId)
        {
            return this.notesRepository.Archive(userId);
        }

        /// <summary>
        /// Adds the labels.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns>returns string</returns>
        public string AddLabels(LabelModel label)
        {
            var result = this.notesRepository.AddLabels(label);
            return result;
        }

        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns list</returns>
        public List<LabelModel> GetLabels(Guid userId)
        {
            return this.notesRepository.GetLabels(userId);
        }

        /// <summary>
        /// Updates the labels.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>returns string</returns>
        public string UpdateLabels(LabelModel label, int id)
        {
            return this.notesRepository.UpdateLabels(label, id);
        }

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns string</returns>
        public string DeleteLabel(int id)
        {
            return this.notesRepository.DeleteLabel(id);
        }

        /// <summary>
        /// Adds the notes label.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns string</returns>
        public string AddNotesLabel(NoteLabelModel model)
        {
            var result = this.notesRepository.AddNotesLabel(model);
            return result;
        }

        /// <summary>
        /// Gets the notes label.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns list</returns>
        public List<NoteLabelModel> GetNotesLabel(Guid userId)
        {
            return this.notesRepository.GetNotesLabel(userId);
        }

        /// <summary>
        /// Deletes the notes label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns string</returns>
        public string DeleteNotesLabel(int id)
        {
            return this.notesRepository.DeleteNotesLabel(id);
        }

        /// <summary>
        /// Adds the collaborator to note.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns string</returns>
        public string AddCollaboratorToNote(CollaboratorModel model)
        {
            var result = this.notesRepository.AddCollaboratorToNote(model);
            return result;
        }

        /// <summary>
        /// Removes the collaborator to note.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns string</returns>
        public string RemoveCollaboratorToNote(int id)
        {
            var result = this.notesRepository.RemoveCollaboratorToNote(id);
            return result;
        }

        /// <summary>
        /// Collaborators the note.
        /// </summary>
        /// <param name="receiverEmail">The receiver email.</param>
        /// <returns>returns string</returns>
        public string CollaboratorNote(string receiverEmail)
        {
            var result = this.notesRepository.CollaboratorNote(receiverEmail);
            return result;
        }
    }
}
