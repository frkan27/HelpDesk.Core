﻿using HelpDesk.Model.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace HelpDesk.BLL
{
    public class MembershipTools
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public MembershipTools(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async System.Threading.Tasks.Task<ApplicationUser> GetCurrentUser(ClaimsPrincipal userClaims)
        {
            return await _userManager.GetUserAsync(userClaims);
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
