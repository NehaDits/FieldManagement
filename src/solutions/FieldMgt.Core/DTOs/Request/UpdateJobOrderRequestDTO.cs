using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Request
{
    public class UpdateJobOrderRequestDTO
    {
        public string JobOrderDescription { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public int ZipCode { get; set; }
        public int JobOrderId { get; set; }
        public int? LeadId { get; set; }
        public int? ClientId { get; set; }
    }
}
