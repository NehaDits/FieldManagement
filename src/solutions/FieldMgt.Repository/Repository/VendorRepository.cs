using System.Collections.Generic;
using System.Linq;
using FieldMgt.Core.Interfaces;
using FieldMgt.Core.DomainModels;
using FieldMgt.Repository.UOW;
using System.Threading.Tasks;

namespace FieldMgt.Repository.Repository
{
    public class VendorRepository : GenericRepository<Vendor>, IVendorRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public VendorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateVendorAsync(Vendor model)
        {
            await InsertAsync(model);
        }
        public IEnumerable<Vendor> GetVendorsAsync()
        {
            var vendors = _dbContext.Vendors.Where(a => a.IsDeleted == true).ToList();
            return vendors;
        }
        public Vendor GetVendorbyIdAsync(int id)
        {
            var result = _dbContext.Vendors.FirstOrDefault(l => l.VendorId == id);
            return result;
        }
        public async Task<Vendor> UpdateVendorStatusAsync(Vendor vendor)
        {
            var response = await SingleAsync<Vendor>("sp_UpdateVendorDetail", vendor);
            return response;
        }
    }
}
