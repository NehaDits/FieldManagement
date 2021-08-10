using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Request
{
    public class UpdateJobOrderRequirementRequestDTO
    {
        public int JobOrderRequirementId { get; set; }
        public string RequirementDescription { get; set; }
        public DateTime? RequirementGatheredOn { get; set; }
        public int? JobOrderId { get; set; }        
        public int RequirementGatheredBy { get; set; }
    }
}
