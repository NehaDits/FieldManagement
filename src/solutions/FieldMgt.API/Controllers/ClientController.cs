using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FieldMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IUnitofWork _uow;
        public ClientController(IUnitofWork uow)
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
        public async Task<IActionResult> CreateVendorAsync([FromBody] CreateClientDTO model)
        => BaseResult(await _uow.ClientRepositories.Save(model));

        /// <summary>
        /// Get vendor detail list
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[Route("GetList")]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(IEnumerable<Client>), StatusCodes.Status200OK)]
        //public IActionResult GetVendorAsync()
        //    => Ok(_uow.ClientRepositories.GetVendorsAsync());

        /// <summary>
        /// Pass vendor id and returns single record of vendor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ById/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        public IActionResult GetVendorByIdAsync(int id)
            => BaseResult<Client>(_uow.ClientRepositories.GetVendorbyIdAsync(id));

        /// <summary>
        /// Update the vendor details
        /// </summary>
        /// <param name="vendor"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("Update/{VendorId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        public async Task<IEnumerable<Client>> UpdateVendorStatusAsync(CreateClientDTO vendor, int Vendorid)
        {
            vendor.ClientSource = Vendorid;
            vendor.CreatedBy = GetUserId();
            var vendorDetail = await _uow.ClientRepositories.UpdateVendorStatusAsync(vendor);
            return vendorDetail;
        }
        //=> BaseResult<Vendor>(await _uow.VendorRepositories.UpdateVendorStatusAsync(vendor));

        /// <summary>
        /// Soft delete vendor 
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteVendor/{VendorId}")]
        public Client DeleteVendor(int vendorId)
        {
            var deletedBy = GetUserId();
            return _uow.ClientRepositories.DeleteVendor(vendorId, deletedBy);
        }
    }
}
