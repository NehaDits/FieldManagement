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
using System.Data.Entity;
using Microsoft.Extensions.Logging;
using AutoMapper;
using FieldMgt.Core.DTOs.Response;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FieldMgt.Repository.Repository
{
    public class VendorRepository : GenericRepository<Vendor>, IVendorRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public VendorRepository(ApplicationDbContext dbContext, IUnitofWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(dbContext)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
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
        public IEnumerable<VendorResponseDTO> GetVendorsAsync()
        {
            string userid=_httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<VendorResponseDTO> vendorDetails = _dbContext.Vendors
                          .Join(_dbContext.AddressDetails, p => p.PermanentAddressId, pc => pc.AddressDetailId, (p, pc) => new { p, pc })
                          .Join(_dbContext.AddressDetails, a => a.p.BillingAddressId, ad => ad.AddressDetailId, (a, ad) => new { a, ad })
                          .Join(_dbContext.ContactDetails, cd => cd.a.p.ContactDetailId, c => c.ContactDetailId, (cd, c) => new { cd, c })
                          .Where(x => x.cd.a.p.IsActive == true)
                          .Select(m => new VendorResponseDTO
                          {
                              VendorAccountNumber = m.cd.a.p.VendorAccountNumber,
                              VendorBankBranch = m.cd.a.p.VendorBankBranch,
                              VendorBankName = m.cd.a.p.VendorBankName,
                              VendorCompanyName = m.cd.a.p.VendorCompanyName,
                              VendorContactPersonName = m.cd.a.p.VendorContactPersonName,
                              VendorGSTNumber = m.cd.a.p.VendorGSTNumber,
                              VendorIFSCCode = m.cd.a.p.VendorIFSCCode,
                              VendorOwnerorMD = m.cd.a.p.VendorOwnerorMD,
                              VendorId = m.cd.a.p.VendorId,
                              AlternateEmail = m.c.AlternateEmail,
                              PrimaryEmail = m.c.PrimaryEmail,
                              AlternatePhone = m.c.AlternatePhone,
                              PrimaryPhone = m.c.PrimaryPhone,
                              CorrespondenceAddress = m.cd.ad.Address,
                              CorrespondenceCity = m.cd.ad.CityId,
                              CorrespondenceCountry = m.cd.ad.CountryId,
                              CorrespondenceState = m.cd.ad.StateId,
                              CorrespondenceZipCode = m.cd.ad.ZipCode,
                              PermanentZipCode = m.cd.ad.ZipCode,
                              PermanentAddress = m.cd.ad.Address,
                              PermanentCity = m.cd.ad.CityId,
                              PermanentCountry = m.cd.ad.CountryId,
                              PermanentState = m.cd.ad.StateId
                          });
            return vendorDetails;
        }

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
            Vendor detail = _mapper.Map<CreateVendorDTO, Vendor>(model);
            try
            {
                return await CommandAsync<Vendor>(StoreProcedures.UpdateVendorDetail, detail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorId"></param>
        /// <param name="deletedBy"></param>
        /// <returns></returns>
        public Vendor DeleteVendor(int vendorId, string deletedBy)
        {
            try
            {
                var currentVendor =_dbContext.Vendors.SingleOrDefault(a => a.VendorId == vendorId);
                currentVendor.IsDeleted = true;
                currentVendor.DeletedBy = deletedBy;
                currentVendor.DeletedOn = System.DateTime.Now;
                int permanentAddress = (int)currentVendor.PermanentAddressId;
                int correspondenceAddress = (int)currentVendor.BillingAddressId;
                int contactDetail = (int)currentVendor.ContactDetailId;
                _unitOfWork.AddressRepositories.DeleteAddress(permanentAddress, deletedBy);
                _unitOfWork.AddressRepositories.DeleteAddress(correspondenceAddress, deletedBy);
                _unitOfWork.ContactDetailRepositories.DeleteContact(contactDetail, deletedBy);
                return Update(currentVendor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
