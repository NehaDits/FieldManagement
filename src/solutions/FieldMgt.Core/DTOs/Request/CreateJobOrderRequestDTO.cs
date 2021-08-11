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
        public string Address { get; set; }
        public int? City { get; set; }
        public int? State { get; set; }
        public int? Country { get; set; }
        public string ZipCode { get; set; }
        public int? LeadId { get; set; }
        public int? ClientId { get; set; }
    }
}
