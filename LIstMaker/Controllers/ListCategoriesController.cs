using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListMaker.Data;
using ListMaker.Models;
using ListMaker.DTOs;

namespace ListMaker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListCategoriesController : ControllerBase
    {
        private readonly ListMakerContext _context;

        public ListCategoriesController(ListMakerContext context)
        {
            _context = context;
        }

        // GET: api/ListCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListCategory>>> GetListCategories()
        {
            return await _context.ListCategories.ToListAsync();
        }

        // GET: api/ListCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListCategory>> GetListCategory(int id)
        {
            var listCategory = await _context.ListCategories.FindAsync(id);

            if (listCategory == null)
            {
                return NotFound();
            }

            return listCategory;
        }

        // PUT: api/ListCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListCategory(int id, ListCategory listCategory)
        {
            if (id != listCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(listCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ListCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListCategory>> PostListCategory(AddListCategoryDTO addListCategoryDTO)
        {
            var listCategory = new ListCategory
            {
                CategoryName = addListCategoryDTO.CategoryName,
            };
            _context.ListCategories.Add(listCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListCategory", new { id = listCategory.Id }, listCategory);
        }

        // DELETE: api/ListCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListCategory(int id)
        {
            var listCategory = await _context.ListCategories.FindAsync(id);
            if (listCategory == null)
            {
                return NotFound();
            }

            _context.ListCategories.Remove(listCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListCategoryExists(int id)
        {
            return _context.ListCategories.Any(e => e.Id == id);
        }
    }
}
