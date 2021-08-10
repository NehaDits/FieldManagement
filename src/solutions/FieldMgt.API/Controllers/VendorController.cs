using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.UOW;
using System.Threading.Tasks;
using FieldMgt.Core.DTOs.Request;
using System.Net;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace FieldMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : BaseController
    {
        private readonly IUnitofWork _uow;
        private readonly IMapper _mapper;
        public VendorController(IUnitofWork uow, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(httpContextAccessor)
        {
            _uow = uow;
            _mapper = mapper;
        }
        /// <summary>
        /// Use to create vendor
        /// </summary>
        /// <paramname="model"></param>
        /// <paramname="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateVendorAsync([FromBody] CreateVendorDTO model)
        {
            var user = _mapper.Map<CreateVendorDTO, AddVendorDTO>(model);
            user.CreatedBy = GetUserId();
            user.CreatedOn = System.DateTime.Now;
            user.IsActive= true;
            return BaseResult(await _uow.VendorRepositories.Save(user));
        }

        /// <summary>
        /// Get vendor detail list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetList")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<Vendor>), StatusCodes.Status200OK)]
        public IActionResult GetVendorAsync()
            => Ok(_uow.VendorRepositories.GetVendorsAsync());

        /// <summary>
        /// Pass vendor id and returns single record of vendor
        /// </summary>
        /// <paramname="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ById/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Vendor), StatusCodes.Status200OK)]
        public IActionResult GetVendorByIdAsync(int id)
            => BaseResult<Vendor>(_uow.VendorRepositories.GetVendorbyIdAsync(id));

        /// <summary>
        /// Update the vendor details
        /// </summary>
        /// <paramname="vendor"></param>
        /// <paramname="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("Update/{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Vendor), StatusCodes.Status200OK)]
        public async Task<IEnumerable<Vendor>> UpdateVendorStatusAsync(CreateVendorDTO vendor, int Vendorid)
        {
            var user = _mapper.Map<CreateVendorDTO, UpdateVendorDTO>(vendor);
            user.CreatedBy = GetUserId();
            user.CreatedOn = System.DateTime.Now;
            var vendorDetail = await _uow.VendorRepositories.UpdateVendorStatusAsync(user);
            return vendorDetail;
        }

        /// <summary>
        /// Soft delete vendor 
        /// </summary>
        /// <paramname="vendorId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteVendor/{VendorId}")]
        public Vendor DeleteVendor(int vendorId)
        {
            var deletedBy = GetUserId();
            return _uow.VendorRepositories.DeleteVendor(vendorId, deletedBy);
        }
    }
}
