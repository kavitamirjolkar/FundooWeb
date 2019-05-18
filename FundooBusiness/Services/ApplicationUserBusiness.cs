// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationUserBusiness.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooBusiness.Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Common.Model;
    using FundooBusiness.Interfaces;
    using FundooRepository.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using IEmailSender = Interfaces.IEmailSender;

    /// <summary>
    /// this class is implementing an interface
    /// </summary>
    /// <seealso cref="FundooBusiness.Interfaces.IApplicationUserBusiness" />
    public class ApplicationUserBusiness : IApplicationUserBusiness
    {     
        /// <summary>
        /// The application user context
        /// </summary>
        private readonly IApplicationUserContextRepository applicationUserContext;

        /// <summary>
        /// The email sender
        /// </summary>
        private readonly IEmailSender emailSender;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserBusiness"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="emailSender">The email sender.</param>
        public ApplicationUserBusiness(IApplicationUserContextRepository context, IEmailSender emailSender)
        {
            this.applicationUserContext = context;          
            this.emailSender = emailSender;
        }

        /// <summary>
        /// Finds the name of the by.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>
        /// returns response
        /// </returns>
        public Task<ApplicationUserDBModel> FindByName(string userName)
        {
            var result = this.applicationUserContext.FindByNameAsync(userName);
            return result;
        }

        /// <summary>
        /// Forgot the password asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// returns bool value
        /// </returns>
        public bool ForgotPasswordAsync(ForgotPasswordModel model)
        {
            var result = this.applicationUserContext.FindByEmailAsync(model.Email);
            if (result != null)
            {
                var token = this.applicationUserContext.GeneratePasswordResetTokenAsync(model);
                var callbackUrl = "http://localhost:4200/user/resetpassword";
                this.emailSender.SendEmailAsync(model.Email, "Reset Password", $"Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">here</a>");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Logins the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// returns string
        /// </returns>
        public Task<string> LoginAsync(LoginModel model)
        {
           var result = this.applicationUserContext.LoginAsync(model);
            return result;
        }

        /// <summary>
        /// Faces the book login asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// returns response
        /// </returns>
        public Task<string> FaceBookLoginAsync(string email)
        {
            var result = this.applicationUserContext.FaceBookLoginAsync(email);
            return result;
        }

        /// <summary>
        /// Profiles the picture.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="email">The email.</param>
        /// <returns>
        /// returns response
        /// </returns>
        public string ProfilePicture(IFormFile file, string email)
        {
           var result = this.applicationUserContext.ProfilePicture(file, email);
            return result;
        }

        /// <summary>
        /// Profiles the URL.
        /// </summary>
        /// <param name="userid">The user id.</param>
        /// <returns>
        /// returns response
        /// </returns>
        public Task<string> ProfileUrl(string userid)
        {
            var result = this.applicationUserContext.ProfileUrl(userid);
            return result;
        }

        /// <summary>
        /// Registrations the asynchronous.
        /// </summary>
        /// <param name="applicationUserModel">The application user model.</param>
        /// <returns>
        /// returns bool value
        /// </returns>
        public async Task<bool> RegistrationAsync(ApplicationUserModel applicationUserModel)
        {
            await this.applicationUserContext.CreateAsync(applicationUserModel);
            return true;
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// returns bool value
        /// </returns>
        public bool ResetPassword(ResetPasswordModel model)
        {
            this.applicationUserContext.ResetPasswordAsync(model);
            return true;
        }

        ///// <summary>
        ///// Generates the json web token.
        ///// </summary>
        ///// <returns>returns string</returns>
        ////private string GenerateJSONWebToken()
        ////{
        ////    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.appSettings.JWT_Secret));
        ////    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        ////    var token = new JwtSecurityToken("localhost", "localhost", null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

        ////    return new JwtSecurityTokenHandler().WriteToken(token);
        ////}
    }
}