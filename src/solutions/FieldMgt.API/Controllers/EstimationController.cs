using AutoMapper;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DTOs.Response;
using FieldMgt.Core.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace FieldMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimationController : BaseController
    {
        private readonly IUnitofWork _uow;
        private readonly IMapper _mapper;
        public EstimationController(IUnitofWork uow, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(httpContextAccessor)
        {
            _uow = uow;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateClienttContactAsync(CreateClientContactDTO model)
        {
            var addClientContact = _mapper.Map<CreateClientContactDTO, AddClientContactDTO>(model);
            addClientContact.CreatedBy = GetUserId();
            addClientContact.CreatedOn = System.DateTime.Now;
            addClientContact.IsActive = true;
            return BaseResult(await _uow.ClientContactRepositories.CreateClientContactAsync(addClientContact));
        }

        [HttpGet]
        [Route("GetList")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<ClientContact>), StatusCodes.Status200OK)]
        public IActionResult GetClientContactAsync()
            => Ok(_uow.ClientContactRepositories.GetClientContactList());

        [HttpGet]
        [Route("ById/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientContact), StatusCodes.Status200OK)]
        public IActionResult GetClientContactByIdAsync(int id)
            => BaseResult<ClientContactResponseDTO>(_uow.ClientContactRepositories.GetClientContactbyIdAsync(id));

        [HttpPatch]
        [Route("Update/{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientContact), StatusCodes.Status200OK)]
        public async Task UpdateClientStatusAsync(CreateClientContactDTO clientContact, int Id)
        {
            var user = _mapper.Map<CreateClientContactDTO, UpdateClientContactDTO>(clientContact);
            user.ClientContactId = Id;
            user.ModifiedBy = GetUserId();
            user.ModifiedOn = System.DateTime.Now;
            await _uow.ClientContactRepositories.UpdateClientContact(user);
        }

        [HttpDelete]
        [Route("DeleteEstimation/{Id}")]
        public async Task<IActionResult> DeleteClientContact(int clientContactId)
        {
            var deletedBy = GetUserId();
            _uow.ClientContactRepositories.DeleteClientContact(clientContactId, deletedBy);
            return BaseResult(await _uow.SaveAsync());
        }
    }
}
