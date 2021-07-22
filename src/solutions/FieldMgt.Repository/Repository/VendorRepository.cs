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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task CreateVendorAsync(Vendor model) => await InsertAsync(model);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vendor> GetVendorsAsync() => _dbContext.Vendors.Where(a => a.IsDeleted == true).ToList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Vendor GetVendorbyIdAsync(int id) => _dbContext.Vendors.FirstOrDefault(l => l.VendorId == id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendor"></param>
        /// <returns></returns>
        public async Task<Vendor> UpdateVendorStatusAsync(Vendor vendor) => await SingleAsync<Vendor>("sp_UpdateVendorDetail", vendor);
    }
}
