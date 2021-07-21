
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FieldMgt.Core.DomainModels
{
    public class AddressDetail
    {
        public AddressDetail()
        {
            LeadAddress1Id = new HashSet<Lead>();
            LeadAddress2Id = new HashSet<Lead>();
            OrderAddress1Id = new HashSet<Order>();
            OrderAddress2Id = new HashSet<Order>();
            ServiceProviderAddress1Id = new HashSet<ServiceProvider>();
            ServiceProviderAddress2Id = new HashSet<ServiceProvider>();
            ServiceProviderLocationAddress1Id = new HashSet<ServiceProviderLocation>();
            ServiceProviderLocationAddress2Id = new HashSet<ServiceProviderLocation>();
            VendorAddress1Id = new HashSet<Vendor>();
            VendorAddress2Id = new HashSet<Vendor>();
            StaffAddress1Id = new HashSet<Staff>();
            StaffAddress2Id = new HashSet<Staff>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressDetailId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        [MaxLength(10)]
        public string ZipCode { get; set; }
        public int AddressType { get; set; }
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
        public ApplicationUser AddressCreatedBy { get; set; }
        public ApplicationUser AddressModifiedBy { get; set; }
        public ApplicationUser AddressDeletedBy { get; set; }
        public GlobalCode AddressCode { get; set; }
        public ICollection<Lead> LeadAddress1Id { get; set; }
        public ICollection<Lead> LeadAddress2Id { get; set; }
        public ICollection<Order> OrderAddress1Id { get; set; }
        public ICollection<Order> OrderAddress2Id { get; set; }
        public ICollection<ServiceProvider> ServiceProviderAddress1Id { get; set; }
        public ICollection<ServiceProvider> ServiceProviderAddress2Id { get; set; }
        public ICollection<ServiceProviderLocation> ServiceProviderLocationAddress1Id { get; set; }
        public ICollection<ServiceProviderLocation> ServiceProviderLocationAddress2Id { get; set; }
        public ICollection<Vendor> VendorAddress1Id { get; set; }
        public ICollection<Vendor> VendorAddress2Id { get; set; }
        public ICollection<Staff> StaffAddress1Id { get; set; }
        public ICollection<Staff> StaffAddress2Id { get; set; }
    }
}
