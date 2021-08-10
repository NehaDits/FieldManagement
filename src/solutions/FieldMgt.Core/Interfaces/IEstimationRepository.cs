using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IEstimationRepository
    {
        Task<ClientContact> CreateClientContactAsync(AddClientContactDTO model);
        IEnumerable<ClientContactResponseDTO> GetClientContactList();
        ClientContactResponseDTO GetClientContactbyIdAsync(int id);
        Task UpdateClientContact(UpdateClientContactDTO clientContact);
        Estimation DeleteClientContact(int clientContactId, string deletedBy);
    }
}
