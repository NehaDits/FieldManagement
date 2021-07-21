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
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task CreateLeadAsync(Lead model) => await InsertAsync(model);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Lead> GetLeadsAsync() => GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Lead GetLeadbyIdAsync(int id) => _dbContext.Leads.FirstOrDefault(l => l.LeadId == id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lead"></param>
        /// <returns></returns>
        public Lead UpdateLeadStatusAsync(Lead lead) => Update(lead);
    }
}
