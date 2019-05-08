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
        /// <param name="UserId">The user identifier.</param>
        /// <returns>returns string</returns>
        List<LabelModel> GetLabels(Guid UserId);

        /// <summary>
        /// Updates the labels.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="newlabel">The newlabel.</param>
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
