using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Model.ViewModels.UserViewModels
{
    public class RegisterLoginViewModel
    {
        public LoginViewModel LoginViewModel { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
    }
}
