using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FieldMgt.Core.DomainModels
{
    public class ProductsIssued
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductIssuedId { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal? QuantityIssued { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string IssuedBy { get; set; }
        public DateTime? IssuedOn { get; set; }
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
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public ApplicationUser ProductIssuedBy { get; set; }
        public ApplicationUser PIModifiedBy { get; set; }
        public ApplicationUser PIDeletedBy { get; set; }
    }
}
