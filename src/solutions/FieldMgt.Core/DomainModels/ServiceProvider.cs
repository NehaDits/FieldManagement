using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class ServiceProvider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceProviderId { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string ServiceProviderName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        [MaxLength(15)]
        public string ServiceProviderIncharge { get; set; }
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
        [DefaultValue(false)]
        public bool? IsDeleted { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public ApplicationUser SPCreatedBy { get; set; }
        public ApplicationUser SPModifiedBy { get; set; }
        public ApplicationUser SPDeletedBy { get; set; }
        public AddressDetail ServiceProviderAddress { get; set; }
        public AddressDetail ServiceProviderBillingAddress { get; set; }
    }
}
