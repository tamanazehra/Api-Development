using BookApi.Models;
using System.Collections.Generic;

namespace BookApi.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(int id, Book updatedBook);
        void DeleteBook(int id);
    }
}
