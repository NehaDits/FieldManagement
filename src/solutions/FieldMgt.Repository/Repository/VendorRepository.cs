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
using AutoMapper;


namespace FieldMgt.Repository.Repository
{
    public class VendorRepository : GenericRepository<Vendor>, IVendorRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
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
        public async Task CreateVendorAsync(Vendor model) => await SingleAsync<Vendor>(StoreProcedures.SaveVendorDetail, model); //=> await InsertAsync(model);

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
        public async Task<Vendor> UpdateVendorStatusAsync(Vendor vendor) => await SingleAsync<Vendor>(StoreProcedures.UpdateVendorDetail, vendor);

        /// <summary>
        /// To save the vendor details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> Save(CreateVendorDTO model)
        {
            CreateContactDetailDTO createContactDetailDTO = _mapper.Map<CreateVendorDTO, CreateContactDetailDTO>(model);
            Vendor vendor = _mapper.Map<CreateVendorDTO, Vendor>(model);
            var addressResponse = await _unitOfWork.AddressRepositories.SaveAddressAsync(model);
            var contactDetailResponse = await _unitOfWork.ContactDetailRepositories.SaveContactDetails(createContactDetailDTO);
            vendor.PermanentAddressId = addressResponse.AddressDetailId;
            vendor.ContactDetailId = contactDetailResponse.ContactDetailId;
            await _unitOfWork.VendorRepositories.CreateVendorAsync(vendor);
            return await _unitOfWork.SaveAsync();
        }
    }
}
