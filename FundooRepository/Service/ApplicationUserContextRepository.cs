// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationUserContextRepository.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository
{
    using System.Threading.Tasks;
    using Common.Model;
    using FundooRepository.Interfaces;
    using Microsoft.AspNetCore.Identity;
 
    /// <summary>
    /// This class is implementing repository interface
    /// </summary>
    /// <seealso cref="FundooRepository.Interfaces.IApplicationUserContextRepository" />
    public class ApplicationUserContextRepository : IApplicationUserContextRepository
    {
        /// <summary>
        /// The user manager
        /// </summary>
        private UserManager<ApplicationUserDBModel> usermanager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserContextRepository"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        public ApplicationUserContextRepository(UserManager<ApplicationUserDBModel> userManager)
        {
            this.usermanager = userManager;           
        }

        /// <summary>
        /// Checks the password asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns response</returns>
        public async Task<bool> CheckPasswordAsync(LoginModel model)
        {          
            var result = await this.usermanager.FindByNameAsync(model.UserName);
            var user = await this.usermanager.CheckPasswordAsync(result, model.Password);
                return user;
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="applicationUserModel">The application user model.</param>
        /// <returns>returns response</returns>
        public Task CreateAsync(ApplicationUserModel applicationUserModel)
        {         
            ApplicationUserDBModel user = new ApplicationUserDBModel()
            {
                UserName = applicationUserModel.UserName,
                FirstName = applicationUserModel.FirstName,
                LastName = applicationUserModel.LastName,
                Email = applicationUserModel.Email,
            };
            var result  = this.usermanager.CreateAsync(user, applicationUserModel.Password);
            return result;
        }

        /// <summary>
        /// Finds the by email asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns response</returns>
        public Task FindByEmailAsync(ForgotPasswordModel model)
        {
            var result = this.usermanager.FindByEmailAsync(model.Email);
            return result;
        }

        /// <summary>
        /// Finds the by name asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns response</returns>
        public Task FindByNameAsync(LoginModel model)
        {
            var result = this.usermanager.FindByNameAsync(model.UserName);
            return result;
        }

        /// <summary>
        /// Generates the password reset token asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns response</returns>
        public async Task<bool> GeneratePasswordResetTokenAsync(ForgotPasswordModel model)
        {
            var result = await this.usermanager.FindByEmailAsync(model.Email);
            var user = await this.usermanager.GenerateEmailConfirmationTokenAsync(result);            
            return true;
        }

        /// <summary>
        /// Resets the password asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns response</returns>
        public async Task<object> ResetPasswordAsync(ResetPasswordModel model)
        {
            var userEmail = await this.usermanager.FindByEmailAsync(model.Email);
            var token = await this.usermanager.GeneratePasswordResetTokenAsync(userEmail);
            var result = await this.usermanager.ResetPasswordAsync(userEmail, token, model.Password);
            return result;
        }
    }
}
