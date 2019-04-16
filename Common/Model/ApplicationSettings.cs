// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationSettings.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    /// <summary>
    /// this is model class of app settings
    /// </summary>
    public class ApplicationSettings
    {
        /// <summary>
        /// Gets or sets the JWT secret.
        /// </summary>
        /// <value>
        /// The JWT secret.
        /// </value>
        public string JWT_Secret { get; set; }

        /// <summary>
        /// Gets or sets the client URL.
        /// </summary>
        /// <value>
        /// The client URL.
        /// </value>
        public string Client_URL { get; set; }
    }
}
