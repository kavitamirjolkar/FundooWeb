namespace FundooRepository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Common.Model;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// this is label interface
    /// </summary>
    public interface ILabelsRepository
    {
        /// <summary>
        /// Adds the labels.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns>returns string</returns>
        string AddLabels([FromBody] LabelModel label);

        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns list</returns>
        List<LabelModel> GetLabels(Guid userId);

        /// <summary>
        /// Updates the labels.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newlabel">The new label.</param>
        /// <returns>returns string</returns>
        string UpdateLabels(int id, string newlabel);

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>returns string</returns>
        string DeleteLabel(int id);
    }
}
