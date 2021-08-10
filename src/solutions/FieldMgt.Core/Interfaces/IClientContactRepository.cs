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
    public interface IClientContactRepository
    {
        Task<ClientContact> CreateClientContactAsync(AddClientContactDTO model);
        IEnumerable<ClientContactResponseDTO> GetClientContactList();
        ClientContactResponseDTO GetClientContactbyIdAsync(int id);
        Task UpdateClientContact(UpdateClientContactDTO clientContact);
        ClientContact DeleteClientContact(int clientContactId, string deletedBy);
    }
}
