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
    public class ServiceProviderController : BaseController
    {
        private readonly IUnitofWork _uow;
        public ServiceProviderController(IUnitofWork uow, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _uow = uow;
        }
        [HttpPost]
        [Route("AddServiceProvider")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateServiceProvider([FromBody] CreateServiceProviderDTO model)
        {
            try
            {
                model.CreatedBy =GetUserId();
                model.CreatedOn = System.DateTime.Now;   
                return BaseResult(await _uow.ServiceProviderRepositories.CreateServiceProviderAsync(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Route("List")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<ServiceProviderListDTO>), StatusCodes.Status200OK)]
        public IEnumerable<ServiceProviderListDTO> GetServiceProvider() => _uow.ServiceProviderRepositories.GetServiceProvider();
        [Route("ById/{id}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServiceProviderListDTO), StatusCodes.Status200OK)]
        public ServiceProviderListDTO GetServiceProviderbyId(int id)
        {
            var result = _uow.ServiceProviderRepositories.GetServiceProviderbyId(id);
            return result;
        }
        [Route("UpdateServiceProvider")]
        [HttpPatch]
        [ProducesResponseType(typeof(ServiceProvider), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task UpdateServiceProviderAsync(UpdateServiceProviderDTO model)
        {
            model.ModifiedBy = GetUserId();
            model.ModifiedOn = System.DateTime.Now;
            await _uow.ServiceProviderRepositories.UpdateServiceProviderAsync(model);            
        }
        [Route("Delete/{serviceProviderId}")]
        [HttpPatch]
        [ProducesResponseType(typeof(Staff), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteServiceProvider(int serviceProviderId)
        {
            var deletedBy = GetUserId();
            var serviceProvider = _uow.ServiceProviderRepositories.DeleteServiceProvider(serviceProviderId, deletedBy);
            var result = await _uow.SaveAsync();
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(ResponseMessages.ServiceProviderNotDeleted);
            }

        }
    }
}
