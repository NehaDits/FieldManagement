using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FieldMgt.Core.DomainModels
{
    public class VendorProducts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendorProductId { get; set; }
        public int ProductId { get; set; }
        public ProductMaster ProductMaster { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal ProductPrice { get; set; }
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
        public ApplicationUser VPCreatedBy { get; set; }
        public ApplicationUser VPModifiedBy { get; set; }
        public ApplicationUser VPDeletedBy { get; set; }
    }
}
