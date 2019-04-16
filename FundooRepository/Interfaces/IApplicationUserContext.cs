

namespace FundooRepository.Interfaces
{
    using Common.Model;
    using System.Threading.Tasks;

    public interface IApplicationUserContextRepository
    {
        Task CreateAsync(ApplicationUserModel applicationUserModel);
        Task FindByNameAsync(string UserName);
        Task CheckPasswordAsync(ApplicationUserDBModel applicationUser, string Password);
        Task  FindByEmailAsync(string Email);
    }
}
