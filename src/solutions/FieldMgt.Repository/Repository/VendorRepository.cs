using System.Collections.Generic;
using System.Linq;
using FieldMgt.Core.Interfaces;
using FieldMgt.Core.DomainModels;
using FieldMgt.Repository.UOW;
using System.Threading.Tasks;
using System.Threading;
using FieldMgt.Repository.Common.StoreProcedures;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.UOW;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace FieldMgt.Repository.Repository
{
    public class VendorRepository : GenericRepository<Vendor>, IVendorRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public VendorRepository(ApplicationDbContext dbContext, IUnitofWork unitOfWork, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// To save the vendor details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public async Task CreateVendorAsync(Vendor model) => await SingleAsync<Vendor>(StoreProcedures.SaveVendorDetail, model); //=> await InsertAsync(model);

        /// <summary>
        /// To get the details of vendor
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vendor> GetVendorsAsync() => _dbContext.Vendors.Where(a => a.IsDeleted == true).ToList();

        /// <summary>
        /// To get the sibgle records
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Vendor GetVendorbyIdAsync(int id) => _dbContext.Vendors.FirstOrDefault(l => l.VendorId == id);

        /// <summary>
        /// To update the vendor details
        /// </summary>
        /// <param name="vendor"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Vendor>> UpdateVendorStatusAsync(CreateVendorDTO vendor) => await CollectionsAsync<Vendor>(StoreProcedures.UpdateVendorDetail, vendor);

        /// <summary>
        /// To save the vendor details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Vendor> Save(CreateVendorDTO model)
        {
            try
            {
                return await CommandAsync<Vendor>(StoreProcedures.UpdateVendorDetail, model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
             }
        }
        public async Task<Vendor> DeleteVendor(int vendorId, string deletedBy)
        {
            try
            {
                var currentVendor = _dbContext.Vendors.SingleOrDefault(a => a.VendorId == vendorId);
                currentVendor.IsDeleted = true;
                currentVendor.DeletedBy = deletedBy;
                currentVendor.DeletedOn = System.DateTime.Now;
                return Update(currentVendor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> AddVendor(CreateVendorDTO model)
        {
            Vendor vendor = new Vendor();
            vendor.VendorContactPersonName = model.VendorContactPersonName;
            vendor.VendorCompanyName = model.VendorCompanyName;
            vendor.BillingAddressId = 1;
            vendor.VendorBankName = model.VendorBankName;
            vendor.VendorBankBranch = model.VendorBankBranch;
            return 0;
        }
    }
}
