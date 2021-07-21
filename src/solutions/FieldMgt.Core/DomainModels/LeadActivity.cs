using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class LeadActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeadActivityId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ActivityDescription { get; set;}
        public DateTime? DueDate { get; set; } 
        public int Status { get; set; }
        public int LeadId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string AssignedTo { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string CreatedBy { get; set; }        
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ModifiedBy { get; set; }        
        public DateTime? ModifiedOn { get; set; }
        public ApplicationUser LeadActivityCreatedBy { get; set; }
        public ApplicationUser LeadActivityModifiedBy { get; set; }
        public ApplicationUser LeadActivityAssignedTo { get; set; }
        public Reference RefLeadActivityStatus { get; set; }
        public Lead RefLeadId { get; set; }
    }
}
