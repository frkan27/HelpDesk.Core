using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Model.IdentityEntities
{
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Surname { get; set; }

        public DateTime RegisteredDate { get; set; } = DateTime.Now;

        [DisplayName("Enlem")]
        public double? Latitude { get; set; }
        [DisplayName("Boylam")]
        public double? Longtitude { get; set; }
        public string ActivationCode { get; set; }
        public string AvatarPath { get; set; }
    }
}
