using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class ProductMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductMasterId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public string ProductName { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string ProductDescription { get; set; }
        public int ProductCategory { get; set; }
        public GlobalCode Category {get;set;}
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
        public ApplicationUser ProductMasterCreatedBy { get; set; }
        public ApplicationUser ProductMasterModifiedBy { get; set; }
        public ApplicationUser ProductMasterDeletedBy { get; set; }

    }
}
