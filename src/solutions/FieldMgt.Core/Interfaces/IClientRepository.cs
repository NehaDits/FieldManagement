using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IClientRepository
    {
        //IEnumerable<VendorResponseDTO> GetVendorsAsync();
        Client GetVendorbyIdAsync(int id);
        Task<IEnumerable<Client>> UpdateVendorStatusAsync(CreateClientDTO lead);
        Task<Client> Save(CreateClientDTO model);
        Client DeleteVendor(int vendorId, string deletedBy);
    }
}
