using Blog.Data;
using Blog.Models;
using Blog.ViewModels;
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
        public async Task<IActionResult> PostAsync([FromBody] EditorCategoryViewModel model)
        {
            if(!ModelState.IsValid) 
                return BadRequest();
            try
            {
                var category = new Category
                {
                    Id = 0,
                    Name = model.Name,
                    Slug = model.Slug
                };

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
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorCategoryViewModel model)
        {
            try
            {
                var findCategory = _context.Categories.FirstOrDefault(x => x.Id == id);
                if (findCategory == null)
                {
                    return NotFound();
                }

                findCategory.Name = model.Name;
                findCategory.Slug = model.Slug;

                _context.Categories.Update(findCategory);
                await _context.SaveChangesAsync();

                return Ok(model);
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
