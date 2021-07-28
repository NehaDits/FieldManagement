using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
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
        public ServiceProviderController(IUnitofWork uow)
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
                //model.CreatedBy =GetUserId();
                model.CreatedOn = System.DateTime.Now;   
                return BaseResult(await _uow.ServiceProviderRepositories.CreateServiceProviderAsync(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Route("UpdateServiceProvider")]
        [HttpPatch]
        [ProducesResponseType(typeof(ServiceProvider), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task UpdateServiceProviderAsync(UpdateServiceProviderDTO model)
        {
            //model.ModifiedBy = GetUserId();
            model.ModifiedOn = System.DateTime.Now;
            await _uow.ServiceProviderRepositories.UpdateServiceProviderAsync(model);            
        }
        [Route("Delete/{serviceProviderId}")]
        [HttpPatch]
        [ProducesResponseType(typeof(Staff), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteServiceProvider(int serviceProviderId)
        {
            //var deletedBy = GetUserId();
            string deletedBy = "7ca0112a-8300-42bc-b805-7c756dc53456";
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
