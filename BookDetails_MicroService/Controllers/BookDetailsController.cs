using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Swashbuckle.AspNetCore.Annotations;
using System.Transactions;
using BookDetails_MicroService.Model;
using BookDetails_MicroService.Repository;
using Microsoft.Extensions.Logging;


namespace BookDetails_MicroService.Controllers
{
    [ApiVersion("1")]
    [SwaggerTag("Public APIs to be used for Book Dedtails")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailsController : ControllerBase
    {
        private IBookRepository repository;

        private ILogger<BookDetailsController> logger;
        private IBookRepository service;

        public BookDetailsController(IBookRepository _repository, ILogger<BookDetailsController> _logger)
        {
            logger = _logger;
            repository = _repository;
        }

        [Produces("application/json")]
        [HttpGet("(ISBN)", Name = "Get")]
        public IActionResult Get(string isbn)
        {
            var book = repository.GetBook_byISBN(isbn);
            return new OkObjectResult(book);

        }

        [Produces("application/json")]
        [HttpPost]
        public IActionResult Post([FromBody] BookMaster book)
        {
            using (var scope = new TransactionScope())
            {
                repository.InsertBook(book);
                scope.Complete();
            }
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [Produces("application/json")]
        [HttpPut("{ID}")]
        public IActionResult Put([FromBody] BookMaster book)
        {
            if (book != null)
            {
                using (var scope = new TransactionScope())
                {
                    repository.UpdateBook(book);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [Produces("application/json")]
        [HttpDelete("(ID)")]
        public IActionResult Delete(int id)
        {
            repository.DeleteBook(id);
            return new OkResult();
        }
    }
}




