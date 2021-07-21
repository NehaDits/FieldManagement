using System.ComponentModel.DataAnnotations;

namespace FieldMgt.Core.DTOs.Request
{
    public class CreateLeadContactDTO:BaseCreateLeadContactModel
    {        
        public string Name { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string PermaAddress1 { get; set; }
        public string PermaAddress2 { get; set; }
        public string PermaCity { get; set; }
        public string PermaCountry { get; set; }
        public string CoresAddress1 { get; set; }
        public string CoresAddress2 { get; set; }
        public string CoresCity { get; set; }
        public string CoresCountry { get; set; }        
    }
    public class BaseCreateLeadContactModel
    {
        public int? LeadId { get; set; }
        public int? LeadContactId { get; set; }
    }
}
