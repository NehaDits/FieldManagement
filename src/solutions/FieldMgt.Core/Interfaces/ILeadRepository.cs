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
        LeadResponseDTO GetLeadbyIdAsync(int id);
        Task UpdateLeadStatusAsync(UpdateLeadDTO lead);
        void UpdateLeadStatus(int Id, int Status, string modifiedBy);
    }
}
