using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; }
        public int? Gender { get; set; }
        public DateTime? DOB { get; set; }                   
        public int? Designation { get; set; }
        public int? PermanentAddressId { get; set; }
        public int? CorrespondenceAddressId { get; set; }
        public int? ContactDetailId { get; set; }
        [ForeignKey("ContactDetailId")]
        public ContactDetail ContactDetail { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string UserId { get; set; }
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
        public GlobalCode StaffDesignation { get; set; }
        public GlobalCode StaffGender{ get; set; }
        public ApplicationUser StaffUserId { get; set; }
        public ApplicationUser StaffCreatedBy { get; set; }
        public ApplicationUser StaffModifiedBy { get; set; }
        public ApplicationUser StaffDeletedBy { get; set; }
        public AddressDetail StaffPermaAddress { get; set; }
        public AddressDetail StaffCorresAddress { get; set; }
    }    
}
