using Microsoft.AspNetCore.Mvc;
using FieldMgt.Core.UOW;
using AutoMapper;
using FieldMgt.Core.DomainModels;
using System.Collections.Generic;
using FieldMgt.Core.DTOs.Request;
using System.Threading;
using FieldMgt.Repository.Enums;
using System.Net;

namespace FieldMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadContactController : ControllerBase
    {
        private readonly IUnitofWork _uow;
        private readonly IMapper _mapper;
        public LeadContactController(IUnitofWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        [Route("AddContact")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateLeadContactAsync(CreateLeadContactDTO model,int leadId)
        {
            CreateLeadContactDTO modelDTO = new CreateLeadContactDTO();
            modelDTO.LeadId = leadId;
            modelDTO.LeadContactId = null;
            modelDTO.Name = model.Name;
            modelDTO.CoresAddress1 = model.CoresAddress1;
            modelDTO.CoresAddress2 = model.CoresAddress2;
            modelDTO.CoresCity = model.CoresCity;
            modelDTO.CoresCountry = model.CoresCountry;
            modelDTO.PermaAddress1 = model.PermaAddress1;
            modelDTO.PermaAddress2 = model.PermaAddress2;
            modelDTO.PermaCity = model.PermaCity;
            modelDTO.PermaCountry = model.PermaCountry;
            modelDTO.Phone = model.Phone;
            modelDTO.Gender = model.Gender;
            modelDTO.Email = model.Email;
            LeadContact payload = _mapper.Map<CreateLeadContactDTO, LeadContact>(modelDTO);
            _uow.LeadContactRepositories.CreateLeadContactAsync(payload);
            var result = _uow.SaveAsync();
            if (result.IsCompletedSuccessfully)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(ResponseMessages.LeadContactNotCreated);
            }
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
