using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.UOW;
using System.Threading.Tasks;
using FieldMgt.Core.DTOs.Request;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace FieldMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : BaseController
    {
        private readonly IUnitofWork _uow;
        public VendorController(IUnitofWork uow)
        {
            _uow = uow;
        }
        /// <summary>
        /// Use to create vendor
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateVendorAsync([FromBody] CreateVendorDTO model)
        => BaseResult(await _uow.VendorRepositories.Save(model));

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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ById{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Vendor), StatusCodes.Status200OK)]
        public IActionResult GetVendorByIdAsync(int id)
            => BaseResult<Vendor>(_uow.VendorRepositories.GetVendorbyIdAsync(id));

        /// <summary>
        /// Update the vendor details
        /// </summary>
        /// <param name="vendor"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("Update/{VendorId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Vendor), StatusCodes.Status200OK)]
        public async Task<IEnumerable<Vendor>> UpdateVendorStatusAsync(CreateVendorDTO vendor, int Vendorid)
        {
            vendor.VendorId = Vendorid;
            var vendorDetail= await _uow.VendorRepositories.UpdateVendorStatusAsync(vendor);
            return vendorDetail;
        }
            //=> BaseResult<Vendor>(await _uow.VendorRepositories.UpdateVendorStatusAsync(vendor));

        [HttpPost]
        [Route("test")]
        public async Task<IActionResult> CreateVendor([FromBody] CreateVendorDTO model)
        { 
            var res= await _uow.VendorRepositories.AddVendor(model);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteVendor/VendorId")]
        public async Task<Vendor> DeleteVendor(int vendorId)
        {
            var deletedBy = GetUserId();
            return await _uow.VendorRepositories.DeleteVendor(vendorId, deletedBy);
        }
    }
}
