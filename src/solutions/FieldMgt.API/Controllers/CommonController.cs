using FieldMgt.Core.Interfaces;
using FieldMgt.Core.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
