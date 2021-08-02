﻿using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FieldMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IUnitofWork _uow;
        public ClientController(IUnitofWork uow, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _uow = uow;
        }
        /// <summary>
        /// Use to create Client
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateClientAsync([FromBody] CreateClientDTO model)
        => BaseResult(await _uow.ClientRepositories.Save(model));

        /// <summary>
        /// Get Client detail list
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[Route("GetList")]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(IEnumerable<Client>), StatusCodes.Status200OK)]
        //public IActionResult GetClientAsync()
        //    => Ok(_uow.ClientRepositories.GetClientsAsync());

        /// <summary>
        /// Pass Client id and returns single record of Client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ById/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        public IActionResult GetClientByIdAsync(int id)
            => BaseResult(_uow.ClientRepositories.GetClientbyIdAsync(id));

        /// <summary>
        /// Update the Client details
        /// </summary>
        /// <param name="Client"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("Update/{ClientId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        public async Task<IEnumerable<Client>> UpdateClientStatusAsync(CreateClientDTO Client, int Clientid)
        {
            Client.ClientSource = Clientid;
            Client.CreatedBy = GetUserId();
            var ClientDetail = await _uow.ClientRepositories.UpdateClientStatusAsync(Client);
            return ClientDetail;
        }
        //=> BaseResult<Client>(await _uow.ClientRepositories.UpdateClientStatusAsync(Client));

        /// <summary>
        /// Soft delete Client 
        /// </summary>
        /// <param name="ClientId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteClient/{Id}")]
        public Client DeleteClient(int Id)
        {
            var deletedBy = GetUserId();
            return _uow.ClientRepositories.DeleteClient(Id, deletedBy);
        }
    }
}
