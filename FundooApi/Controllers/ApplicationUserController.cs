// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationUserController.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kavita Mirjolkar"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Common.Model;
    using FundooBusiness.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// this is application user controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        /// <summary>
        /// The application user
        /// </summary>
        private readonly IApplicationUserBusiness applicationUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserController"/> class.
        /// </summary>
        /// <param name="applicationUser">The application user.</param>
        public ApplicationUserController(IApplicationUserBusiness applicationUser)
        {
            this.applicationUser = applicationUser;
        }

        /// <summary>
        /// Registers the specified application user model.
        /// </summary>
        /// <param name="applicationUserModel">The application user model.</param>
        /// <returns>returns response</returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(ApplicationUserModel applicationUserModel)
        {
            try
            {
                var result = await this.applicationUser.RegistrationAsync(applicationUserModel);
                return this.Ok(new { result });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns response</returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await this.applicationUser.LoginAsync(model);
            if (result == "invalid user")
            {
                return this.BadRequest();
            }
            else
            {
                return this.Ok(new { result });
            }
        }

        [HttpPost]
        [Route("fblogin")]
        public async Task<IActionResult> FaceBookLogin(string email)
        {
            var result = await this.applicationUser.FaceBookLoginAsync(email);
            if (result == "invalid user")
            {
                return this.BadRequest();
            }
            else
            {
                return this.Ok(new { result });
            }
        }

        /// <summary>
        /// forget password function
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns response</returns>
        [HttpPost]
        [Route("forgotpassword")]
        public IActionResult ForgotPassword(ForgotPasswordModel model)
        {
            var result = this.applicationUser.ForgotPasswordAsync(model);
            return this.Ok(result);
        }

        /// <summary>
        /// Resets the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns response</returns>
        [HttpPost]
        [Route("resetpassword")]
        public IActionResult Reset(ResetPasswordModel model)
        {
            try
            {
                var result = this.applicationUser.ResetPassword(model);
                return this.Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Profiles the picture.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="email">The email.</param>
        /// <returns>returns response</returns>
        [HttpPost]
        [Route("profilepicture/{email}")]
        public IActionResult ProfilePicture(IFormFile file, string email)
        {
            if (file == null)
            {
                return this.BadRequest("No file found");
            }

            var result = this.applicationUser.ProfilePicture(file, email);
            return this.Ok(new { result });
        }

        /// <summary>
        /// Profiles the URL.
        /// </summary>
        /// <param name="userid">The user id.</param>
        /// <returns>returns response</returns>
        [HttpGet]
        [Route("url/{userid}")]
       public Task<string> ProfileUrl(string userid)
        {
            var result = this.applicationUser.ProfileUrl(userid);
            return result;
        }
    }
}