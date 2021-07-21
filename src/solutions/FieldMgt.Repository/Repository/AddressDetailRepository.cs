using System;
using System.Linq;
using FieldMgt.Core.Interfaces;
using FieldMgt.Repository.UOW;
using System.Threading.Tasks;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Repository.Common.StoreProcedures;
using FieldMgt.Core.UOW;
using AutoMapper;
using System.Threading;
using Dapper;

namespace FieldMgt.Repository.Repository
{
    public class AddressDetailRepository : GenericRepository<AddressDetail>, IAddressDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddressDetailRepository(ApplicationDbContext dbContext, IUnitofWork unitOfWork, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// Save Vendor Address
        /// </summary>
        /// <param name="model">typeof CreateAddressDTO</param>
        /// <returns>It is returning AdressDetail object</returns>
        public async Task<AddressDetail> SaveAddressAsync(CreateVendorDTO model)
        {
            CreateAddressDTO createAddressDTO = _mapper.Map<CreateVendorDTO, CreateAddressDTO>(model);
            return await SingleAsync<AddressDetail>(StoreProcedures.SaveAddressDetail, createAddressDTO);
        }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> Save(CreateVendorDTO model)
        {
            CreateContactDetailDTO createContactDetailDTO = _mapper.Map<CreateVendorDTO, CreateContactDetailDTO>(model);
            Vendor vendor = _mapper.Map<CreateVendorDTO, Vendor>(model);

            var addressResponse = await _unitOfWork.AddressRepositories.SaveAddressAsync(model);
            var conteactDetailResponse = await _unitOfWork.ContactDetailRepositories.SaveContactDetails(createContactDetailDTO);
            vendor.PermanentAddressId = addressResponse.AddressDetailId;
            vendor.ContactDetailId = conteactDetailResponse.ContactDetailId;
            await _unitOfWork.VendorRepositories.CreateVendorAsync(vendor);

            return await _unitOfWork.SaveAsync();

        }
    }
}
