using FieldMgt.API.Controllers;
using FieldMgt.Core.Interfaces;
using FieldMgt.Repository.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        protected readonly MockVendorController _controller;
        protected readonly IMockVendorRepository _service;
        public UnitTest1()
        {
            _service = new IVendorRepo();
            _controller = new MockVendorController(_service);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }    
}
