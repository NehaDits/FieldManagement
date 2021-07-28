using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FieldMgt.Core.Interfaces;
using FieldMgt.Repository.Utils;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace FieldMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : BaseController
    {
        private readonly IRoleRepository _roleService;
        public AdministrationController(IRoleRepository roleService)
        {
            _roleService = roleService;
        }
        [Route("ListRoles")]
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

        [HttpPost]
        [Route("AddRole")]        
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task AddRoleAsync(string role)
        {
            await _roleService.AddRoleAsync(role);            
        }
    }
}
