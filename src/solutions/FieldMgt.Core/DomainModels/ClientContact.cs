using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
   public class ClientContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientContactId { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; }
        public int? Gender { get; set; }
        public int? AddressDetailId { get; set; }
        [ForeignKey("AddressDetailId")]
        public AddressDetail AddressDetail { get; set; }
        public int? ContactDetailId { get; set; }
        [ForeignKey("ContactDetailId")]
        public ContactDetail ContactDetail { get; set; }
        public int? ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        [DefaultValue(true)]
        public bool? IsActive { get; set; }
        [DefaultValue(false)]
        public bool? IsDeleted { get; set; }
        public GlobalCode RefGender { get; set; }
        public ApplicationUser ClientContactCreatedBy { get; set; }
        public ApplicationUser ClientContactModifiedBy { get; set; }
        public ApplicationUser ClientContactDeletedBy { get; set; }
    }
}
