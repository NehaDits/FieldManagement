using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.UOW;
using AutoMapper;
using FieldMgt.API.Infrastructure.Services;
using System.Threading.Tasks;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;

namespace FieldMgt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class LeadController : ControllerBase
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
        [Route("~/api/Lead/Create")]
        [HttpPost]
        //[Authorize(Policy = "Sales Operation")]
        public async Task<IActionResult> CreateLeadAsync(CreateLeadDTO model)
        {
            CreateLeadDTO modelDTO = new CreateLeadDTO();
            modelDTO.FirstName = model.FirstName;
            modelDTO.LastName = model.LastName;
            modelDTO.LeadDescription = model.LeadDescription;
            modelDTO.LeadContact = model.LeadContact;
            modelDTO.LeadSource = model.LeadSource;
            modelDTO.LeadStatus = model.LeadStatus;
            modelDTO.Gender = model.Gender;
            modelDTO.Address = model.Address;
            modelDTO.City = model.City;
            modelDTO.State = model.State;
            modelDTO.Country = model.Country;
            modelDTO.Zip = model.Zip;
            modelDTO.Email = model.Email;
            modelDTO.LeadStage = model.LeadStage;
            modelDTO.IsActive = true;
            modelDTO.CreatedBy = _currentUserService.GetUserId();
            modelDTO.CreatedOn = System.DateTime.Now;
            Lead payload = _mapper.Map<CreateLeadDTO, Lead>(modelDTO);
            await _uow.LeadServices.CreateLeadAsync(payload);
            var result = await _uow.SaveAsync1();
            if (result.Equals(1))
            {
                return Ok(result);//status code 200
            }
            else
            {
                return BadRequest("Lead can not be created");
            }
        }        
        [Route("~/api/Lead/GetList")]
        [HttpGet]        
        public IEnumerable<Lead> GetLeadsAsync()
        {
            return _uow.LeadServices.GetLeadsAsync();
        }
        [Route("~/api/Lead/ById{id}")]
        [HttpGet]
        public IActionResult GetLeadByIdAsync(int id)
        {
            var result= _uow.LeadServices.GetLeadbyIdAsync(id);
            if (result == null)
            {
                return BadRequest("Lead Contact doesnt exist");
            }
            return Ok(result);//status code 200
        }
        [Route("~/api/Lead/Update")]
        [HttpPatch]
        //[Authorize(Policy = "Operation Staff")]
        public Lead UpdateLeadStatusAsync(Lead lead)
        {
            var updatedLead= _uow.LeadServices.UpdateLeadStatusAsync(lead);
            _uow.SaveAsync();
            return updatedLead;
        }
    }
}
