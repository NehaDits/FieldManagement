using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class EstimationDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstimationDetailId { get; set; }
        public int ProductMasterId { get; set; }
        public ProductMaster ProductMaster { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal? ProductUnitPrice { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal? QuantityRequired { get; set; }
        public int EstimationId { get; set; }
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
        public Estimation Estimation { get; set; }
        public ApplicationUser EstimationDetailCreatedBy { get; set; }
        public ApplicationUser EstimationDetailModifiedBy { get; set; }
        public ApplicationUser EstimationDetailDeletedBy { get; set; }
    }
}
