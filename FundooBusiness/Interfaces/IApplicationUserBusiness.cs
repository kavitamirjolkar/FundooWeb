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
    }
}
