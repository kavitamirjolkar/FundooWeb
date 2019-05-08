namespace Common.Model
{
    using System;
   
    /// <summary>
    /// this is nodel label model
    /// </summary>
    public class NoteLabelModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the lable identifier.
        /// </summary>
        /// <value>
        /// The lable identifier.
        /// </value>
        public int LableId { get; set; }

        /// <summary>
        /// Gets or sets the note identifier.
        /// </summary>
        /// <value>
        /// The note identifier.
        /// </value>
        public int NoteId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }
    }
}
