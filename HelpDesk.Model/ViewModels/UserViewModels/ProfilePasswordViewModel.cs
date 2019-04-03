using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Model.ViewModels.UserViewModels
{
    public class ProfilePasswordViewModel
    {
        public UserProfileViewModel UserProfileViewModel { get; set; }
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
    }
}
