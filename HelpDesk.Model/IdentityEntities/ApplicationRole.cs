using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Model.IdentityEntities
{
    public class ApplicationRole : IdentityRole
    {
        [StringLength(128)]
        public string Desc { get; set; }
    }
}
