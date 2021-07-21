using System.Collections.Generic;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs;
using FieldMgt.Core.Interfaces;
using FieldMgt.Repository.UOW;

namespace FieldMgt.Repository.Repository
{
    public class LeadContactRepository :GenericRepository<LeadContact>, ILeadContactRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LeadContactRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateLeadContactAsync(LeadContact model)
        {
            InsertAsync(model);            
        }
        public LeadContact GetLeadContactbyIdAsync(int id)
        {
            var leadContact=GetById(id);
            return leadContact;           
        }
        public IEnumerable<LeadContact> GetLeadsAsync()
        {
            return GetAll();
        }
        public LeadContact UpdateLeadContactStatusAsync(LeadContact leadContact)
        {
            return Update(leadContact);
        }
    }
}
