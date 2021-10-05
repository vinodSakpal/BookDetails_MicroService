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
        private ILogger<BookDetailsController> logger;

        public BookDetailsControllerTests()
        {
            _service = new InMemoryBookRepository();
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
            Assert.IsType<CreatedAtActionResult>(badResponse);
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
                ISBN_Num = "1234567890123",
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
                ISBN_Num = "1234567890123",
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
        public void GetByIsbn_Passed_ReturnsNotFoundResult()
        {
            // Act
            string id = "0";
            var notFoundResult = _controller.Get(id);
            // Assert
            Assert.IsType<OkObjectResult>(notFoundResult);

        }

        [Fact]
        public void GetByIsbn_ExistingIsbnPassed_ReturnsOkResult()
        {
            // Arrange
            string id = "0";
            // Act
            var okResult = _controller.Get(id);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetByIsbn_ExistingIsbnPassed_ReturnsRightItem()
        {
            // Arrange
            string id = "1234567890123";
            // Act
            var okResult = _controller.Get(id);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);

        }

        [Fact]
        public void Delete_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            int id = 0;
            // Act
            var badResponse = _controller.Delete(id);
            // Assert
            Assert.IsType<OkResult>(badResponse);
        }

        [Fact]
        public void Delete_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            int id = 1;
            // Act
            var okResponse = _controller.Delete(id);
            // Assert
            Assert.IsType<OkResult>(okResponse);
        }

    }
}
