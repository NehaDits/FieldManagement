using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IServiceProviderRepository
    {
        Task<ServiceProvider> CreateServiceProviderAsync(CreateServiceProviderDTO model);
        IEnumerable<ServiceProvider> GetServiceProvider();
        Staff GetServiceProviderbyId(int id);
        ServiceProvider DeleteServiceProvider(int serviceProviderId, string deletedBy);
        Task UpdateServiceProviderAsync(UpdateServiceProviderDTO model);
    }
}
