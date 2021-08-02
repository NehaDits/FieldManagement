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
    public class ServiceProviderLocationController : BaseController
    {
        private readonly IUnitofWork _uow;
        public ServiceProviderLocationController(IUnitofWork uow)
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
                //model.CreatedBy = GetUserId();
                model.CreatedOn = System.DateTime.Now;
                return BaseResult(await _uow.ServiceProviderLocationRepositories.CreateServiceProviderLocationAsync(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
