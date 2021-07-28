using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.UOW;
using AutoMapper;
using FieldMgt.API.Infrastructure.Services;
using System.Threading.Tasks;
using FieldMgt.Core.DTOs.Request;
using System.Threading;
using FieldMgt.Repository.Enums;
using System.Net;
using FieldMgt.API.Controllers;
using FieldMgt.Core.DTOs.Response;

namespace FieldMgt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class LeadController : BaseController
    {
        private readonly IUnitofWork _uow;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public LeadController(IUnitofWork uow, IMapper mapper, ICurrentUserService currentUserService)
        {
            _uow = uow;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        [Route("Create")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateLeadAsync(CreateLeadDTO model)=> BaseResult(await _uow.LeadServices.CreateLeadAsync(model));

        [Route("GetList")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IEnumerable<LeadResponseDTO> GetLeadsAsync()
        {
            return _uow.LeadServices.GetLeadsAsync();
        }
        [Route("ById/{id}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetLeadByIdAsync(int id)
        {
            var result= _uow.LeadServices.GetLeadbyIdAsync(id);
            if (result == null)
            {
                return BadRequest(ResponseMessages.LeadNotFound);
            }
            return Ok(result);
        }
        [Route("Update")]
        [HttpPatch]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task UpdateLeadStatusAsync(UpdateLeadDTO lead)=>  await _uow.LeadServices.UpdateLeadStatusAsync(lead);
    }
}
