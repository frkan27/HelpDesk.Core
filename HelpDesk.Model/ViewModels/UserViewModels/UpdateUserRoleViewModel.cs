using System.Collections.Generic;

namespace HelpDesk.Model.ViewModels.UserViewModels
{
    public  class UpdateUserRoleViewModel
    {
        public string Id { get; set; }
        public List<string> Roles { get; set; }
    }
}
