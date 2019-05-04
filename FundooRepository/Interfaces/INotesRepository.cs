// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesRepository.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Common.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This is an interface
    /// </summary>
    public interface INotesRepository
    {
        /// <summary>
        /// Adds the specified notes.
        /// </summary>
        /// <param name="notes">The notes.</param>
        /// <returns>returns response</returns>
        string Add(NotesModel notes);

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns>return response</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>return response</returns>
        Task<int> Remove(int id);

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>return response</returns>
        Task<NotesModel> FindAsync(int id);

        /// <summary>
        /// Gets all notes asynchronous.
        /// </summary>
        /// <returns>return response</returns>
        IEnumerable<NotesModel> GetAllNotesAsync();

        /// <summary>
        /// Gets the notes asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>return response</returns>
        IList<NotesModel> GetNotesAsync(Guid userId);

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        void UpdateNotes([FromBody]NotesModel model, int id);

        /// <summary>
        /// Images the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>returns url</returns>
        string Image(IFormFile file, int id);

        /// <summary>
        /// Reminders the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns list</returns>
        IList<NotesModel> Reminder(Guid userId);

        /// <summary>
        /// Archives the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns list</returns>
        IList<NotesModel> Archive(Guid userId);

        string AddLabels([FromBody] LabelModel label);

        List<LabelModel> GetLabels(Guid UserId);
        string UpdateLabels([FromBody] LabelModel label, int id);
        string DeleteLabel(int id);

        string AddNotesLabel([FromBody]NoteLabelModel model);
        List<NoteLabelModel> GetNotesLabel(Guid userId);
        string DeleteNotesLabel(int id);
        string AddCollaboratorToNote([FromBody]CollaboratorModel model);
        string RemoveCollaboratorToNote(int id);
        string CollaboratorNote(string receiverEmail);
    }
}
