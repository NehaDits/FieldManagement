using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IServiceProviderLocationRepository
    {
        Task<ServiceProviderLocation> CreateServiceProviderLocationAsync(CreateServiceProviderLocationDTO model);
        IEnumerable<ServiceProviderLocationListDTO> GetServiceProviderLocation();
        ServiceProviderListDTO GetServiceProviderLocationbyId(int serviceProviderId);
        ServiceProviderLocation DeleteServiceProviderLocation(int serviceProviderLocationId, string deletedBy);
        Task UpdateServiceProviderLocationAsync(UpdateServiceProviderDTO model);
    }
}
