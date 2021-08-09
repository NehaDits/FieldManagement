using AutoMapper;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
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
    public class JobOrderController : BaseController
    {
        private readonly IUnitofWork _uow;
        private readonly IMapper _mapper;
        public JobOrderController(IUnitofWork uow, IMapper mapper,IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _uow = uow;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("AddJobOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateJobOrder(CreateJobOrderRequestDTO model)
        {
            var jobOrder = _mapper.Map<CreateJobOrderRequestDTO, CreateJobOrderDTO>(model);
            jobOrder.CreatedBy = GetUserId();
            await _uow.JobOrderRepositories.CreateJobOrder(jobOrder);
            return BaseResult(await _uow.SaveAsync());
        }
        [Route("ListJobOrders")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<ServiceProviderListDTO>), StatusCodes.Status200OK)]
        public IEnumerable<JobOrderResponseDTO> GetJobOrderAsync()
        {
            return _uow.JobOrderRepositories.GetJobOrderAsync();
        }
        [Route("ByJobOrderId/{jobOrderId}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ServiceProviderListDTO), StatusCodes.Status200OK)]
        public JobOrderResponseDTO GetJobOrderById(int jobOrderId)
        {
            var result = _uow.JobOrderRepositories.GetJobOrderbyIdAsync(jobOrderId);
            return result;
        }
        [Route("UpdateJobOrder")]
        [HttpPatch]
        [ProducesResponseType(typeof(ServiceProvider), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public JobOrderResponseDTO UpdateJobOrder(UpdateJobOrderRequestDTO model)
        {
            var jobOrder = _mapper.Map<UpdateJobOrderRequestDTO, UpdateJobOrderDTO>(model);
            jobOrder.ModifiedBy = GetUserId();
            jobOrder.ModifiedOn = System.DateTime.Now;
            return _uow.JobOrderRepositories.UpdateJobOrderAsync(jobOrder);
        }
        [Route("Delete/{jobOrderId}")]
        [HttpPatch]
        [ProducesResponseType(typeof(Staff), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteJobOrder(int jobOrderId)
        {
            var deletedBy = GetUserId();
            var jobOrder = _uow.JobOrderRepositories.DeleteJobOrder(jobOrderId, deletedBy);
            return BaseResult(await _uow.SaveAsync());
        }        
    }
}
