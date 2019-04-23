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

        ///// <summary>
        ///// Finds the by name asynchronous.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns>returns response</returns>
        //Task<ApplicationUserDBModel> FindByNameAsync(string userName);

        ///// <summary>
        ///// Checks the password asynchronous.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns>returns response</returns>
        //Task<bool> CheckPasswordAsync(LoginModel model, string password);

        /// <summary>
        /// Finds the by email asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns response</returns>
        Task FindByEmailAsync(ForgotPasswordModel model);

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

        Task<string> LoginAsync(LoginModel model);
    }
}
