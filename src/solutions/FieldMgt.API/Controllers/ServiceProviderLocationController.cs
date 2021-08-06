using AutoMapper;
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
        private readonly IMapper _mapper;
        public ServiceProviderLocationController(IUnitofWork uow, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _uow = uow;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("AddServiceProviderLocation")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateServiceProviderLocation([FromBody] CreateServiceProviderLocationRequestDTO model)
        {
            try
            {
                var serviceProviderLocation = _mapper.Map<CreateServiceProviderLocationRequestDTO, CreateServiceProviderLocationDTO>(model);
                serviceProviderLocation.CreatedBy = GetUserId();
                serviceProviderLocation.CreatedOn = System.DateTime.Now;
                return BaseResult(await _uow.ServiceProviderLocationRepositories.CreateServiceProviderLocationAsync(serviceProviderLocation));
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
        [Route("ListByServiceProviderLocationId/{serviceProviderLocationId}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServiceProviderLocationListDTO), StatusCodes.Status200OK)]
        public ServiceProviderLocationListDTO GetServiceProviderLocationbyId(int serviceProviderLocationId)
        {
            var result = _uow.ServiceProviderLocationRepositories.GetServiceProviderLocationbyId(serviceProviderLocationId);
            return result;
        }
        [Route("UpdateServiceProviderLocation")]
        [HttpPatch]
        [ProducesResponseType(typeof(ServiceProviderLocation), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task UpdateServiceProviderAsync(UpdateServiceProviderLocationRequestDTO model)
        {
            var serviceProviderLocation = _mapper.Map<UpdateServiceProviderLocationRequestDTO, UpdateServiceProviderLocationDTO>(model);
            serviceProviderLocation.ModifiedBy = GetUserId();
            serviceProviderLocation.ModifiedOn = System.DateTime.Now;
            await _uow.ServiceProviderLocationRepositories.UpdateServiceProviderLocationAsync(serviceProviderLocation);
        }
        [Route("Delete/{serviceProviderLocationId}")]
        [HttpPatch]
        [ProducesResponseType(typeof(ServiceProviderLocation), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteServiceProviderLocation(int serviceProviderLocationId)
        {
            var deletedBy = GetUserId();
            var serviceProvider = _uow.ServiceProviderLocationRepositories.DeleteServiceProviderLocation(serviceProviderLocationId, deletedBy);
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
        [Route("DeleteByServiceProvider/{serviceProviderId}")]
        [HttpPatch]
        [ProducesResponseType(typeof(ServiceProviderLocation), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteServiceProviderLocationByServiceProvider(int serviceProviderId)
        {
            var deletedBy = GetUserId();
            _uow.ServiceProviderLocationRepositories.DeleteServiceProviderLocationByServiceProvider(serviceProviderId, deletedBy);
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
