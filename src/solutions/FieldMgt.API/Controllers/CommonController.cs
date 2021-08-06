using FieldMgt.Core.DTOs.Response;
using FieldMgt.Core.Interfaces;
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
    public class CommonController : BaseController
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IUnitofWork _uow;
        public CommonController(ICommonRepository commonRepository, IUnitofWork uow,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _commonRepository = commonRepository;
            _uow = uow;
        }
        [Route("GetCities")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public List<CityListDTO> GetCityList()
        {
            return _uow.CommonRepositories.GetCities();
        }
        [Route("GetStates")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public List<StateListDTO> GetStateList()
        {
            return _uow.CommonRepositories.GetStates();
        }
        [Route("GetCountries")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public List<CountryListDTO> GetCountryList()
        {
            return _uow.CommonRepositories.GetCountries();
        }
        [Route("GetGlobalCodes")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public List<GlobalCodesListDTO> GetGlobalCodesList(int category)
        {
            return _uow.CommonRepositories.GetGlobalCodes(category);
        }
        [Route("GetGlobalCodeCategories")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public List<GlobalCodeCategoriesListDTO> GetGlobalCodeCategoriesList()
        {
            return _uow.CommonRepositories.GetGlobalCodeCategories();
        }
    }
}
