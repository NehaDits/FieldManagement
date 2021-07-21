using System;
using System.ComponentModel;

namespace FieldMgt.Core.DTOs.Request
{
    public class CreateLeadDTO:BaseCreateLeadModel
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LeadContact { get; set; }    
        public string LeadDescription { get; set; }       
        public int LeadSource { get; set; }
        public int LeadStatus { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        //public string Address2 { get; set; }
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
        [DefaultValue(true)]
        public bool IsActive { get; set; }     
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
    public class BaseCreateLeadModel
    {
        public int? LeadId { get; set; }
    }

}
