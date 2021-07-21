using System;
using System.Collections.Generic;
using System.Text;

namespace FieldMgt.Core.DTOs.Request
{
    public class UpdateLeadDTO:BaseUpdateLeadDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LeadContact { get; set; }
        public string LeadDescription { get; set; }
        public int LeadSource { get; set; }
        public int LeadStatus { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        //public string CoresAddress1 { get; set; }
        //public string CoresAddress2 { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public int City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        //public int CoresCity { get; set; }
        //public int CoresCountry { get; set; }
        public int LeadStage { get; set; }
        public bool IsActive { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class BaseUpdateLeadDTO
    {
        public int? LeadId { get; set; }
    }
}
