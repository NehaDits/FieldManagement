using FieldMgt.Core.DomainModels;
using FieldMgt.Core.UOW;
using FieldMgt.Repository.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
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
        
        [Route("List")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<Staff>), StatusCodes.Status200OK)]
        public IEnumerable<Staff> GetStaff() => _uow.StaffRepositories.GetStaff();

        [Route("ById/{id}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Staff), StatusCodes.Status200OK)]
        public IActionResult GetStaffbyId(int id)
        {
            var result = _uow.StaffRepositories.GetStaffbyId(id);
            if (result == null)
            {
                return BadRequest(ResponseMessages.StaffNotExist);
            }
            return Ok(result);
        }    
        [Route("Update")]
        [HttpPatch]
        [ProducesResponseType(typeof(Staff), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
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
                return BadRequest(ResponseMessages.UserNotUpdated);
            }

        }
    }
}
