// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesBusinessManager.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooBusiness.Interfaces
{   
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Common.Model;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// This is an interface
    /// </summary>
    public interface INotesBusinessManager
    {
        /// <summary>
        /// Adds the notes asynchronous.
        /// </summary>
        /// <param name="notes">The notes.</param>
        /// <returns>returns int value</returns>
        Task<int> AddNotesAsync(NotesModel notes);

        /// <summary>
        /// Gets all notes asynchronous.
        /// </summary>
        /// <returns>returns list</returns>
        IEnumerable<NotesModel> GetAllNotesAsync();

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns int value</returns>
        Task<int> DeleteAsync(int id);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>returns response</returns>
        Task UpdateAsync(NotesModel model, int id);

        /// <summary>
        /// Gets the notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns list</returns>
        IList<NotesModel> GetNotes(Guid userId);

        /// <summary>
        /// Images the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>returns string value</returns>
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

        /// <summary>
        /// Adds the labels.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns>returns string</returns>
        string AddLabels(LabelModel label);

        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns list of label</returns>
        List<LabelModel> GetLabels(Guid userId);

        /// <summary>
        /// Updates the labels.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>returns string</returns>
        string UpdateLabels(LabelModel label, int id);

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns string</returns>
        string DeleteLabel(int id);

        /// <summary>
        /// Adds the notes label.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns string</returns>
        string AddNotesLabel(NoteLabelModel model);

        /// <summary>
        /// Gets the notes label.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns list</returns>
        List<NoteLabelModel> GetNotesLabel(Guid userId);

        /// <summary>
        /// Deletes the notes label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns string</returns>
        string DeleteNotesLabel(int id);

        /// <summary>
        /// Adds the collaborator to note.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns string</returns>
        string AddCollaboratorToNote(CollaboratorModel model);

        /// <summary>
        /// Removes the collaborator to note.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns string</returns>
        string RemoveCollaboratorToNote(int id);

        /// <summary>
        /// Collaborators the note.
        /// </summary>
        /// <param name="receiverEmail">The receiver email.</param>
        /// <returns>returns string</returns>
        string CollaboratorNote(string receiverEmail);
    }
}
