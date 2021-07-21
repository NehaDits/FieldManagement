using System.Collections.Generic;
using System.Threading.Tasks;
using FieldMgt.Core.DomainModels;

namespace FieldMgt.Core.Interfaces
{
    public interface ILeadRepository
    {
        Task CreateLeadAsync(Lead model);
        IEnumerable<Lead> GetLeadsAsync();
        Lead GetLeadbyIdAsync(int id);
        Lead UpdateLeadStatusAsync(Lead lead);
    }
}
