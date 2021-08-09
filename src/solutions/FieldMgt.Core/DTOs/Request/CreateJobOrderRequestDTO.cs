using FieldMgt.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Request
{
    public class CreateJobOrderRequestDTO
    {
        public string JobOrderDescription { get; set; }
        public int LeadId { get; set; }
        public int ClientId { get; set; }
    }
}
