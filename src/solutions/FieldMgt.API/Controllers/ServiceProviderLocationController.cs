using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using FieldMgt.Core.UOW;
using FieldMgt.Repository.Enums;
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
    public class ServiceProviderLocationController : BaseController
    {
        private readonly IUnitofWork _uow;
        public ServiceProviderLocationController(IUnitofWork uow, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _uow = uow;
        }
        [HttpPost]
        [Route("AddServiceProviderLocation")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateServiceProviderLocation([FromBody] CreateServiceProviderLocationDTO model)
        {
            try
            {
                model.CreatedBy = GetUserId();
                model.CreatedOn = System.DateTime.Now;
                return BaseResult(await _uow.ServiceProviderLocationRepositories.CreateServiceProviderLocationAsync(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Route("ListByServiceProvider/{serviceProviderId}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<ServiceProviderLocationListDTO>), StatusCodes.Status200OK)]
        public IEnumerable<ServiceProviderLocationListDTO> GetServiceProviderLocation(int serviceProviderId) => _uow.ServiceProviderLocationRepositories.GetServiceProviderLocation(serviceProviderId);
        [Route("ByLocationId/{id}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServiceProviderLocationListDTO), StatusCodes.Status200OK)]
        public ServiceProviderLocationListDTO GetServiceProviderLocationbyId(int id)
        {
            var result = _uow.ServiceProviderLocationRepositories.GetServiceProviderLocationbyId(id);
            return result;
        }
        [Route("UpdateServiceProviderLocation")]
        [HttpPatch]
        [ProducesResponseType(typeof(ServiceProviderLocation), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task UpdateServiceProviderAsync(UpdateServiceProviderLocationDTO model)
        {
            model.ModifiedBy = GetUserId();
            model.ModifiedOn = System.DateTime.Now;
            await _uow.ServiceProviderLocationRepositories.UpdateServiceProviderLocationAsync(model);
        }
        [Route("Delete/{Id}")]
        [HttpPatch]
        [ProducesResponseType(typeof(ServiceProviderLocation), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteServiceProviderLocation(int Id)
        {
            var deletedBy = GetUserId();
            var serviceProvider = _uow.ServiceProviderLocationRepositories.DeleteServiceProviderLocation(Id, deletedBy);
            var result = await _uow.SaveAsync();
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(ResponseMessages.ServiceProviderLocationNotDeleted);
            }

        }
        [Route("DeleteByServiceProvider/{Id}")]
        [HttpPatch]
        [ProducesResponseType(typeof(ServiceProviderLocation), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteServiceProviderLocationByServiceProvider(int Id)
        {
            var deletedBy = GetUserId();
            _uow.ServiceProviderLocationRepositories.DeleteServiceProviderLocationByServiceProvider(Id, deletedBy);
            var result = await _uow.SaveAsync();
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(ResponseMessages.ServiceProviderLocationNotDeleted);
            }

        }
    }
}
