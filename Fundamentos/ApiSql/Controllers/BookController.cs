using ApiSql.Models;
using ApiSql.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiSql.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookRepository _repository;

    public BookController(BookRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult AddBook([FromBody] Book book)
    {
        if(book is null)
        {
            return BadRequest();
        }

        _repository.AddBook(book);
        return Ok(new { message = "Book added" });
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        var book = _repository.GetById(id);
        return Ok(book);
    }

}
