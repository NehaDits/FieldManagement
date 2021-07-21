using System;
using System.Collections.Generic;
using System.Text;

namespace FieldMgt.Core.DTOs.Response
{
    public class ContactResponseDTO
    {
        public string PrimaryPhone { get; set; }
        public string AlternatePhone { get; set; }
        public string PrimaryEmail { get; set; }
        public string AlternateEmail { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
