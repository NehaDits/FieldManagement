using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Response
{
    public class StaffListDTO:BaseStaffModel
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string PermanentAddress { get; set; }
        public int PermanentCityId { get; set; }
        public int PermanentStateId { get; set; }
        public int PermanentCountryId { get; set; }
        public string PermanentCity { get; set; }
        public string PermanentState { get; set; }
        public string PermanentCountry { get; set; }
        public string PermanentZipCode { get; set; }
        public string CorrespondenceAddress { get; set; }
        public int CorrespondenceCityId { get; set; }
        public int CorrespondenceStateId { get; set; }
        public int CorrespondenceCountryId { get; set; }
        public string CorrespondenceCity { get; set; }
        public string CorrespondenceState { get; set; }
        public string CorrespondenceCountry { get; set; }
        public string CorrespondenceZipCode { get; set; }
        public bool IsActive { get; set; }
        public string PrimaryPhone { get; set; }
        public string AlternatePhone { get; set; }
        public string PrimaryEmail { get; set; }
        public string AlternateEmail { get; set; }
        public int? Designation { get; set; }
    }
    public class BaseStaffModel
    {
        public int? StaffId { get; set; }
    }
}
