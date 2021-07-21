using System.Collections.Generic;
using System.Linq;
using FieldMgt.Core.Interfaces;
using FieldMgt.Core.DomainModels;
using FieldMgt.Repository.UOW;
using System.Threading.Tasks;
using System.Threading;

namespace FieldMgt.Repository.Repository
{
    public class VendorRepository : GenericRepository<Vendor>, IVendorRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public VendorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateVendorAsync(Vendor model) => await InsertAsync(model);
        public IEnumerable<Vendor> GetVendorsAsync() => _dbContext.Vendors.Where(a => a.IsDeleted == true).ToList();
        public Vendor GetVendorbyIdAsync(int id) => _dbContext.Vendors.FirstOrDefault(l => l.VendorId == id);
        public async Task<Vendor> UpdateVendorStatusAsync(Vendor vendor) => await SingleAsync<Vendor>("sp_UpdateVendorDetail", vendor);
    }
}
