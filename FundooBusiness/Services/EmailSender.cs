// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailSender.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooBusiness.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Threading.Tasks;
    using Common.Model;
    using FundooBusiness.Interfaces;
    using Microsoft.Extensions.Options;
    
    /// <summary>
    /// this is Email sender class which is implementing an interface
    /// </summary>
    /// <seealso cref="FundooBusiness.Interfaces.IEmailSender" />
    public class EmailSender : IEmailSender
    {
        /// <summary>
        /// The emailSettings
        /// </summary>
        private readonly EmailSettings emailSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSender"/> class.
        /// </summary>
        /// <param name="emailSettings">The email settings.</param>
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            this.emailSettings = emailSettings.Value;
        }

        /// <summary>
        /// Sends the email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <returns>returns object</returns>
        /// <exception cref="InvalidOperationException">throws exception</exception>
        public Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var credentials = new NetworkCredential(this.emailSettings.Sender, this.emailSettings.Password);
                var mail = new MailMessage()
                {
                    From = new MailAddress(this.emailSettings.Sender, this.emailSettings.SenderName),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };
                mail.To.Add(new MailAddress(email));

                var client = new SmtpClient()
                {
                    Port = this.emailSettings.MailPort,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = this.emailSettings.MailServer,
                    EnableSsl = true,
                    Credentials = credentials
                };

                ////sending mail
                client.Send(mail);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(exception.Message);
            }

            return Task.CompletedTask;
        }
    }
}
