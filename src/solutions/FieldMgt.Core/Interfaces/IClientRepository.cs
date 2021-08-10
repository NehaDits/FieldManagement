using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FieldMgt.Core.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<ClientResponseDTO> GetClientsAsync();
        ClientResponseDTO GetClientbyIdAsync(int id);
        Task<IEnumerable<Client>> UpdateClientStatusAsync(ClientResponseDTO lead);
        Task<Client> Save(CreateClientDTO model);
        Client DeleteClient(int ClientId, string deletedBy);
    }
}
