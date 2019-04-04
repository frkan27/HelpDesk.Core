using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.BLL.Helper;
using HelpDesk.BLL.Repository.Abstracts;
using HelpDesk.BLL.Service.Sender;
using HelpDesk.DAL;
using HelpDesk.Model.Enums;
using HelpDesk.Model.IdentityEntities;
using HelpDesk.Model.ViewModels;
using HelpDesk.Model.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace HelpDesk.BLL.Repository.RoleUser
{
    public class RoleUserRepo : IRepoIdentity
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly MyContext DbContext;
        private readonly MembershipTools _membershipTools;
        private readonly EMailService _emailService;
        private readonly RoleUserRepo _roleUserRepo;

        public RoleUserRepo(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, MyContext dbContext, MembershipTools membershipTools, EMailService emailService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            DbContext = dbContext;
            _membershipTools = membershipTools;
            _emailService = emailService;
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
                UserName = model.UserName,
                ActivationCode = StringHelpers.GetCode(),
                AvatarPath = "/Image/default.jpg",

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
                var result = await _userManager.AddToRoleAsync(user, IdentityRoles.Customer.ToString());
            }
            else
            {
                var result = await _userManager.AddToRoleAsync(user, IdentityRoles.Customer.ToString());
            }
        }

        public async Task SendActivationMail(string SiteUrl, CreateUserResultViewModel user)
        {

            var body = $"Merhaba <b>{user.User.Name} {user.User.Surname}</b><br>Hesabınızı aktif etmek için aşağıdaki linke tıklayınız<br> <a href='{SiteUrl}/account/activation?code={user.User.ActivationCode}' >Aktivasyon Linki </a> ";
            await _emailService.SendAsync(new MailModel() { Body = body, Subject = "Sitemize Hoşgeldiniz" }, user.User.Email);
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }



    }
}
