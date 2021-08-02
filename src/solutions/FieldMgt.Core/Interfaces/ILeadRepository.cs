using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;

namespace FieldMgt.Core.Interfaces
{
    public interface ILeadRepository
    {
        Task<Lead> CreateLeadAsync(CreateLeadDTO model);
        IEnumerable<LeadResponseDTO> GetLeadsAsync();
        IEnumerable<LeadResponseDTO> GetLeadbyIdAsync(int id);
        Task UpdateLeadStatusAsync(UpdateLeadDTO lead);
        Task<Lead> UpdateLeadStatus(int Id, int Status, string modifiedBy);
    }
}
