using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FieldMgt.Core.Interfaces;
using FieldMgt.Repository.Utils;
using System.Net;
<<<<<<< HEAD
using Microsoft.AspNetCore.Http;
=======
>>>>>>> main

namespace FieldMgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private readonly IRoleRepository _roleService;
        public AdministrationController(IRoleRepository roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
<<<<<<< HEAD
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task AddRoleAsync(string role)=> await _roleService.AddRoleAsync(role);
       
        [Route("List")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public IEnumerable<string> ListRoles() => _roleService.ListRoles();

        [Route("EditRoles")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task EditUserRoles(string userName, string role)=> await _roleService.EditUserRoles(userName, role);
        
        [Route("RemoveUserRoles")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task RemoveUserRoles(string userName, string role)=> await _roleService.RemoveUserRoles(userName, role);    
=======
        [Route("AddRole")]        
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddRoleAsync(string role)
        {
            var addRoleResponse = await _roleService.AddRoleAsync(role);
            if (Utilities.IsSuccess(addRoleResponse.Message))
                return Ok(addRoleResponse);
            else
                return BadRequest(addRoleResponse);

        }
        [HttpGet]
        [Route("List")]        
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IEnumerable<string> ListRoles() => _roleService.ListRoles();

        [HttpGet]
        [Route("EditRoles")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> EditUserRoles(string userName, string role)
        {
            var result = await _roleService.EditUserRoles(userName, role);
            if (Utilities.IsSuccess(result.Message))
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpGet]
        [Route("RemoveUserRoles")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RemoveUserRoles(string userName, string role)
        {
            var result = await _roleService.RemoveUserRoles(userName, role);
            if (Utilities.IsSuccess(result.Message))
                return Ok(result);
            else
                return BadRequest(result);
        }
>>>>>>> main

    }
}
