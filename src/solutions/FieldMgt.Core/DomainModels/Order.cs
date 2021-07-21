using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class Order
    {        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [Required]
        public int? ClientId { get; set; }
        public Client Client { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string OrderDescription { get; set; }
        public int? OrderStatus { get; set; }        
        public int? ContactDetailId { get; set; }
        [ForeignKey("ContactDetailId")]
        public ContactDetail ContactDetail { get; set; }
        public int? PermanentAddressId { get; set; }
        public int? BillingAddressId { get; set; }
        [DefaultValue(true)]
        public bool? IsActive { get; set; }
        [DefaultValue(false)]
        public bool? IsComplete { get; set; }        
        public DateTime? DueDate { get; set; }        
        public DateTime? ActualCompletionDate { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string AssignedTo { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal? OrderAmount { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal? AmountPaid { get; set; }
        [Column(TypeName = "decimal(16,2)")]
        public decimal? BalanceAmount { get; set; }
        public int? PaymentStatus { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string CompletionCertifcate { get; set; }
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
        public ApplicationUser OrderAssignedTo { get; set; }
        public ApplicationUser OrderCreatedBy { get; set; }
        public ApplicationUser OrderModifiedBy { get; set; }
        public ApplicationUser OrderDeletedBy { get; set; }
        public GlobalCode OrderPaymentStatus { get; set; }
        public GlobalCode OrderCompletionStatus { get; set; }
        public AddressDetail OrderAddress { get; set; }
        public AddressDetail OrderBillingAddress { get; set; }
    }
}
