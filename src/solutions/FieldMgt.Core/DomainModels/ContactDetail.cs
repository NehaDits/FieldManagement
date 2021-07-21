using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class ContactDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactDetailId { get; set; }
        [Phone]
        public string PrimaryPhone { get; set; }
        [Phone]
        public string AlternatePhone { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string PrimaryEmail { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string AlternateEmail { get; set; }
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
        public ApplicationUser ContactDetailsCreatedBy { get; set; }
        public ApplicationUser ContactDetailsModifiedBy { get; set; }
        public ApplicationUser ContactDetailsDeletedBy { get; set; }
    }
}
