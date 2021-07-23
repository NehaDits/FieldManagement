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
    public class StaffController : BaseController
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
        [Route("Delete/{staffId}")]
        [HttpPatch]
        [ProducesResponseType(typeof(Staff), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteStaff(int staffId)
        {
            //var deletedBy = GetUserId();
            string deletedBy= "ef909433-f28e-40a9-ab89-fe81b99ca1e3";
            var staff=_uow.StaffRepositories.DeleteStaff(staffId,deletedBy);
            int permanentAddress = (int)staff.PermanentAddressId;
            int correspondenceAddress = (int)staff.CorrespondenceAddressId;
            int contactDetail = (int)staff.ContactDetailId;
            _uow.AddressRepositories.DeleteAddress(permanentAddress,deletedBy);
            _uow.AddressRepositories.DeleteAddress(correspondenceAddress, deletedBy);
            _uow.ContactDetailRepositories.DeleteContact(contactDetail, deletedBy);
            var result = await _uow.SaveAsync();
            if (result>0)
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
