using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Response
{
    public class ServiceProviderLocationListDTO:BaseServiceProviderLocationModel
    {
        public string ServiceProviderLocationName { get; set; }
        public string ServiceProviderLocationIncharge { get; set; }        
        public int ServiceProviderId { get; set; }
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
    public class BaseServiceProviderLocationModel
    {
        public int? ServiceProviderLocationID { get; set; }
    }
}
