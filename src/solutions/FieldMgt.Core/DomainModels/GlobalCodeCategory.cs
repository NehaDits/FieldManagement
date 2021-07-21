using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class GlobalCodeCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GlobalCodeCategoryId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string GlobalCodeCategoryName { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }        
        [DefaultValue(true)]
        public bool? AllowAddDelete { get; set; }
        [DefaultValue(true)]
        public bool? AllowCodeNameEdit { get; set; }
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
        public ApplicationUser GlobalCodeCategoryCreatedBy { get; set; }
        public ApplicationUser GlobalCodeCategoryModifiedBy { get; set; }
        public ApplicationUser GlobalCodeCategoryDeletedBy { get; set; }
    }
}
