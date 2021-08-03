using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FieldMgt.Core.DTOs.Request
{
    public class CreateLeadDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public string LeadCompanyName { get; set; }    
        public string LeadDescription { get; set; }       
        public int LeadSource { get; set; }
        public int LeadStatus { get; set; }
        public int LeadStage { get; set; }
        [StringLength(100, MinimumLength = 5)]
        public string PermanentAddress { get; set; }
        public int PermanentCity { get; set; }
        public int PermanentState { get; set; }
        public int PermanentCountry { get; set; }
        public string PermanentZipCode { get; set; }
        [StringLength(100, MinimumLength = 5)]
        public string CorrespondenceAddress { get; set; }
        public int CorrespondenceCity { get; set; }
        public int CorrespondenceState { get; set; }
        public int CorrespondenceCountry { get; set; }
        public string CorrespondenceZipCode { get; set; }
        public string PrimaryPhone { get; set; }
        public string AlternatePhone { get; set; }
        [StringLength(100, MinimumLength = 8)]
        public string PrimaryEmail { get; set; }
        [StringLength(100, MinimumLength = 8)]
        public string AlternateEmail { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }     
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
