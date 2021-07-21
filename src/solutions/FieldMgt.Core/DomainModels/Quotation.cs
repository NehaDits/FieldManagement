using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class Quotation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuotationId { get; set; }        
        [Column(TypeName = "decimal(8,2)")]
        public decimal? BuyerDesiredPrice { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal? InitialQuotedPrice { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal? LastQuotedPrice { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal? MinPossiblePrice { get; set; }
        public int? JobOrderId { get; set; }
        public JobOrder JobOrder { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
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
        public ApplicationUser NegotitationCreatedBy { get; set; }
        public ApplicationUser NegotitationModifiedBy { get; set; }
        public ApplicationUser NegotitationDeletedBy { get; set; }
    }
}
