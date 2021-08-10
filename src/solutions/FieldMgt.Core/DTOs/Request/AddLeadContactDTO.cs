using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Request
{
    public class AddLeadContactDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public int? LeadId { get; set; }
        public string PrimaryPhone { get; set; }
        public string AlternatePhone { get; set; }
        public string PrimaryEmail { get; set; }
        public string AlternateEmail { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string ZipCode { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
