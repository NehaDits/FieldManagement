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
        Task<int> CreateServiceProviderLocationAsync(CreateServiceProviderLocationDTO model);
        IEnumerable<ServiceProviderLocationListDTO> GetServiceProviderLocation(int serviceProviderId);
        ServiceProviderLocationListDTO GetServiceProviderLocationbyId(int Id);        
        Task UpdateServiceProviderLocationAsync(UpdateServiceProviderLocationDTO model);
        ServiceProviderLocation DeleteServiceProviderLocation(int Id, string deletedBy);
        void DeleteServiceProviderLocationByServiceProvider(int serviceProviderId, string deletedBy);
    }
}
