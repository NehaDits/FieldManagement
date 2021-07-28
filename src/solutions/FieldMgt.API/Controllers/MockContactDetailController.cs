using FieldMgt.Core.DomainModels;
using FieldMgt.Core.Interfaces.MockRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FieldMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockContactDetailController : ControllerBase
    {
        private readonly IMockContactDetailsRepository  _service;
        public MockContactDetailController(IMockContactDetailsRepository service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ContactDetail>> Get()
        {
            var items = _service.GetAllItems();
            return Ok(items);
        }
    }
}
