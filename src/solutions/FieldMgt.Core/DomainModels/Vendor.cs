using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class Vendor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendorId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string VendorCompanyName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string VendorOwnerorMD { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string VendorContactPersonName { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string VendorGSTNumber { get; set; }
        [Column(TypeName = "nvarchar(12)")]
        public string VendorAccountNumber { get; set; }
        [Column(TypeName = "nvarchar(11)")]
        public string VendorIFSCCode { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string VendorBankName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string VendorBankBranch { get; set; }
        public int? PermanentAddressId { get; set; }
        public int? BillingAddressId { get; set; }
        public int? ContactDetailId { get; set; }
        [ForeignKey("ContactDetailId")]
        public ContactDetail ContactDetail { get; set; }
        [DefaultValue(true)]
        public bool? IsActive { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [DefaultValue(false)]
        public bool? IsDeleted { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public ApplicationUser VendorCreatedBy { get; set; }
        public ApplicationUser VendorModifiedBy { get; set; }
        public ApplicationUser VendorDeletedBy { get; set; }
        public AddressDetail VendorAddress { get; set; }
        public AddressDetail VendorBillingAddress { get; set; }
    }
}
