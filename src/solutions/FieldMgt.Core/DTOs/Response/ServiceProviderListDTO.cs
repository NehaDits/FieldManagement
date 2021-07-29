using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Response
{
    public class ServiceProviderListDTO:BaseServiceProviderModel
    {        
        public string ServiceProviderName { get; set; }        
        public string ServiceProviderIncharge { get; set; }        
        [StringLength(100, MinimumLength = 5)]
        public string Address { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string PrimaryPhone { get; set; }
        public string AlternatePhone { get; set; }
        public string PrimaryEmail { get; set; }
        public string AlternateEmail { get; set; }
    }
    public class BaseServiceProviderModel
    {
        public int? ServiceProviderID { get; set; }
    }

}
