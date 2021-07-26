using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FieldMgt.Core.DTOs.Request
{
    public class UpdateStaffDTO:BaseStaffModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Gender { get; set; }
        public DateTime? DOB { get; set; }
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
        public string PrimaryPhone { get; set; }
        public string AlternatePhone { get; set; }
        public string PrimaryEmail { get; set; }
        public string AlternateEmail { get; set; }
        public int Designation { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class BaseStaffModel
    {
        public int? StaffId { get; set; }
    }
}