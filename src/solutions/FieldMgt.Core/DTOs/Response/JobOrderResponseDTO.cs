using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Response
{
    public class JobOrderResponseDTO
    {
        public int JobOrderId { get; set; }
        public string JobOrderDescription { get; set; }
        public int? LeadId { get; set; }
        public int? ClientId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
