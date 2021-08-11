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
        [Route("AddEstimation")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateEstimationOrder(CreateEstimationDTO model)
        {
            var Estimation = _mapper.Map<CreateEstimationDTO, SaveEstimationDTO>(model);
            Estimation.CreatedBy = GetUserId();
            await _uow.EstimationRepositories.CreateEstimation(Estimation);
            return BaseResult(await _uow.SaveAsync());
        }
        [Route("List")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<EstimationSaveDTO>), StatusCodes.Status200OK)]
        public IEnumerable<EstimationSaveDTO> GetEstimationAsync()
        {
            return _uow.EstimationRepositories.GetEstimationAsync();
        }
        [Route("ById/{Id}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EstimationSaveDTO), StatusCodes.Status200OK)]
        public EstimationSaveDTO GetEstimationById(int EstimationId)
        {
            var result = _uow.EstimationRepositories.GetEstimationbyIdAsync(EstimationId);
            return result;
        }
        [Route("UpdateEstimation")]
        [HttpPatch]
        [ProducesResponseType(typeof(EstimationSaveDTO), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public EstimationSaveDTO UpdateEstimation(UpdateEstimationDTO model)
        {
            var Estimation = _mapper.Map<UpdateEstimationDTO, UpdateEstimationsDTO>(model);
            Estimation.ModifiedBy = GetUserId();
            Estimation.ModifiedOn = System.DateTime.Now;
            return _uow.EstimationRepositories.UpdateEstimationAsync(Estimation);
        }
        [Route("Delete/{Id}")]
        [HttpPatch]
        [ProducesResponseType(typeof(Estimation), StatusCodes.Status200OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteEstimation(int EstimationId)
        {
            var deletedBy = GetUserId();
            var Estimation = _uow.EstimationRepositories.DeleteEstimation(EstimationId, deletedBy);
            return BaseResult(await _uow.SaveAsync());
        }
    }
}
