// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApplicationUserContextRepository.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Interfaces
{
    using System.Threading.Tasks;
    using Common.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// this is an interface
    /// </summary>
    public interface IApplicationUserContextRepository
    {
        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="applicationUserModel">The application user model.</param>
        /// <returns>returns response</returns>
        Task CreateAsync(ApplicationUserModel applicationUserModel);

        /// <summary>
        /// Finds the by name asynchronous.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>returns response</returns>
        Task<ApplicationUserDBModel> FindByNameAsync(string userName);

        /// <summary>
        /// Checks the password asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="password">The password.</param>
        /// <returns>returns response</returns>
        Task<bool> CheckPasswordAsync(ApplicationUserModel model, string password);

        /// <summary>
        /// Finds the by email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>returns response</returns>
        Task<ApplicationUserDBModel> FindByEmailAsync(string email);

        /// <summary>
        /// Generates the password reset token asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns response</returns>
        Task<bool> GeneratePasswordResetTokenAsync(ForgotPasswordModel model);

        /// <summary>
        /// Resets the password asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns response</returns>
        Task<object> ResetPasswordAsync(ResetPasswordModel model);

        /// <summary>
        /// Logins the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns response</returns>
        Task<string> LoginAsync(LoginModel model);

        /// <summary>
        /// Faces the book login asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>returns response</returns>
        Task<string> FaceBookLoginAsync(string email);

        /// <summary>
        /// Profiles the picture.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="email">The email.</param>
        /// <returns>returns response</returns>
        string ProfilePicture(IFormFile file, string email);

        /// <summary>
        /// Profiles the URL.
        /// </summary>
        /// <param name="userid">The user id.</param>
        /// <returns>returns response</returns>
        Task<string> ProfileUrl(string userid);        
    }
}
