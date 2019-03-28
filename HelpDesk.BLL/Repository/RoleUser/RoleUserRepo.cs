using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.BLL.Repository.Abstracts;
using HelpDesk.DAL;
using HelpDesk.Model.Enums;
using HelpDesk.Model.IdentityEntities;
using HelpDesk.Model.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Identity;

namespace HelpDesk.BLL.Repository.RoleUser
{
    public class RoleUserRepo : IRepoIdentity
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly MyContext DbContext;

        public RoleUserRepo(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, MyContext dbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            DbContext = dbContext;
        }



        public async Task<SignInResult> LoginUser(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
            return result;
        }

        public async Task<CreateUserResultViewModel> RegisterUser(RegisterViewModel model)
        {
            var user = new ApplicationUser()
            {
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            return new CreateUserResultViewModel()
            {
                IdentityResult = result,
                User = user
            };
        }

        public async Task CreateRoles()
        {
            var roles = Enum.GetNames(typeof(IdentityRoles));
            foreach (var role in roles)
            {
                if (!_roleManager.RoleExistsAsync(role).Result)
                {
                    await _roleManager.CreateAsync(new ApplicationRole()
                    {
                        Name = role
                    });
                }
            }
        }

        public async Task AddRole(ApplicationUser user)
        {
            if (_userManager.Users.Count() == 1)
            {
                var result = await _userManager.AddToRoleAsync(user, IdentityRoles.Admin.ToString());
            }
            else
            {
                var result = await _userManager.AddToRoleAsync(user, IdentityRoles.User.ToString());
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
