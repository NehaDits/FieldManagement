using FieldMgt.Core.DomainModels;
using FieldMgt.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FieldMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockVendorController : Controller
    {
        private readonly IMockVendorRepository _service;
        public MockVendorController(IMockVendorRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vendor>> Get()
        {
            var items = _service.GetAllItems();
            return Ok(items);
        }
    }
}
