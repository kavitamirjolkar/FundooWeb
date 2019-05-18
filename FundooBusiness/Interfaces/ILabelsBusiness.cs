// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILabelsBusiness.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooBusiness.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Common.Model;

    /// <summary>
    /// Label interface
    /// </summary>
    public interface ILabelsBusiness
    {
        /// <summary>
        /// Adds the labels.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns>returns string </returns>
        string AddLabels(LabelModel label);

        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>returns string</returns>
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
