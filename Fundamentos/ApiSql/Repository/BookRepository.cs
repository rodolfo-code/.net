using ApiSql.DTOs;
using ApiSql.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSql.Repository;

public class BookRepository
{
    private readonly BookContext _context;

    public BookRepository(BookContext context)
    {
        _context = context;
    }

    public List<Book?> GetBookList()
    {
        var books = _context.Books.ToList();
        return books;
    }

    public BookDTO GetById(int id)
    {
        var book = _context.Books
            .Where(x => x.BookId == id)
            .Include(x => x.Author)
            .Include(x => x.Publisher)
        .Select(b => new BookDTO
        {
            BookId = b.BookId,
            Title = b.Title,
            Description = b.Description,
            AuthorName = b.Author.Name,
            PublisherName = b.Publisher.Name
        }
        ).First();

        return book;
    }

    public Book AddBook(Book book)
    {
        _context.Add(book);
        _context.SaveChanges();
        return book;
    }

    public virtual void UpadateBook(Book book, int id)
    {
        _context.Update(book);
        _context.SaveChanges();
    }

    public virtual void DeleteBook(int id)
    {
        var book = _context.Books
            .Include(x => x.AuthorId)
            .Include(x => x.PublisherId)
            .Single(p => p.BookId == id);

        _context.Remove(book); // removemos o livro
        _context.Remove(book.Author); //removemos o autor relacionado
        _context.Remove(book.Publisher); // remove a editora associada
        _context.SaveChanges(); //ao
    }
}
