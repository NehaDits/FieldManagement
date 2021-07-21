using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class JobOrderRequirement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobOrderRequirementId { get; set; }
        [Column(TypeName = "nvarchar(455)")]
        public string RequirementDescription { get; set; }
        public DateTime? RequirementGatheredOn { get; set; }
        public int JobOrderId { get; set; }
        public JobOrder JobOrder { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string RequirementGatheredBy { get; set; }
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
        public ApplicationUser RequirementCreatedBy { get; set; }
        public ApplicationUser RequirementModifiedBy { get; set; }
        public ApplicationUser RequirementDeletedBy { get; set; }
    }
}
