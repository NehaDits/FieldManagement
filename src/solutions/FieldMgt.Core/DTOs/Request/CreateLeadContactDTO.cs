using System;
using System.ComponentModel;

namespace FieldMgt.Core.DTOs.Request
{
    public class CreateLeadContactDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LeadId { get; set; }
        public CreateContactDetailDTO CreateContactDetailDTO { get; set; }
        public CreateAddressDTO createAddressDTO { get; set; }
    }
}
