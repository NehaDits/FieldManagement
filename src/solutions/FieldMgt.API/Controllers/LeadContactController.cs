using Microsoft.AspNetCore.Mvc;
using FieldMgt.Core.DTOs;
using FieldMgt.Core.UOW;
using AutoMapper;
using FieldMgt.Core.DomainModels;
using System.Collections.Generic;
using FieldMgt.API.Infrastructure.Services;
using FieldMgt.Core.DTOs.Request;

namespace FieldMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadContactController : ControllerBase
    {
        private readonly IUnitofWork _uow;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public LeadContactController(IUnitofWork uow, IMapper mapper, ICurrentUserService currentUserService)
        {
            _uow = uow;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        [Route("/api/LeadContact/AddContact")]
        [HttpPost]
        public IActionResult CreateLeadContactAsync(CreateLeadContactDTO model, int leadId)
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
                return BadRequest("Employee can not be created");
            }
        }
        [Route("~/api/LeadContact/List")]
        [HttpGet]
        public IEnumerable<LeadContact> GetLeadContactsAsync()
        {

            return _uow.LeadContactRepositories.GetLeadsAsync();
        }
        [Route("~/api/LeadContact/ById/{id}")]
        [HttpGet]
        public IActionResult GetLeadByIdAsync(int id)
        {
            var result = _uow.LeadContactRepositories.GetLeadContactbyIdAsync(id);
            if (result == null)
            {
                return BadRequest("Lead Contact doesnt exist");
            }
            return Ok(result);
        }
        [Route("~/api/LeadContact/Update")]
        [HttpPatch]
        public LeadContact UpdateLeadStatusAsync(LeadContact leadContact)
        {
            var updated = _uow.LeadContactRepositories.UpdateLeadContactStatusAsync(leadContact);
            _uow.SaveAsync();
            return updated;
        }
    }
}
