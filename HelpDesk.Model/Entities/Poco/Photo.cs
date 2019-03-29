using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using HelpDesk.Model.Entities.BaseEntities;

namespace HelpDesk.Model.Entities.Poco
{
    [Table("Photos")]
    public class Photo : BaseEntity<int>
    {
        [Required]
        public string Path { get; set; }
        public int FaultId { get; set; }

        [ForeignKey("FaultId")]
        public virtual FaultRecord FaultRecord { get; set; }
    }
}
