using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FieldMgt.Core.DTOs.Response
{
    public class LeadContactReponseDTO
    {
        public string Name { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string PermaAddress1 { get; set; }
        public string PermaAddress2 { get; set; }
        public string PermaCity { get; set; }
        public string PermaCountry { get; set; }
        public string CoresAddress1 { get; set; }
        public string CoresAddress2 { get; set; }
        public string CoresCity { get; set; }
        public string CoresCountry { get; set; }
        public string LeadName { get; set; }
    }
}
