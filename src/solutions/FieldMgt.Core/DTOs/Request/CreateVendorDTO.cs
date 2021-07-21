using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FieldMgt.Core.DTOs.Request
{
    public class CreateVendorDTO:BaseCreateVendorModel
    {
        public string VendorCompanyName { get; set; }
        public string VendorOwnerorMD { get; set; }
        public string VendorContactPersonName { get; set; }
        public string VendorGSTNumber { get; set; }
        public string VendorAccountNumber { get; set; }
        public string VendorIFSCCode { get; set; }
        public string VendorBankName { get; set; }
        public string VendorBankBranch { get; set; }
        public string ZipCode { get; set; }
        public int AddressType { get; set; }
        [StringLength(100, MinimumLength = 5)]
        public string PermanentAddress { get; set; }
        public int PermanentCity { get; set; }
        public int PermanentState { get; set; }
        public int PermanentCountry { get; set; }
        public string PermanentZipCode { get; set; }
        [Phone(ErrorMessage = "Please Enter valid Phone Number")]
        public string PrimaryPhone { get; set; }
        [Phone(ErrorMessage = "Please Enter valid Phone Number")]
        public string AlternatePhone { get; set; }
        [StringLength(100, MinimumLength = 8)]
        [EmailAddress(ErrorMessage = "Please Enter valid Email Address")]
        public string PrimaryEmail { get; set; }
        [StringLength(100, MinimumLength = 8)]
        [EmailAddress(ErrorMessage = "Please Enter valid Email Address")]
        public string AlternateEmail { get; set; }
        [DefaultValue(true)]
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
    public class BaseCreateVendorModel
    {
        public int? VendorId { get; set; }
        public int? PermanentAddressId { get; set; }
        public int? BillingAddressId { get; set; }
        public int? ContactDetailId { get; set; }
    }
}
