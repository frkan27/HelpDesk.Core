using HelpDesk.Model.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Model.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Http;

namespace HelpDesk.BLL
{
    public class MembershipTools
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MembershipTools(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApplicationUser> GetCurrentUser(ClaimsPrincipal userClaims)
        {
            return await _userManager.GetUserAsync(userClaims);
        }

        public async Task<ApplicationUser> GetUserWithId(string Id)
        {
            return await _userManager.FindByIdAsync(Id);
        }

        public async Task<ApplicationUser> GetUserWithMail(string mail)
        {
            return await _userManager.FindByEmailAsync(mail);
        }
        public ProfilePasswordViewModel ConvertProfile(ApplicationUser user)
        {
            ProfilePasswordViewModel data = new ProfilePasswordViewModel()
            {
                UserProfileViewModel = new UserProfileViewModel()
                {
                    Email = user.Email,
                    Id = user.Id,
                    Name = user.Name,
                    PhoneNumber = user.PhoneNumber,
                    Surname = user.Surname,
                    UserName = user.UserName,
                    AvatarPath = string.IsNullOrEmpty(user.AvatarPath) ? "~/assets/img/avatars/avatar3.jpg" : user.AvatarPath
                }
            };
            return data;
        }

        public UserManager<ApplicationUser> UserManager
        {
            get { return _userManager; }
        }
        public SignInManager<ApplicationUser> SignInManager
        {
            get { return _signInManager; }
        }

      
    }

}

