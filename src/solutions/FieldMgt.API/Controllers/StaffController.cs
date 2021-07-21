using AutoMapper;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.UOW;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FieldMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IUnitofWork _uow;
        public StaffController(IUnitofWork uow)
        {
            _uow = uow;
        }
        
        [Route("~/api/Staff/List")]
        [HttpGet]
        public IEnumerable<Staff> GetStaff() => _uow.StaffRepositories.GetStaff();
        [Route("~/api/Staff/ById/{id}")]
        [HttpGet]
        public IActionResult GetStaffbyId(int id)
        {
            var result = _uow.StaffRepositories.GetStaffbyId(id);
            if (result == null)
            {
                return BadRequest("Staff Member doesnt exist");
            }
            return Ok(result);
        }    
        [Route("~/api/Staff/Update")]
        [HttpPatch]
        public async Task<IActionResult> UpdateStaffAsync(Staff model)
        {
            _uow.StaffRepositories.UpdateStaffAsync(model);
            var result = await _uow.SaveAsync();
            if (result.Equals(1))
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("User can not be deleted");
            }

        }
    }
}
