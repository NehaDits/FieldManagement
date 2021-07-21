using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class Estimation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstimationId { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal? EstimationAmount { get; set; }
        public int JobOrderID { get; set; }
        public JobOrder JobOrder { get; set; }
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
        public ApplicationUser EstimationCreatedBy { get; set; }
        public ApplicationUser EstimationModifiedBy { get; set; }
        public ApplicationUser EstimationDeletedBy { get; set; }

    }
}
