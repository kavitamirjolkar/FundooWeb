using Common.Model;
using FundooBusiness.Interfaces;
using FundooRepository.Interfaces;
using System;
using System.Threading.Tasks;


namespace FundooBusiness.Services
{
    public class ApplicationUserBusiness : IApplicationUserBusiness
    {
        private readonly IApplicationUserContextRepository applicationUserContext;

        public ApplicationUserBusiness(IApplicationUserContextRepository context)
        {
            this.applicationUserContext = context;
        }

        public Task ForgotPasswordAsync(ForgotPasswordModel model)
        {
            throw new NotImplementedException();
        }

        public Task<string> LoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegistrationAsync(ApplicationUserModel applicationUserModel)
        {

            await this.applicationUserContext.CreateAsync(applicationUserModel);
            return true;
        }

        //public async Task<string> LoginAsync(LoginModel model)
        //{
        //    var user = await this.usermanager.FindByNameAsync(model.UserName);
        //    if (user != null && await this.usermanager.CheckPasswordAsync(user, model.Password))
        //    {
        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new Claim[]
        //            {
        //                new Claim("Token", user.Token.ToString())
        //            }),
        //            Expires = DateTime.UtcNow.AddDays(1),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
        //        };
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        //        var token = tokenHandler.WriteToken(securityToken);
        //        var cacheKey = token;
        //        this.distributedcache.GetString(cacheKey);

        //        ////startTime = DateTime.UtcNow.ToString();
        //        this.distributedcache.SetString(cacheKey, token);
        //        return token;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public Task ResetPasswordAsync(ResetPasswordModel model)
        {
            throw new NotImplementedException();
        }
    }
}
