// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResetPasswordModel.cs" company="Bridgelabz">
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
    /// This is a model class of reset password
    /// </summary>
    public class ResetPasswordModel
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [Required(ErrorMessage = "* Mendatory Field", AllowEmptyStrings = false)]
        [EmailAddress]
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

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }
    }
}
