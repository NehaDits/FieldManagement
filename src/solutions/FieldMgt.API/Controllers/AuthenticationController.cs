using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FieldMgt.Core.Interfaces;
using AutoMapper;
using FieldMgt.Core.UOW;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.API.Controllers;
using System.Net;
using Microsoft.AspNetCore.Http;
using System;
using FieldMgt.Core.DTOs;

namespace FieldMgt.Controllers
{
    [Route("api/[controller]")]

    [ApiController]    
    public class AuthenticationController : BaseController

    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _uow;
        private readonly IRoleRepository _roleService;
        public AuthenticationController(IUserRepository userRepository, IUnitofWork uow, IRoleRepository roleService, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _uow = uow;
            _roleService = roleService;
        }
        [HttpPost]
        [Route("CreateUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateEmployeeDTO model)
        {
            try
            {
                var user = _mapper.Map<CreateEmployeeDTO, CreateUserDTO>(model);
                user.CreatedBy =GetUserId();
                user.CreatedOn = System.DateTime.Now;
                var result = await _userRepository.RegisterUserAsync(user);
                user.UserId = result;
                await _roleService.EditUserRoles(model.Email, model.Role);
                return BaseResult(await _uow.StaffRepositories.CreateStaffAsync(user));
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginViewDTO model) => BaseResult(await _userRepository.LoginUserAsync(model));
        [Route("DeleteUser/{ByUserId}")]
        [HttpPatch]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int) StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var deletedBy = GetUserId();             
            var resultUser = await _userRepository.DeleteUser(userId, deletedBy);
            _uow.StaffRepositories.DeleteStaffAsUser(resultUser, deletedBy);
            return BaseResult(await _uow.SaveAsync());
        }
    }
}