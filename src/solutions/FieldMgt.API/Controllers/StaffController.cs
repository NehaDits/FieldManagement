using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using FieldMgt.Core.UOW;
using FieldMgt.Repository.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public IEnumerable<StaffListDTO> GetStaff() => _uow.StaffRepositories.GetStaff();
        [Route("ById/{id}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Staff), StatusCodes.Status200OK)]
        public StaffListDTO GetStaffbyId(int id)
        {
            var result = _uow.StaffRepositories.GetStaffbyId(id);
            return result;
        }    
        [Route("Update")]
        [HttpPatch]
        [ProducesResponseType(typeof(Staff), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task UpdateStaffAsync(UpdateStaffDTO model)
        {
            try
            {
                model.ModifiedBy = GetUserId();
                model.ModifiedOn = System.DateTime.Now;
                await _uow.StaffRepositories.UpdateStaffAsync(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
        [Route("Delete/{staffId}")]
        [HttpPatch]
        [ProducesResponseType(typeof(Staff), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteStaff(int staffId)
        {
            var deletedBy = GetUserId();
            var staff=_uow.StaffRepositories.DeleteStaff(staffId,deletedBy);            
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
