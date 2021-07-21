using System;
using System.Linq;
using FieldMgt.Core.Interfaces;
using FieldMgt.Repository.UOW;
using System.Threading.Tasks;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Repository.Common.StoreProcedures;
namespace FieldMgt.Repository.Repository
{
    public class AddressDetailRepository : GenericRepository<AddressDetail>, IAddressDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AddressDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Save Vendor Address
        /// </summary>
        /// <param name="model">typeof CreateAddressDTO</param>
        /// <returns>It is returning AdressDetail object</returns>
        public async Task<AddressDetail> SaveAddress(CreateAddressDTO model) => await SingleAsync<AddressDetail>(StoreProcedures.SaveAddressDetail, model);

        /// <summary>
        /// Soft delete vendor address
        /// </summary>
        /// <param name="addressId">addressId</param>
        /// <param name="deletedBy">deletedBy</param>
        /// <returns>AddressDetail object</returns>
        public AddressDetail DeleteAddress(int addressId, string deletedBy)
        {
            try
            {
                AddressDetail address = _dbContext.AddressDetails.FirstOrDefault(a => a.AddressDetailId == addressId);
                address.IsDeleted = true;
                address.DeletedBy = deletedBy;
                address.DeletedOn = DateTime.Now;
                return Update(address);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
