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
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Common.Model;
    using FundooRepository.DBContext;
    using FundooRepository.Interfaces;
    using Microsoft.AspNetCore.Http;
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
        /// <returns>
        /// returns response
        /// </returns>
        public string Add(NotesModel notes)
        {
            NotesModel note = new NotesModel()
            {
                UserId = notes.UserId,
                Title = notes.Title,
                Description = notes.Description,
                Reminder = notes.Reminder,
                IsArchive = notes.IsArchive,
                IsTrash = notes.IsTrash,
                IsPin=notes.IsPin,
                Color=notes.Color,                
            };
            var result = this.Context.Notes.Add(note);
            return null;
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
            notes.Reminder = model.Reminder;
            notes.Color = model.Color;
            notes.IsArchive = model.IsArchive;
            notes.IsTrash = model.IsTrash;
            notes.IsPin = model.IsPin;
        }

        /// <summary>
        /// Images the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>returns string value
        /// </returns>
        public string Image(IFormFile file, int id)
        {
            var stream = file.OpenReadStream();
            var name = file.FileName;
            CloudinaryDotNet.Account account = new CloudinaryDotNet.Account("dhnj4wxml", "754358186258935", "4l9_c_lMhktpvRSpORFDFYHAbKg");
            CloudinaryDotNet.Cloudinary cloudinary = new CloudinaryDotNet.Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(name, stream)
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            var data = this.Context.Notes.Where(t => t.Id == id).FirstOrDefault();
            data.Image = uploadResult.Uri.ToString();
            int result = 0;
            try
            {
                result = this.Context.SaveChanges();
                return data.Image;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Reminders the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns list</returns>
        public IList<NotesModel> Reminder(Guid userId)
        {
            var list = new List<NotesModel>();
            var notesData = from notes in this.Context.Notes where (notes.UserId == userId) && (notes.Reminder != null) select notes;
            foreach (var data in notesData)
            {
                list.Add(data);
            }

            return list;
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
            var list = new List<NotesModel>();
            var notesData = from notes in this.Context.Notes where (notes.UserId == userId) && (notes.IsArchive == true) && (notes.IsTrash == false) select notes;
            foreach (var data in notesData)
            {
                list.Add(data);
            }

            return list;
        }

       public string AddLabels([FromBody] LabelModel label)
       {
            var addLabel = new LabelModel()
            {
                UserId = label.UserId,
                Label = label.Label
            };
            try
            {
                this.Context.Labels.Add(addLabel);
               var result = this.Context.SaveChanges();
                return result.ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
       }

       public List<LabelModel> GetLabels(Guid UserId)
       {
            try
            {
                var list = new List<LabelModel>();
                var labels = from t in this.Context.Labels where t.UserId == UserId select t;
                foreach (var items in labels)
                {
                    list.Add(items);
                }

                return list;
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
       }

       public string UpdateLabels(int id, string newlabel)
       {
            LabelModel labels = Context.Labels.Where(t => t.Id == id).FirstOrDefault();
            labels.Label = newlabel;
            try
            {
               var result = this.Context.SaveChanges();
                return result.ToString();
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
       }

       public string DeleteLabel(int id)
       {
            LabelModel label = Context.Labels.Where(t => t.Id == id).FirstOrDefault();           
            try
            {
                this.Context.Labels.Remove(label);
               var result = Context.SaveChanges();
                return result.ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public string AddNotesLabel([FromBody] NoteLabelModel model)
        {
            try
            {
                var labelData = from t in Context.NoteLabel where t.UserId == model.UserId select t;
                foreach (var datas in labelData.ToList())
                {
                    if (datas.NoteId == model.NoteId && datas.LableId == model.LableId)
                    {
                        return false.ToString();
                    }
                }

                var data = new NoteLabelModel
                {
                    LableId = model.LableId,
                    NoteId = model.NoteId,
                    UserId = model.UserId
                };
                int result = 0;
                Context.NoteLabel.Add(data);
                result = Context.SaveChanges();
                return result.ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<NoteLabelModel> GetNotesLabel(Guid userId)
        {
            var list = new List<NoteLabelModel>();
            var Labeldata = from t in Context.NoteLabel where t.UserId == userId select t;
            try
            {
                foreach (var data in Labeldata)
                {
                    list.Add(data);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return list;
        }

        public string DeleteNotesLabel(int id)
        {
            var label = Context.NoteLabel.Where<NoteLabelModel>(t => t.Id == id).First();
            
            try
            {
                Context.NoteLabel.Remove(label);
               var result = Context.SaveChanges();
                return result.ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public string AddCollaboratorToNote([FromBody] CollaboratorModel model)
        {
            try
            {
                var data = from t in Context.Collaborator where t.UserId == model.UserId select t;
                foreach (var item in data.ToList())
                {
                    if (item.NoteId == model.NoteId && item.ReceiverEmail == model.ReceiverEmail)
                    {
                        return false.ToString();
                    }
                }
                var newdata = new CollaboratorModel()
                {
                    UserId = model.UserId,
                    NoteId = model.NoteId,
                    SenderEmail = model.SenderEmail,
                    ReceiverEmail = model.ReceiverEmail,

                };               
                Context.Collaborator.Add(newdata);
               var result = Context.SaveChanges();
                return result.ToString();
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public string RemoveCollaboratorToNote(int id)
        {
            try
            {
                var data = Context.Collaborator.Where<CollaboratorModel>(t => t.Id == id).FirstOrDefault();                
                Context.Collaborator.Remove(data);
               var result = Context.SaveChanges();
                return result.ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

       public string CollaboratorNote(string receiverEmail)
        {
            try
            {
                var collaboratorData = new List<NotesModel>();
                var sharednotes = new List<SharedNotes>();
                var data = from coll in this.Context.Collaborator
                           where coll.ReceiverEmail == receiverEmail
                           select new
                           {
                               coll.SenderEmail,
                               coll.NoteId
                           };
                foreach (var result in data)
                {
                    var collnotes = from notes in this.Context.Notes
                                    where notes.Id == result.NoteId
                                    select new SharedNotes
                                    {
                                        noteId = notes.Id,
                                        Title = notes.Title,
                                        TakeANote = notes.Description,

                                    };
                    foreach (var collaborator in collnotes)
                    {
                        sharednotes.Add(collaborator);
                    }
                }

                return sharednotes.ToString();
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}