using System.Collections.Generic;
using System.Linq;
using FieldMgt.Core.Interfaces;
using FieldMgt.Core.DomainModels;
using FieldMgt.Repository.UOW;
using System.Threading.Tasks;
using System.Threading;

namespace FieldMgt.Repository.Repository
{
    public class LeadRepository : GenericRepository<Lead>, ILeadRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LeadRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// To Create lead 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task CreateLeadAsync(Lead model) => await InsertAsync(model);

        /// <summary>
        /// Get the list of leads
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Lead> GetLeadsAsync() => GetAll();

        /// <summary>
        /// Get the single records of lead
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Lead GetLeadbyIdAsync(int id) => _dbContext.Leads.FirstOrDefault(l => l.LeadId == id);

        /// <summary>
        /// Update the single records of leads
        /// </summary>
        /// <param name="lead"></param>
        /// <returns></returns>
        public Lead UpdateLeadStatusAsync(Lead lead) => Update(lead);
    }
}
