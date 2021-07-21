using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldMgt.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult BaseResult(int response)
        {
            if (response > 0)
                return Ok();
            else
                return BadRequest();
        }
        protected IActionResult BaseResult<T>(T response)
        {
            if (response == null)
                return Ok(response);
            else
                return BadRequest();
        }
        protected IActionResult CollectionResult<T>(T response)
        {
            return Ok(response);
        }

    }
}
