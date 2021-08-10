using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.UOW;
using AutoMapper;
using System.Threading.Tasks;
using FieldMgt.Core.DTOs.Request;
using System.Threading;
using FieldMgt.Repository.Enums;
using System.Net;
using FieldMgt.API.Controllers;
using FieldMgt.Core.DTOs.Response;
using Microsoft.AspNetCore.Http;

namespace FieldMgt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeadController : BaseController
    {
        private readonly IUnitofWork _uow;
        private readonly IMapper _mapper;
        public LeadController(IUnitofWork uow, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _uow = uow;
            _mapper = mapper;
        }
        [Route("Create")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateLeadAsync(CreateLeadDTO model)//=> BaseResult(await _uow.LeadServices.CreateLeadAsync(model));
        {
            var addClientContact = _mapper.Map<CreateLeadDTO, AddLeadDTO>(model);
            addClientContact.CreatedBy = GetUserId();
            addClientContact.CreatedOn = System.DateTime.Now;
            addClientContact.IsActive = true;
            return BaseResult(await _uow.LeadServices.CreateLeadAsync(addClientContact));
        }

        [Route("GetList")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IEnumerable<LeadResponseDTO> GetLeadsAsync()
        {
            string userid = GetUserId();
            return _uow.LeadServices.GetLeadsAsync();
        }
        [Route("ById/{id}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetLeadByIdAsync(int id)
        {
            var result = _uow.LeadServices.GetLeadbyIdAsync(id);
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
        public async Task UpdateLeadStatusAsync(LeadUpdateDTO lead)
        {
            var addClientContact = _mapper.Map<LeadUpdateDTO, UpdateLeadDTO>(lead);
            addClientContact.ModifiedBy = GetUserId();
            addClientContact.ModifiedOn = System.DateTime.Now;
            addClientContact.IsActive = true;
            await _uow.LeadServices.UpdateLeadAsync(addClientContact);
        }

        [Route("UpdateLeadStatus/{Id}/{Status}")]
        [HttpPatch]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateLeadStatus(int Id, int Status)
        {
            string modifiedBy = GetUserId();
            _uow.LeadServices.UpdateLeadStatus(Id, Status, modifiedBy);
            return BaseResult(await _uow.SaveAsync());
        }

        [Route("Delete/{Id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteLead(int Id)
        {
            var deletedBy = GetUserId();
            _uow.LeadServices.DeleteLead(Id, deletedBy);
            return BaseResult(await _uow.SaveAsync());
        }
        [Route("UpdateLeadStage/{Id}/{Stage}")]
        [HttpPatch]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateLeadStage(int Id, int Stage)
        {
            string modifiedBy = GetUserId();
            _uow.LeadServices.UpdateLeadStage(Id, Stage, modifiedBy);
            return BaseResult(await _uow.SaveAsync());
        }
    }
}
