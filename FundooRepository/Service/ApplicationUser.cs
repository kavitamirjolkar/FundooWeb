

namespace FundooRepository
{
    using Common.Model;
    using FundooRepository.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Threading.Tasks;

    public class ApplicationUserContextRepository : IApplicationUserContextRepository
    {
        private UserManager<ApplicationUserDBModel> usermanager;

        public ApplicationUserContextRepository(UserManager<ApplicationUserDBModel> userManager)
        {
            usermanager = userManager;
        }

        public Task CheckPasswordAsync(ApplicationUserDBModel applicationUser, string Password)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(ApplicationUserModel applicationUserModel)
        {
            ApplicationUserModel model = new ApplicationUserModel();
            ApplicationUserDBModel user = new ApplicationUserDBModel()
            {
                UserName = applicationUserModel.UserName,
                FirstName = applicationUserModel.FirstName,
                LastName = applicationUserModel.LastName,
                Email = applicationUserModel.Email,
            };
            var result= usermanager.CreateAsync(user, applicationUserModel.Password);
            return result;
        }


        public Task FindByEmailAsync(string Email)
        {
            throw new NotImplementedException();
        }

        public Task FindByNameAsync(string UserName)
        {
            throw new NotImplementedException();
        }
    }
}