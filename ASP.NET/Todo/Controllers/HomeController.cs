using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]
    [Route("/v1")]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext _context;
        public HomeController([FromServices] AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        // [Route("/")]
        public IActionResult Get()
        {
            return Ok(_context.Todos.ToList());
        }

        // [HttpGet("/v1/{id:int}")]
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {

            var todo = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        // [HttpPost("/")]
        [HttpPost]
        public IActionResult Post([FromBody] TodoModel todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return Created($"/{todo.Id}", todo);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] TodoModel todo)
        {
            var model = _context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            model.Title = todo.Title;
            model.Done = todo.Done;

            _context.Todos.Update(model);
            _context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            var model = _context.Todos.FirstOrDefault(x => x.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(model);
            _context.SaveChanges();
            return Ok(model);
        }
    }
}