using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FieldMgt.Core.DTOs.Request
{

    public class CreateContactDetailDTO:BaseContactModel
   {
        public string PrimaryPhone { get; set; }
        public string AlternatePhone { get; set; }
        [StringLength(100, MinimumLength = 8)]
        public string PrimaryEmail { get; set; }
        [StringLength(100, MinimumLength = 8)]
        public string AlternateEmail { get; set; }
        [DefaultValue(true)]
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
    public class BaseContactModel
    {
    }
}
