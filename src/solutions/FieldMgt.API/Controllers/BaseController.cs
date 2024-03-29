﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FieldMgt.API.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContext;
        //private readonly ICurrentUserService _currentUserService;
        public BaseController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        protected IActionResult BaseResult(int response)
        {
            if (response > 0)
                return Ok();
            else
                return BadRequest();
        }
        protected IActionResult BaseResult<T>(T response)
        {
            if (response != null)
                return Ok(response);
            else
                return BadRequest();
        }
        protected IActionResult CollectionResult<T>(T response)
        {
            return Ok(response);
        }
        [NonAction]
        protected string GetUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
