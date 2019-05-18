// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApplicationUserBusiness.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooBusiness.Interfaces
{
    using System.Threading.Tasks;
    using Common.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// This is an interface
    /// </summary>
    public interface IApplicationUserBusiness
    {
        /// <summary>
        /// Registrations the asynchronous.
        /// </summary>
        /// <param name="applicationUserModel">The application user model.</param>
        /// <returns>returns bool value</returns>
        Task<bool> RegistrationAsync(ApplicationUserModel applicationUserModel);

        /// <summary>
        /// Logins the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns string</returns>
        Task<string> LoginAsync(LoginModel model);

        /// <summary>
        /// Faces the book login asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>returns response</returns>
        Task<string> FaceBookLoginAsync(string email);

        /// <summary>
        /// Forgot the password asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns bool value</returns>
        bool ForgotPasswordAsync(ForgotPasswordModel model);

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns bool value</returns>
        bool ResetPassword(ResetPasswordModel model);

        /// <summary>
        /// Profiles the picture.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="email">The email.</param>
        /// <returns>returns response</returns>
        string ProfilePicture(IFormFile file, string email);

        /// <summary>
        /// Finds the name of the by.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>returns response</returns>
        Task<ApplicationUserDBModel> FindByName(string userName);

        /// <summary>
        /// Profiles the URL.
        /// </summary>
        /// <param name="userid">The user id.</param>
        /// <returns>returns response</returns>
        Task<string> ProfileUrl(string userid);
    }
}
