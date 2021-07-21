using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class OrderTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderTransactiontId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal? AmountPaid { get; set; }
        public int? PaymentMethod { get; set; }
        public string PaymentReferenceNumber { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [DefaultValue(false)]
        public bool? IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public ApplicationUser OrderTransactionCreatedBy { get; set; }
        public ApplicationUser OrderTransactionModifiedBy { get; set; }
        public ApplicationUser OrderTransactionDeletedBy { get; set; }
    }
}
