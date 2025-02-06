using BookAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksDbContext _booksDbContext;
        public BooksController(BooksDbContext booksDbContext)
        {
            _booksDbContext = booksDbContext;
        }
        [HttpGet]
        public ActionResult<Books> GetAllBooks()
        {
            var getAllBooks = _booksDbContext.Books.ToList();

            return Ok(getAllBooks);
        }
        [HttpGet("{id}")]
        public ActionResult GetBook(int id)
        {
            var getBook = _booksDbContext.Books.Find(id);

            return Ok(getBook);
        }
        [HttpPost]
        public ActionResult CreateBook([FromBody] Books book)
        {
            _booksDbContext.Books.Add(book);
            _booksDbContext.SaveChanges();

            return Ok(CreateBook);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id) 
        {
            var bookToDelete = _booksDbContext.Books.Find(id);
            _booksDbContext.Books.Remove(bookToDelete);
            _booksDbContext.SaveChanges();

            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, [FromBody] Books updatedbook) 
        {
            var existingBook = _booksDbContext.Books.Find(id);

            existingBook.Name = updatedbook.Name;
            existingBook.Author = updatedbook.Author;
            existingBook.ReleaseYear = updatedbook.ReleaseYear;
            existingBook.Price = updatedbook.Price;

            _booksDbContext.SaveChanges();

            return NoContent();
        }

    }
}
