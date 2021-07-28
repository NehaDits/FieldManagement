using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Request
{
    public class CreateServiceProviderDTO
    {
        public string ServiceProviderName { get; set; }
        public string ServiceProviderIncharge { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        [StringLength(100, MinimumLength = 5)]
        public string Address { get; set; }
        public int City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public string ZipCode { get; set; }
        public string PrimaryPhone { get; set; }
        public string AlternatePhone { get; set; }
        public string PrimaryEmail { get; set; }
        public string AlternateEmail { get; set; }
        public string CreatedBy {get;set;}
        public DateTime? CreatedOn {get;set;}
    }
}
