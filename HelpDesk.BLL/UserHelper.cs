using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Model.IdentityEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace HelpDesk.BLL
{
    public static class UserHelper
    {
        private static readonly MembershipTools _membershipTools;
        private static readonly IHttpContextAccessor _httpContextAccessor;

        public static async System.Threading.Tasks.Task<string> GetUserAsync()
        {
            var userx = _httpContextAccessor.HttpContext.User.Identity.Name;
            //var user = await _membershipTools.UserManager.GetUserAsync(HttpContext.User);
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return userId;
        }

        public static async Task<ApplicationUser> GetUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _membershipTools.UserManager.FindByIdAsync(userId);
            return await user;
        }
    }
}
