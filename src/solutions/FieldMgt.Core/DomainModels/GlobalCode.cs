using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class GlobalCode
    {
        public GlobalCode()
        {
            Staff1Navigation = new HashSet<Staff>();
            Staff2Navigation = new HashSet<Staff>();
            Lead1Navigation = new HashSet<Lead>();
            Lead2Navigation = new HashSet<Lead>();
            Lead3Navigation = new HashSet<Lead>();
            LeadContact1Navigation = new HashSet<LeadContact>();
            LeadCall1Navigation = new HashSet<LeadCall>();
            OPStatus = new HashSet<Order>();
            OrdersStatus = new HashSet<Order>();
            AddressTypeRef = new HashSet<AddressDetail>();
            ClientSourceRef = new HashSet<Client>();            
            ClientContactSourceRef = new HashSet<ClientContact>();
            MaintenanceTypesRef = new HashSet<Maintenance>();
            ProductCategoryRef = new HashSet<ProductMaster>();
            NotesTypeRef = new HashSet<Notes>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GlobalCodeId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string GlobalCodeName { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
        public int GlobalCodeCategoryId { get; set; }
        [ForeignKey("GlobalCodeCategoryId")]
        public GlobalCodeCategory GlobalCodeCategory { get; set; }
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
        public ApplicationUser GlobalCodeCreatedBy { get; set; }
        public ApplicationUser GlobalCodeModifiedBy { get; set; }
        public ApplicationUser GlobalCodeDeletedBy { get; set; }
        public ICollection<Staff> Staff1Navigation { get; set; }
        public ICollection<Lead> Lead1Navigation { get; set; }
        public ICollection<Lead> Lead2Navigation { get; set; }
        public ICollection<Lead> Lead3Navigation { get; set; }
        public ICollection<LeadContact> LeadContact1Navigation { get; set; }
        public ICollection<LeadCall> LeadCall1Navigation { get; set; }
        public ICollection<Order> OPStatus { get; set; }
        public ICollection<Order> OrdersStatus { get; set; }
        public ICollection<AddressDetail> AddressTypeRef { get; set; }
        public ICollection<Client> ClientSourceRef { get; set; }
        public ICollection<ClientContact> ClientContactSourceRef { get; set; }
        public ICollection<Maintenance> MaintenanceTypesRef { get; set; }
        public ICollection<ProductMaster> ProductCategoryRef { get; set; }
        public ICollection<Notes> NotesTypeRef { get; set; }
        public ICollection<Staff> Staff2Navigation { get; set; }
    }
}
