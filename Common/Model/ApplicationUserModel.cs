// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationUserModel.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    /// <summary>
    /// This is Application user model
    /// </summary>
    public class ApplicationUserModel
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [Required(ErrorMessage = "* Mendatory Field", AllowEmptyStrings = false)]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [EmailAddress]
        [Required(ErrorMessage = "* Mendatory Field", AllowEmptyStrings = false)]
        [Display(Name = "Email Address: ")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required(ErrorMessage = "* Mendatory Field", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Password must contain minimum 6 characters")]
        [Display(Name = "Password: ")]
        public string Password { get; set; }
    }      
}
