using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FieldMgt.Core.DomainModels
{
    public class ServiceProviderLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceProviderLocationId { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string ServiceProviderLocationName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        [MaxLength(15)]
        public string ServiceProviderLocationIncharge { get; set; }
        public int? ContactDetailId { get; set; }
        [ForeignKey("ContactDetailId")]
        public ContactDetail ContactDetail { get; set; }
        public int? PermanentAddressId { get; set; }
        public int? BillingAddressId { get; set; }
        public int ServiceProviderId { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public AddressDetail ServiceProviderLocationAddress { get; set; }
        public AddressDetail ServiceProviderLocationBillingAddress { get; set; }
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
        public ApplicationUser SPLCreatedBy { get; set; }
        public ApplicationUser SPLModifiedBy { get; set; }
        public ApplicationUser SPLDeletedBy { get; set; }
    }
}
