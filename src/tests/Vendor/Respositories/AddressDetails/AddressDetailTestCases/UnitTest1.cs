using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace AddressDetailTestCases
{
    public class UnitTest1
    {
        protected readonly VendorController _controller;
        protected readonly IVendorRepository _service;
        public UnitTest1()
        {
            _service = new VendorRepository();
            _controller = new VendorController(_service);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        //[Fact]
        //public void Get_WhenCalled_ReturnsAllItems()
        //{
        //    // Act
        //    var okResult = _controller.Get().Result as OkObjectResult;
        //    // Assert
        //    var items = Assert.IsType<List<Vendor>>(okResult.Value);
        //    Assert.Equal(3, items.Count);
        //}
    }
}
