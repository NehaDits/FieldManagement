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
        public IActionResult CreateLeadContactAsync(CreateLeadContactDTO model)
        {
            model.CreatedBy = GetUserId();
            return BaseResult(_uow.LeadContactRepositories.CreateLeadContactAsync(model));
        }
        [Route("List")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IEnumerable<LeadContact> GetLeadContactsAsync()
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
        public LeadContact UpdateLeadStatusAsync(LeadContact leadContact)
        {
            var updated = _uow.LeadContactRepositories.UpdateLeadContactStatusAsync(leadContact);
            _uow.SaveAsync();
            return updated;
        }
    }
}
