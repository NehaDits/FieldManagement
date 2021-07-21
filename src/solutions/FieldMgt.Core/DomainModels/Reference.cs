using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{   
    public class Reference
    {
        public Reference()
        {
            Staff1Navigation = new HashSet<Staff>();
            Lead1Navigation = new HashSet<Lead>();
            Lead2Navigation = new HashSet<Lead>();
            Lead3Navigation = new HashSet<Lead>();
            Lead8Navigation = new HashSet<Lead>();
            LeadContact1Navigation = new HashSet<LeadContact>();
            LeadCall1Navigation = new HashSet<LeadCall>();
            OPStatus = new HashSet<Order>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferenceId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string ReferenceName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string ReferenceCategory { get; set; }        
        
    }
}
