using Microsoft.AspNetCore.Mvc;
using FieldMgt.Core.UOW;
using AutoMapper;
using FieldMgt.Core.DomainModels;
using System.Collections.Generic;
using FieldMgt.Core.DTOs.Request;
using System.Threading;
using FieldMgt.Repository.Enums;
using System.Net;
using Microsoft.AspNetCore.Http;
using FieldMgt.Core.DTOs.Response;
using System.Threading.Tasks;

namespace FieldMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadContactController : BaseController
    {
        private readonly IUnitofWork _uow;
        private readonly IMapper _mapper;
        public LeadContactController(IUnitofWork uow, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _uow = uow;
            _mapper = mapper;
        }
        [Route("AddContact")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateLeadContactAsync(CreateLeadContactDTO model)
        {
            var addClientContact = _mapper.Map<CreateLeadContactDTO, AddLeadContactDTO>(model);
            addClientContact.CreatedBy = GetUserId();
            addClientContact.CreatedOn = System.DateTime.Now;
            addClientContact.IsActive = true;
            return BaseResult(await _uow.LeadContactRepositories.CreateLeadContactAsync(addClientContact));
        }
        [Route("GetList")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IEnumerable<LeadContactReponseDTO> GetLeadContactsAsync()
        {
            return _uow.LeadContactRepositories.GetLeadsAsync();
        }
        [Route("ById/{id}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetLeadByIdAsync(int id)
        {
            var result = _uow.LeadContactRepositories.GetLeadContactbyIdAsync(id);
            if (result == null)
            {
                return BadRequest(ResponseMessages.LeadContactNotExist);
            }
            return Ok(result);
        }
        [Route("Update")]
        [HttpPatch]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task UpdateLeadStatusAsync(LeadContact leadContact)
        {
            var updated = _uow.LeadContactRepositories.UpdateLeadContactStatusAsync(leadContact);
            await _uow.SaveAsync();
        }
        [Route("Delete/{Id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteLead(int Id)
        {
            string deletedBy = GetUserId();
            _uow.LeadContactRepositories.DeleteLeadContact(Id, deletedBy);
            return BaseResult(await _uow.SaveAsync());
        }
    }
}
