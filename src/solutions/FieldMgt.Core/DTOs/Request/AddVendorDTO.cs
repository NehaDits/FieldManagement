﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Request
{
    public class AddVendorDTO
    {
        public string VendorCompanyName { get; set; }
        public string VendorOwnerorMD { get; set; }
        public string VendorContactPersonName { get; set; }
        public string VendorGSTNumber { get; set; }
        public string VendorAccountNumber { get; set; }
        public string VendorIFSCCode { get; set; }
        public string VendorBankName { get; set; }
        public string VendorBankBranch { get; set; }
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
        public string PrimaryPhone { get; set; }
        public string AlternatePhone { get; set; }
        [StringLength(100, MinimumLength = 8)]
        public string PrimaryEmail { get; set; }
        [StringLength(100, MinimumLength = 8)]
        public string AlternateEmail { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
