using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FieldMgt.Core.DomainModels
{
    public class LeadCall
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeadCallId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
        public int? CallStatus { get; set; }
        public int LeadId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string CalledBy { get; set; }
        public DateTime? CalledOn { get; set; }
        public ApplicationUser LeadCalledBy { get; set; }
        public GlobalCode RefLeadCallStatus { get; set; }
        public Lead RefCallLeadId { get; set; }
        [DefaultValue(true)]
        public bool? IsActive { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string DeletedBy { get; set; }
        [DefaultValue(false)]
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
