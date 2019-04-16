using Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooBusiness.Interfaces
{
   public interface IApplicationUserBusiness
    {

        Task<bool> RegistrationAsync(ApplicationUserModel applicationUserModel);
        Task<string> LoginAsync(LoginModel model);
        Task ForgotPasswordAsync(ForgotPasswordModel model);
        Task ResetPasswordAsync(ResetPasswordModel model);
    }
}
