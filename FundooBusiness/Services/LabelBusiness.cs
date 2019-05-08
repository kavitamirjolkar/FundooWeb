namespace FundooBusiness.Services
{
    using System;
    using System.Collections.Generic;
    using Common.Model;
    using FundooBusiness.Interfaces;
    using FundooRepository.Interfaces;

    /// <summary>
    /// this is label business class
    /// </summary>
    /// <seealso cref="FundooBusiness.Interfaces.ILabelsBusiness" />
    public class LabelBusiness : ILabelsBusiness
    {
        /// <summary>
        /// The labels repository
        /// </summary>
        private readonly ILabelsRepository labelsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelBusiness"/> class.
        /// </summary>
        /// <param name="labelsRepository">The labels repository.</param>
        public LabelBusiness(ILabelsRepository labelsRepository)
        {
            this.labelsRepository = labelsRepository;
        }

        /// <summary>
        /// Adds the labels.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns>
        /// returns string
        /// </returns>
        public string AddLabels(LabelModel label)
        {
            var result = this.labelsRepository.AddLabels(label);
            return result;
        }

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns string
        /// </returns>
        public string DeleteLabel(int id)
        {
            return this.labelsRepository.DeleteLabel(id);
        }

        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <returns>
        /// returns string
        /// </returns>
        public List<LabelModel> GetLabels(Guid UserId)
        {
            return this.labelsRepository.GetLabels(UserId);
        }

        /// <summary>
        /// Updates the labels.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newlabel">The newlabel.</param>
        /// <returns>
        /// returns string
        /// </returns>
        public string UpdateLabels(int id, string newlabel)
        {
            return this.labelsRepository.UpdateLabels(id, newlabel);
        }
    }
}
