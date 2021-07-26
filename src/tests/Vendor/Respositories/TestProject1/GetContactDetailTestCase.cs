using FieldMgt.API.Controllers;
using FieldMgt.Core.Interfaces.MockRepository;
using FieldMgt.Repository.Repository;
using FieldMgt.Repository.Repository.MockRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace TestProject1
{
    public class GetContactDetailTestCase
    {
        protected readonly MockContactDetailController _controller;
        protected readonly IMockContactDetailsRepository _service;
        public GetContactDetailTestCase()
        {
            _service = new MockContactDetailRepository();
            _controller = new MockContactDetailController(_service);
        }
        [Fact]
        public void GetContacts_ShouldReturnOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
