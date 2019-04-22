// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesRepository.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Common.Model;
    using FundooRepository.DBContext;
    using FundooRepository.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    
    /// <summary>
    /// This class is implementing repository interface
    /// </summary>
    /// <seealso cref="FundooRepository.Interfaces.INotesRepository" />
    public class NotesRepository : INotesRepository 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public NotesRepository(AuthenticationContext context)
        {
            this.Context = context;
        }
        
        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public AuthenticationContext Context { get; }
       
        /// <summary>
        /// Adds the specified notes.
        /// </summary>
        /// <param name="notes">The notes.</param>
        public void Add(NotesModel notes)
        {
            NotesModel note = new NotesModel()
            {
                UserId = notes.UserId,      
                Title = notes.Title,
                Description = notes.Description
            };            
                var result = this.Context.Notes.Add(note);          
        }

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns response</returns>
        public Task<NotesModel> FindAsync(int id)
        {
            var result = this.Context.Notes.FindAsync(id);
            return result;
        }

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns response</returns>
        public async Task<int> Remove(int id)
        {
            var note = await this.Context.Notes.FindAsync(id);
            this.Context.Remove(note);
            var result = await this.Context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns>returns response</returns>
        public Task<int> SaveChangesAsync()
        {
            var result = this.Context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Gets all notes asynchronous.
        /// </summary>
        /// <returns>returns response</returns>
        public IEnumerable<NotesModel> GetAllNotesAsync()
        {
            var result = this.Context.Notes.ToList<NotesModel>();
            return result;
        }

        /// <summary>
        /// Gets the notes asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns response</returns>
        public IList<NotesModel> GetNotesAsync(Guid userId)
        {
            var list = new List<NotesModel>();
            var note = from notes in this.Context.Notes where notes.UserId == userId orderby notes.Id descending select notes;
            ////return Context.NotesModels.FirstOrDefault(e => e.UserId == UserId);
            foreach (var item in note)
            {
                list.Add(item);
            }

            return note.ToArray();
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        public void UpdateNotes([FromBody] NotesModel model, int id)
        {
            NotesModel notes = this.Context.Notes.Where<NotesModel>(t => t.Id == id).FirstOrDefault();
            notes.Title = model.Title;
            notes.Description = model.Description;
        }
    }
}
