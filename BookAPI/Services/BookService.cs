using BookApi.Interfaces;
using BookApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookApi.Services;

public class BookService : IBookService
{
    private readonly List<Book> _books = new List<Book>
    {
        new Book { Id = 1, Title = "1984", Author = "George Orwell", Price = 9.99m },
        new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Price = 7.99m }
    };

    public IEnumerable<Book> GetAllBooks() => _books;

    public Book GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public void AddBook(Book book)
    {
        book.Id = _books.Max(b => b.Id) + 1;
        _books.Add(book);
    }

    public void UpdateBook(int id, Book updatedBook)
    {
        var book = GetBookById(id);
        if (book != null)
        {
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Price = updatedBook.Price;
        }
    }

    public void DeleteBook(int id)
    {
        var book = GetBookById(id);
        if (book != null)
        {
            _books.Remove(book);
        }
    }
}
