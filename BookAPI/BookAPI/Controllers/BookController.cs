using Microsoft.AspNetCore.Mvc;
using BookApi.Repositories;
using BookAPI.Interface;
using BookAPI.Models;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public BooksController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookRepo.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookRepo.GetBook(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            _bookRepo.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.Id)
                return BadRequest();

            _bookRepo.UpdateBook(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookRepo.DeleteBook(id);
            return NoContent();
        }
    }
}

