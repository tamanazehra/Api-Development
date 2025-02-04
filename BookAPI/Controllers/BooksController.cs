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
    }
}
