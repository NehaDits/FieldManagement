using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs;
using FieldMgt.Core.Interfaces;
using FieldMgt.Repository.UOW;

namespace FieldMgt.Repository.Repository
{
    public class LeadContactRepository : GenericRepository<LeadContact>, ILeadContactRepository
    {
        public LeadContactRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task CreateLeadContactAsync(LeadContact model) => await InsertAsync(model);
        public LeadContact GetLeadContactbyIdAsync(int id) => GetById(id);
        public IEnumerable<LeadContact> GetLeadsAsync() => GetAll();
        public LeadContact UpdateLeadContactStatusAsync(LeadContact leadContact) => Update(leadContact);
    }
}
