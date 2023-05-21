using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BlogDataContext _context;
        public CategoryController([FromServices] BlogDataContext context) 
        {
            _context = context;
        }

        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var category = await _context
               .Categories
               .FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                {
                    return NotFound();
                }


                return Ok(category);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "05XE17 - Não foi possivel incluir a categoria");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05XE18 - Falha intena no servidor");
                throw;
            }
        }

        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync([FromBody] Category category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();

                return Created($"v1/categories/{category.Id}", category);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "05XE9 - Não foi possivel incluir a categoria");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05XE10 - Falha intena no servidor");
                throw;
            }
        }

        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] Category category)
        {
            try
            {
                var findCategory = _context.Categories.FirstOrDefault(x => x.Id == id);
                if (category == null)
                {
                    return NotFound();
                }

                findCategory.Name = category.Name;
                findCategory.Slug = category.Slug;

                _context.Categories.Update(category);
                await _context.SaveChangesAsync();

                return Ok(category);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "05XE11 - Não foi possivel incluir a categoria");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05XE12 - Falha intena no servidor");
                throw;
            }
        }

        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                {
                    return NotFound();
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return Ok(category);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "05XE12 - Não foi possivel incluir a categoria");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05XE13 - Falha intena no servidor");
                throw;
            }
        }
    }
}
