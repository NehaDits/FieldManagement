using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DomainModels
{
    public class StaffOrganization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffOrganizationId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string StaffOrganizationName { get; set; }        
        [DefaultValue(true)]
        public bool? IsActive { get; set; }
        public int? ContactDetailId { get; set; }
        [ForeignKey("ContactDetailId")]
        public ContactDetail ContactDetail { get; set; }
        public int? AddressDetailId { get; set; }
        public AddressDetail AddressDetail { get; set; }
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
        public ApplicationUser StaffOrganizationCreatedBy { get; set; }
        public ApplicationUser StaffOrganizationModifiedBy { get; set; }
        public ApplicationUser StaffOrganizationDeletedBy { get; set; }
    }
}
