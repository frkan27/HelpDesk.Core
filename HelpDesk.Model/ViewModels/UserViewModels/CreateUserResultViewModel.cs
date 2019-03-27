﻿using HelpDesk.Model.IdentityEntities;
using Microsoft.AspNetCore.Identity;

namespace HelpDesk.Model.ViewModels.UserViewModels
{
    public class CreateUserResultViewModel
    {
        public IdentityResult IdentityResult { get; set; }

        public AppUser User { get; set; }
    }
}
