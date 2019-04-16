// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEmailSender.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooBusiness.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is an interface to send an e-mail
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends the email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="htmlMessage">The HTML message.</param>
        /// <returns>returns response</returns>
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
