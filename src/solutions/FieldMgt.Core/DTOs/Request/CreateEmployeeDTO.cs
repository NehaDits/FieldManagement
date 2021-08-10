using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FieldMgt.Core.DTOs.Request
{
    public class CreateEmployeeDTO
    {
        [NoMap]
        public string Email { get; set; }
        [NoMap]
        public string Password { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public int? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string PermanentAddress { get; set; }
        public int PermanentCity { get; set; }
        public int PermanentState { get; set; }
        public int PermanentCountry { get; set; }
        public string PermanentZipCode { get; set; }
        public string CorrespondenceAddress { get; set; }
        public int CorrespondenceCity { get; set; }
        public int CorrespondenceState { get; set; }
        public int CorrespondenceCountry { get; set; }
        public string CorrespondenceZipCode { get; set; }
        public string PrimaryPhone { get; set; }
        public string AlternatePhone { get; set; }
        public string PrimaryEmail { get; set; }
        public string AlternateEmail { get; set; }
        public int Designation { get; set; }        
    }
    public class NoMapAttribute:System.Attribute
    {

    }
    
}
