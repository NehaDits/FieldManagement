using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FieldMgt.Core.DTOs.Request
{
    public class CreateEmployeeDTO:BaseEmployeeModel
    {
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public int? Gender { get; set; }
        public DateTime? DOB { get; set; }
        //public int? PermanentAddressId { get; set; }
        //public int? CorrespondenceAddressId { get; set; }
        //public int? ContactDetailId { get; set; }
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
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public string UserId { get; set; }
        [Phone(ErrorMessage = "Please Enter valid Phone Number")]
        public string PrimaryPhone { get; set; }
        [Phone(ErrorMessage = "Please Enter valid Phone Number")]
        public string AlternatePhone { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter valid Email Address")]
        public string PrimaryEmail { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter valid Email Address")]
        public string AlternateEmail { get; set; }
        public int Designation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
    public class BaseEmployeeModel
    {
        public int? EmployeeId { get; set; }
    }
}
