using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FieldMgt.Core.Interfaces;
using AutoMapper;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.UOW;
using FieldMgt.API.Infrastructure.Services;
using FieldMgt.Core.DTOs.Request;
using System;
using FieldMgt.API.Infrastructure.MiddleWares.Exceptions;
using Microsoft.AspNetCore.Mvc;
using FieldMgt.API.Controllers;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading;

namespace FieldMgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class AuthenticationController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitofWork _uow;
        private readonly ICurrentUserService _currentUserService;
        public AuthenticationController(IUserRepository userRepository, IUnitofWork uow, IMapper mapper,ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _uow = uow;
        }        
        [HttpPost]
        [Route("api/auth/Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]CreateEmployeeDTO model,CancellationToken cancellationToken)
        {
                RegisterUserDTO registerDTO = new RegisterUserDTO();
                registerDTO.Email = model.Email;
                registerDTO.Password = model.Password;
                registerDTO.ConfirmPassword = model.ConfirmPassword;
                registerDTO.CreatedBy = _currentUserService.GetUserId();
                registerDTO.CreatedOn = System.DateTime.Now;
                var result = await _userRepository.RegisterUserAsync(registerDTO);
                if (result.IsSuccess)
                    {                        
                        CreateAddressDTO permanentAddressModelDTO = new CreateAddressDTO();
                        permanentAddressModelDTO.Address = model.PermanentAddress;
                        permanentAddressModelDTO.CityId = model.PermanentCity;
                        permanentAddressModelDTO.StateId = model.PermanentState;
                        permanentAddressModelDTO.CountryId = model.PermanentCountry;
                        permanentAddressModelDTO.ZipCode = model.PermanentZipCode;
                        permanentAddressModelDTO.CreatedBy = _currentUserService.GetUserId();
                        permanentAddressModelDTO.CreatedOn = System.DateTime.Now;
                        permanentAddressModelDTO.AddressType = 1;
                        AddressDetail permanentPayload = _mapper.Map<CreateAddressDTO, AddressDetail>(permanentAddressModelDTO);
                        //var permanentAddressResponse = _uow.AddressRepositories.SaveAddress(permanentPayload);
                        CreateAddressDTO correspondenceAddressModelDTO = new CreateAddressDTO();
                        correspondenceAddressModelDTO.Address = model.CorrespondenceAddress;
                        correspondenceAddressModelDTO.CityId = model.CorrespondenceCity;
                        correspondenceAddressModelDTO.StateId = model.CorrespondenceState;
                        correspondenceAddressModelDTO.CountryId = model.CorrespondenceCountry;
                        correspondenceAddressModelDTO.ZipCode = model.CorrespondenceZipCode;
                        correspondenceAddressModelDTO.CreatedBy = _currentUserService.GetUserId();
                        correspondenceAddressModelDTO.CreatedOn = System.DateTime.Now;
                        correspondenceAddressModelDTO.AddressType = 2;
                        AddressDetail correspondencePayload = _mapper.Map<CreateAddressDTO, AddressDetail>(correspondenceAddressModelDTO);
                        //var correspondenceAddressResponse = _uow.AddressRepositories.SaveAddress(correspondencePayload);
                        CreateContactDetailDTO contactModelDTO = new CreateContactDetailDTO();
                        contactModelDTO.PrimaryPhone = model.PrimaryPhone;
                        contactModelDTO.AlternatePhone = model.AlternatePhone;
                        contactModelDTO.PrimaryEmail = model.PrimaryEmail;
                        contactModelDTO.AlternateEmail = model.AlternateEmail;
                        contactModelDTO.CreatedBy= _currentUserService.GetUserId();
                        contactModelDTO.CreatedOn= System.DateTime.Now;
                         ContactDetail contactPayload = _mapper.Map<CreateContactDetailDTO, ContactDetail>(contactModelDTO);
                        //var contactResponse = _uow.ContactDetailRepositories.SaveContactDetails(contactPayload);
<<<<<<< Updated upstream
                    RegistrationDTO modelDTO = new RegistrationDTO();
                    modelDTO.EmployeeId = null;
                    modelDTO.Email = model.Email;
                    modelDTO.FirstName = model.FirstName;
                    modelDTO.LastName = model.LastName;         
                    modelDTO.Gender = model.Gender;
                    modelDTO.DOB = model.DOB;
                    modelDTO.PermanentAddressId =19;
                    modelDTO.CorrespondenceAddressId = 20;
                    modelDTO.ContactDetailId = 12;
                    //modelDTO.PermanentAddressId = permanentAddressResponse.Id;
                    //modelDTO.CorrespondenceAddressId = correspondenceAddressResponse.Id;
                    //modelDTO.ContactDetailId = contactResponse.Id;
                    modelDTO.IsActive = true;
                    modelDTO.UserId = result.Id;
                    modelDTO.Designation = model.Designation;
                    modelDTO.CreatedOn = System.DateTime.Now;
                    modelDTO.CreatedBy = _currentUserService.GetUserId();
                    Staff payload = _mapper.Map<RegistrationDTO, Staff>(modelDTO);
                    await _uow.StaffRepositories.CreateStaffAsync(payload);
                    var result1 = await _uow.SaveAsync();
=======
                        RegistrationDTO modelDTO = new RegistrationDTO();
                        modelDTO.EmployeeId = null;
                        modelDTO.Email = model.Email;
                        modelDTO.FirstName = model.FirstName;
                        modelDTO.LastName = model.LastName;         
                        modelDTO.Gender = model.Gender;
                        modelDTO.DOB = model.DOB;
                        modelDTO.PermanentAddressId =19;
                        modelDTO.CorrespondenceAddressId = 20;
                        modelDTO.ContactDetailId = 12;
                        //modelDTO.PermanentAddressId = permanentAddressResponse.Id;
                        //modelDTO.CorrespondenceAddressId = correspondenceAddressResponse.Id;
                        //modelDTO.ContactDetailId = contactResponse.Id;
                        modelDTO.IsActive = true;
                        modelDTO.UserId = result.Id;
                        modelDTO.Designation = model.Designation;
                        modelDTO.CreatedOn = System.DateTime.Now;
                        modelDTO.CreatedBy = _currentUserService.GetUserId();
                        Staff payload = _mapper.Map<RegistrationDTO, Staff>(modelDTO);
                        await _uow.StaffRepositories.CreateStaffAsync(payload);
                        var result1 = await _uow.SaveAsync1();
>>>>>>> Stashed changes
                        if (result1.Equals(1))
                        {
                            return Ok(result);//status code 200
                        }
                        else
                        {
                            return BadRequest("Unable to create Staff");
                        }
                }
                return BadRequest("Some Properties are not valid"); //status Code 400
        }
        [HttpPost]
        [Route("Login")]
<<<<<<< Updated upstream
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginViewDTO model) => BaseResult(await _userRepository.LoginUserAsync(model));

=======
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginViewDTO model)
        {
                var result = await _userRepository.LoginUserAsync(model);
                return Ok(result);//status code 200
            
        }
>>>>>>> Stashed changes
        [Route("DeleteUser")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Vendor), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser(string userName)
        {
                var deletedBy = _currentUserService.GetUserId();
                var resultUser = await _userRepository.DeleteUser(userName, deletedBy);
                if (resultUser!=null)
                {
                    var staffId = resultUser;
                    var updatedstaff = _uow.StaffRepositories.DeleteStaff(staffId, deletedBy);
                    if(updatedstaff !=null)
                    {
                        int permanentId = (int)updatedstaff.PermanentAddressId;
                        int correspondenceId = (int)updatedstaff.CorrespondenceAddressId;
                        int contactId = (int)updatedstaff.ContactDetailId;
                        if(permanentId!=0)
                        {
                            _uow.AddressRepositories.DeleteAddress(permanentId,deletedBy);
                        }
                        if(correspondenceId!=0)
                        {
                            _uow.AddressRepositories.DeleteAddress(correspondenceId, deletedBy);
                        }
                        if(contactId!=0)
                        {
                            _uow.ContactDetailRepositories.DeleteContact(contactId, deletedBy);
                        }
                    }
                    else
                    {

                    }
                    var result = await _uow.SaveAsync();
                    if (!(result.Equals(0)))
                    {
                        return Ok(result);//status code 200
                    }
                    else
                    {
                        return BadRequest("User can not be deleted");
                    }
                }
                else
                {
                    return BadRequest("User Doesn't Exist");
                }
        }
    }
}