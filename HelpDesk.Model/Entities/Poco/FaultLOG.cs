using HelpDesk.Model.Entities.BaseEntities;
using HelpDesk.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.Model.Entities.Poco
{
    [Table("FaultLOG")]
    public class FaultLOG:BaseEntity<int>
    {
        public string Description { get; set; }
        public IdentityRoles AuthorizeRole { get; set; }
        public int FaultId { get; set; }

        [ForeignKey("FaultId")]
        public FaultRecord Fault { get; set; }
    }
}
