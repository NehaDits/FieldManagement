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
        public string Address { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string ZipCode { get; set; }
        public int? LeadId { get; set; }
        public int? ClientId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
