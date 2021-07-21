using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FieldMgt.Core.DTOs.Request
{
    public class RegistrationDTO:BaseRegistration
    {
        [StringLength(100)]
        [EmailAddress(ErrorMessage ="Please enter a valid Email address")]
        public string Email { get; set; }
        [StringLength(30, MinimumLength = 1)]
        [Required(ErrorMessage ="Please Enter First Name")]
        public string FirstName { get; set; }
        [StringLength(30, MinimumLength = 1)]
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }
        public int? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public int? PermanentAddressId { get; set; }
        public int? CorrespondenceAddressId { get; set; }
        public int? ContactDetailId { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public string UserId { get; set; }        
        public int Designation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
    public class BaseRegistration
    {
        public int? EmployeeId { get; set; }
    }
}

