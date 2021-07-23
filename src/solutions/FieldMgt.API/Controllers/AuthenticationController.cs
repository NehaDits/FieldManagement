using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FieldMgt.Core.Interfaces;
using AutoMapper;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.UOW;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.API.Controllers;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Net;
using FieldMgt.Repository.Enums;
using System;

namespace FieldMgt.Controllers
{
    [Route("api/[controller]")]

    [ApiController]    
    public class AuthenticationController : BaseController

    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _uow;

        public AuthenticationController(IUserRepository userRepository, IUnitofWork uow, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _uow = uow;
        }
        [HttpPost]
        [Route("Register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterAsync([FromBody] CreateEmployeeDTO model)
        {
            try
            {                
                //model.CreatedBy =GetUserId();
                model.CreatedOn = System.DateTime.Now;
                var result = await _userRepository.RegisterUserAsync(model);
                model.UserId = result;
                return BaseResult(await _uow.StaffRepositories.CreateStaffAsync(model));
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


        [Route("DeleteUser")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int) StatusCodes.Status200OK)]
        public async Task DeleteUser(string userName)
        {
            var deletedBy = GetUserId();
            var resultUser = await _userRepository.DeleteUser(userName, deletedBy);
        }
    }
}