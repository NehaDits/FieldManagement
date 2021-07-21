using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class OrderImplementationDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderImplementationDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ServiceProviderLocationId { get; set; }
        public ServiceProviderLocation ServiceProviderLocation { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string PocName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string TeamLead { get; set; }
        [Column(TypeName = "nvarchar(14)")]
        public string PocContactNumber { get; set; }
        [Column(TypeName = "nvarchar(14)")]
        public string TeamLeadContactNumber { get; set; }
        public int? NumberofDayRequired { get; set; }
        public DateTime? ProposedCompletionDate { get; set; }
        public DateTime? ConfirmedCompletionDate { get; set; }
        [DefaultValue(false)]
        public bool? IsComplete { get; set; }
    }
}
