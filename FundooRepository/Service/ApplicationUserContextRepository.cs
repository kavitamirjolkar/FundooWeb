// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationUserContextRepository.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Common.Model;
    using FundooRepository.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// This class is implementing repository interface
    /// </summary>
    /// <seealso cref="FundooRepository.Interfaces.IApplicationUserContextRepository" />
    public class ApplicationUserContextRepository : IApplicationUserContextRepository
    {
        /// <summary>
        /// The application settings
        /// </summary>
        private readonly ApplicationSettings appSettings;
        
        /// <summary>
        /// The user manager
        /// </summary>
        private UserManager<ApplicationUserDBModel> usermanager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserContextRepository"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        public ApplicationUserContextRepository(UserManager<ApplicationUserDBModel> userManager, IOptions<ApplicationSettings> appSettings)
        {
            this.usermanager = userManager;
            this.appSettings = appSettings.Value;
        }

        ///// <summary>
        ///// Checks the password asynchronous.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns>returns response</returns>
        //public async Task<bool> CheckPasswordAsync(LoginModel model,string password)
        //{          
        //    var result = await this.usermanager.FindByNameAsync(model.UserName);
        //    var user = await this.usermanager.CheckPasswordAsync(result, model.Password);
        //        return user;
        //}

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

        ///// <summary>
        ///// Finds the by name asynchronous.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns>returns response</returns>
        //public Task<ApplicationUserDBModel> FindByNameAsync(string userName)
        //{
        //    var result=this.usermanager.FindByNameAsync(userName);
        //    return result ;
            
        //}

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

        public async Task<string> LoginAsync(LoginModel model)
        {
            var user = await this.usermanager.FindByNameAsync(model.UserName);        
            if (user != null && await this.usermanager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim("UserID", user.Id.ToString())
                        }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token= tokenHandler.WriteToken(securityToken);
                string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(token);
                return jsonString;
            }
            else
            {
                return null;
            }
            
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
