using HelpDesk.Model.IdentityEntities;
using HelpDesk.Model.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace HelpDesk.BLL.Repository.Abstracts
{
    public interface IRepoIdentity
    {
        Task<CreateUserResultViewModel> RegisterUser(RegisterViewModel model);
        Task<SignInResult> LoginUser(LoginViewModel model);
        Task Logout();
        Task CreateRoles();
        Task AddRole(ApplicationUser user);
        Task SendActivationMail(string SiteUrl, CreateUserResultViewModel user);
    }
}
