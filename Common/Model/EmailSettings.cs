using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
   public class EmailSettings
    {
        /// <summary>
        /// Gets or sets the mail server.
        /// </summary>
        /// <value>
        /// The mail server.
        /// </value>
        public string MailServer { get; set; }

        /// <summary>
        /// Gets or sets the mail port.
        /// </summary>
        /// <value>
        /// The mail port.
        /// </value>
        public int MailPort { get; set; }

        /// <summary>
        /// Gets or sets the name of the sender.
        /// </summary>
        /// <value>
        /// The name of the sender.
        /// </value>
        public string SenderName { get; set; }

        /// <summary>
        /// Gets or sets the sender.
        /// </summary>
        /// <value>
        /// The sender.
        /// </value>
        public string Sender { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable s s l ].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable s s l]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableSSL { get; set; }
    }
}
