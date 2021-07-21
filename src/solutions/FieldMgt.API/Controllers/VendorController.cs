using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.UOW;
using System.Threading.Tasks;
using FieldMgt.Core.DTOs.Request;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading;

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

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateVendorAsync([FromBody] CreateVendorDTO model, CancellationToken cancellationToken)
            => BaseResult(await _uow.AddressRepositories.Save(model));

        [HttpGet]
        [Route("GetList")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<Vendor>), StatusCodes.Status200OK)]
        public IActionResult GetVendorAsync()
            => Ok(_uow.VendorRepositories.GetVendorsAsync());

        [HttpGet]
        [Route("ById{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Vendor), StatusCodes.Status200OK)]
        public IActionResult GetVendorByIdAsync(int id)
            => BaseResult<Vendor>(_uow.VendorRepositories.GetVendorbyIdAsync(id));

        [HttpPatch]
        [Route("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Vendor), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateVendorStatusAsync(Vendor vendor, CancellationToken cancellationToken)
            => BaseResult<Vendor>(await _uow.VendorRepositories.UpdateVendorStatusAsync(vendor));

    }
}
