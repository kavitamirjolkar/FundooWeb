namespace FundooRepository.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Model;
    using FundooRepository.DBContext;
    using FundooRepository.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// this is label repository
    /// </summary>
    /// <seealso cref="FundooRepository.Interfaces.ILabelsRepository" />
    public class LabelsRepository : ILabelsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LabelsRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public LabelsRepository(AuthenticationContext context)
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
        /// Adds the labels.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns>returns string</returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns string</returns>
        /// <exception cref="Exception"></exception>
        public string DeleteLabel(int id)
        {
            LabelModel label = this.Context.Labels.Where(t => t.Id == id).FirstOrDefault();
            try
            {
                this.Context.Labels.Remove(label);
                var result = this.Context.SaveChanges();
                return result.ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <returns>returns list</returns>
        /// <exception cref="Exception"></exception>
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
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// Updates the labels.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newlabel">The newlabel.</param>
        /// <returns>returns string</returns>
        /// <exception cref="Exception"></exception>
        public string UpdateLabels(int id, string newlabel)
        {
            LabelModel labels = this.Context.Labels.Where(t => t.Id == id).FirstOrDefault();
            labels.Label = newlabel;
            try
            {
                var result = this.Context.SaveChanges();
                return result.ToString();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }        
    }
}
