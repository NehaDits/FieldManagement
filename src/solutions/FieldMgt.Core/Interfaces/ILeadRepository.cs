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
        Task<Lead> CreateLeadAsync(AddLeadDTO model);
        IEnumerable<LeadResponseDTO> GetLeadsAsync();
        LeadResponseDTO GetLeadbyIdAsync(int id);
        Task UpdateLeadAsync(UpdateLeadDTO lead);
        void UpdateLeadStatus(int Id, int Status, string modifiedBy);
    }
}
