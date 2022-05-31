using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System.Collections.Generic;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _booksService.GetallBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);

        }

        [HttpPost]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBookById(int id, [FromBody]BookVM book)
        {
            var updatedBook = _booksService.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}
