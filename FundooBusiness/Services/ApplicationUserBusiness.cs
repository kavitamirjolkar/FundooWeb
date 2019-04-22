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
    using System.Text;
    using System.Threading.Tasks;
    using Common.Model;
    using FundooBusiness.Interfaces;
    using FundooRepository.Interfaces;
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
        /// The application settings
        /// </summary>
        private readonly ApplicationSettings appSettings;

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
        /// <param name="appSettings">The application settings.</param>
        /// <param name="emailSender">The email sender.</param>
        public ApplicationUserBusiness(IApplicationUserContextRepository context, IOptions<ApplicationSettings> appSettings, IEmailSender emailSender)
        {
            this.applicationUserContext = context;
            this.appSettings = appSettings.Value;
            this.emailSender = emailSender;
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
            var result = this.applicationUserContext.FindByEmailAsync(model);
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
        public string LoginAsync(LoginModel model)
        {
           var user = this.applicationUserContext.FindByNameAsync(model);
            if (user != null)
            {
                var result = this.applicationUserContext.CheckPasswordAsync(model);
            ////    var tokenDescriptor = new SecurityTokenDescriptor
            ////    {
            ////        Subject = new ClaimsIdentity(new Claim[]
            ////           {
            ////            new Claim("UserID", user.Id.ToString())
            ////           }),
            ////        Expires = DateTime.UtcNow.AddDays(1),
            ////        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                  
            ////};
            ////    var tokenHandler = new JwtSecurityTokenHandler();
            ////    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            ////    var token = tokenHandler.WriteToken(securityToken);
                string token = this.GenerateJSONWebToken();
                return token;
            }
            else
            {
                return null;
            }
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

        /// <summary>
        /// Generates the json web token.
        /// </summary>
        /// <returns>returns string</returns>
        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.appSettings.JWT_Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("localhost", "localhost", null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
