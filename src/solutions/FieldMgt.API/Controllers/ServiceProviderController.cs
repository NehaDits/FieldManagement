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
    public class ServiceProviderController : BaseController
    {
        private readonly IUnitofWork _uow;
        private readonly IMapper _mapper;
        public ServiceProviderController(IUnitofWork uow, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _uow = uow;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("AddServiceProvider")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateServiceProvider([FromBody] CreateServiceProviderRequestDTO model)
        {
            var serviceProvider = _mapper.Map<CreateServiceProviderRequestDTO, CreateServiceProviderDTO>(model);
            serviceProvider.CreatedBy =GetUserId();
            serviceProvider.CreatedOn = System.DateTime.Now;   
            return BaseResult(await _uow.ServiceProviderRepositories.CreateServiceProviderAsync(serviceProvider));
        }
        [Route("List")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<ServiceProviderListDTO>), StatusCodes.Status200OK)]
        public IEnumerable<ServiceProviderListDTO> GetServiceProvider() => _uow.ServiceProviderRepositories.GetServiceProvider();
        [Route("ByServiceProviderId/{serviceProviderId}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServiceProviderListDTO), StatusCodes.Status200OK)]
        public ServiceProviderListDTO GetServiceProviderbyId(int serviceProviderId)
        {
            var result = _uow.ServiceProviderRepositories.GetServiceProviderbyId(serviceProviderId);
            return result;
        }
        [Route("UpdateServiceProvider")]
        [HttpPatch]
        [ProducesResponseType(typeof(ServiceProvider), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task UpdateServiceProviderAsync(UpdateServiceProviderRequestDTO model)
        {
            var serviceProvider = _mapper.Map<UpdateServiceProviderRequestDTO, UpdateServiceProviderDTO>(model);
            serviceProvider.ModifiedBy = GetUserId();
            serviceProvider.ModifiedOn = System.DateTime.Now;
            await _uow.ServiceProviderRepositories.UpdateServiceProviderAsync(serviceProvider);            
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
