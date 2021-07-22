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
        /// <summary>
        /// Create lead contact
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task CreateLeadContactAsync(LeadContact model) => await InsertAsync(model);
        /// <summary>
        /// Get particular record of lead contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LeadContact GetLeadContactbyIdAsync(int id) => GetById(id);
        /// <summary>
        /// Get the list of leadcontacts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LeadContact> GetLeadsAsync() => GetAll();
        /// <summary>
        /// Update the single record of lead contact
        /// </summary>
        /// <param name="leadContact"></param>
        /// <returns></returns>
        public LeadContact UpdateLeadContactStatusAsync(LeadContact leadContact) => Update(leadContact);
    }
}
