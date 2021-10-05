using System;
using Xunit;
using BookDetails_MicroService.Controllers;
using BookDetails_MicroService.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookDetails_MicroService.Model;
using BookDetails_MicroService.DBContexts;
using Microsoft.Extensions.Logging;

namespace Book_Details_MicroService_Testing
{

    public class BookDetailsControllerTests
    {
        BookDetailsController _controller;
        IBookRepository _service;
        BookDBContext Contexts;
        private ILogger<BookDetailsController> logger;

        public BookDetailsControllerTests()
        {
            _service = new BookRepositoryTests(Contexts);
            _controller = new BookDetailsController(_service,logger);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new BookMaster()
            {
                Id = 1,
                Book_Name = "Dot Net"
            };
            _controller.ModelState.AddModelError("Name", "Required");
            // Act
            var badResponse = _controller.Post(nameMissingItem);
            // Assert
            
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            //Arrange
            BookMaster testItem = new BookMaster()
            {
                Id = 1,
                Book_Name = "Dot Net",
                Book_Author_Name = "Dr Swammy",
                ISBN_Num = "12345",
                Book_Publication_Date = DateTime.Parse("01/02/2020")
            };
            //Act
            var createdResponse = _controller.Post(testItem);
            //Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            BookMaster testItem = new BookMaster()
            {
                Id = 1,
                Book_Name = "Dot Net",
                Book_Author_Name = "Dr Swammy",
                ISBN_Num = "12345",
                Book_Publication_Date = DateTime.Parse("01/02/2020")
            };
            // Act
            var createdResponse = _controller.Post(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as BookMaster;
            // Assert
            Assert.IsType<BookMaster>(item);
            Assert.Equal("Dot Net", item.Book_Name);
        }

        [Fact]
        public void GetById_Passed_ReturnsNotFoundResult()
        {
            // Act
            Decimal Id = 0;
            var notFoundResult = _controller.Get(Id);
            // Assert
           
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            Decimal Id = 1;
            // Act
            var okResult = _controller.Get(Id);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            Decimal Id = 1;
            // Act
            var okResult = _controller.Get(Id) as OkObjectResult;
            // Assert
            Assert.IsType<BookMaster>(okResult.Value);

        }

        [Fact]
        public void Delete_NotExistingIddPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            Decimal Id = 0;
            // Act
            var badResponse = _controller.Delete(Id);
            // Assert
            
        }

        [Fact]
        public void Delete_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            Decimal Id = 1;
            // Act
            var okResponse = _controller.Delete(Id);
            // Assert
            
        }

    }
}
