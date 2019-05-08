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
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Common.Model;
    using FundooRepository.DBContext;
    using FundooRepository.Interfaces;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Distributed;
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
        /// The context
        /// </summary>
        private readonly AuthenticationContext context;

        /// <summary>
        /// The distributedcache/
        /// </summary>
        private readonly IDistributedCache distributedcache;

        /// <summary>
        /// The user manager
        /// </summary>
        private UserManager<ApplicationUserDBModel> usermanager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserContextRepository"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="appSettings">The application settings.</param>
        /// <param name="context">The context.</param>
        public ApplicationUserContextRepository(UserManager<ApplicationUserDBModel> userManager, IOptions<ApplicationSettings> appSettings, AuthenticationContext context, IDistributedCache distributedcache)
        {
            this.usermanager = userManager;
            this.appSettings = appSettings.Value;
            this.context = context;
            this.distributedcache = distributedcache;

        }

        /// <summary>
        /// Checks the password asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// returns response
        /// </returns>
        public async Task<bool> CheckPasswordAsync(ApplicationUserModel model, string password)
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
        /// <param name="email">The email.</param>
        /// <returns>
        /// returns response
        /// </returns>
        public Task<ApplicationUserDBModel> FindByEmailAsync(string email)
        {
            var user = this.usermanager.FindByEmailAsync(email);
            return user;
        }

        /// <summary>
        /// Finds the by name asynchronous.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>
        /// returns response
        /// </returns>
        public Task<ApplicationUserDBModel> FindByNameAsync(string userName)
        {
            var result = this.usermanager.FindByNameAsync(userName);
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
        /// Logins the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// returns response
        /// </returns>
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
                var token = tokenHandler.WriteToken(securityToken);
                var cacheKey = model.UserName;
                this.distributedcache.GetString(cacheKey);
                this.distributedcache.SetString(cacheKey, token);
                return token;
            }

            return "invalid user";
        }

        public async Task<string> FaceBookLoginAsync(string email)
        {
            var user = await this.usermanager.FindByEmailAsync(email);
            if (user != null)
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
                var token = tokenHandler.WriteToken(securityToken);
                var cacheKey = email;
                this.distributedcache.GetString(cacheKey);
                this.distributedcache.SetString(cacheKey, token);
                return token;
            }

            return "invalid user";
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
            var stream = file.OpenReadStream();
            var name = file.FileName;
            CloudinaryDotNet.Account account = new CloudinaryDotNet.Account("dhnj4wxml", "754358186258935", "4l9_c_lMhktpvRSpORFDFYHAbKg");
            CloudinaryDotNet.Cloudinary cloudinary = new CloudinaryDotNet.Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(name, stream)
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            cloudinary.Api.UrlImgUp.Transform(new Transformation().Height(99).Width(60).Crop("limit"));
            var data = this.context.ApplicationUsers.Where(t => t.Email == email).FirstOrDefault();
            data.ProfilePicture = uploadResult.Uri.ToString();

            try
            {
                var result = this.context.SaveChanges();
                return data.ProfilePicture;
            }
            catch (Exception ex)
            {
                return ex.Message;
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

        /// <summary>
        /// Profiles the URL.
        /// </summary>
        /// <param name="userid">The user id.</param>
        /// <returns>
        /// returns response
        /// </returns>
        public async Task<string> ProfileUrl(string userid)
        {
            var data = await this.usermanager.FindByIdAsync(userid);
            return data.ProfilePicture.ToString();
        }
    }
}
