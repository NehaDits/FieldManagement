using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderProductId { get; set; }
        public int ProductMasterId { get; set; }
        public ProductMaster ProductMaster { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal? QuantityRequired { get; set; }
        public int? JobOrderId { get; set; }
        public JobOrder JobOrder { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
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
        public ApplicationUser OrderProductCreatedBy { get; set; }
        public ApplicationUser OrderProductModifiedBy { get; set; }
        public ApplicationUser OrderProductDeletedBy { get; set; }
    }
}
