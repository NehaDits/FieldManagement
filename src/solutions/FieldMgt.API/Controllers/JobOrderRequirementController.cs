using AutoMapper;
using FieldMgt.Core.DTOs;
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
    public class JobOrderRequirementController : BaseController
    {
        private readonly IUnitofWork _uow;
        private readonly IMapper _mapper;
        public JobOrderRequirementController(IUnitofWork uow, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _uow = uow;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("AddJobOrderRequirement")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateJobOrder(CreateJobOrderRequirementRequestDTO model)
        {
            var jobOrder = _mapper.Map<CreateJobOrderRequirementRequestDTO, CreateJobOrderRequirementDTO>(model);
            jobOrder.CreatedBy = GetUserId();
            await _uow.JobOrderRequirementRepositories.CreateJobOrderRequirement(jobOrder);
            return BaseResult(await _uow.SaveAsync());
        }
    }
}
