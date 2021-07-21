using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class JobOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobOrderId { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string JobOrderDescription { get; set; }
        public int? LeadId { get; set; }
        public Lead Lead { get; set; }
        public int? ClientId { get; set; }
        public Client Client { get; set; }
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
        public ApplicationUser JobOrderCreatedBy { get; set; }
        public ApplicationUser JobOrderModifiedBy { get; set; }
        public ApplicationUser JobOrderDeletedBy { get; set; }
    }
}
