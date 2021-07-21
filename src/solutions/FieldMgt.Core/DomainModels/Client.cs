using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ClienyCompanyName { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ClientDescription { get; set; }
        public int? ClientSource { get; set; }
        [DefaultValue(true)]
        public bool? IsActive { get; set; }
        public int? ContactDetailId { get; set; }
        [ForeignKey("ContactDetailId")]
        public ContactDetail ContactDetail { get; set; }
        public int? PermanentAddressId { get; set; }
        public int? BillingAddressId { get; set; }
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
        public GlobalCode RefSource { get; set; }
        public ApplicationUser ClientCreatedBy { get; set; }
        public ApplicationUser ClientModifiedBy { get; set; }
        public ApplicationUser ClientDeletedBy { get; set; }
        public AddressDetail ClientAddress { get; set; }
    }
}
