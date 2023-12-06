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
    public class ListsController : ControllerBase
    {
        private readonly ListMakerContext _context;

        public ListsController(ListMakerContext context)
        {
            _context = context;
        }

        // GET: api/Lists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<List>>> GetLists()
        {
            return await _context.Lists.ToListAsync();
        }

        // GET: api/Lists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List>> GetList(int id)
        {
            var list = await _context.Lists.Where(x => x.Id == id).Include(x => x.User).SingleOrDefaultAsync();

            if (list == null)
            {
                return NotFound();
            }

            return list;
        }
        // GET: api/lists/userId/
        [HttpGet("userId/{userId}")]
        public async Task<ActionResult<IEnumerable<List>>> GetListByUserId(int userId)
        {
            var lists = await _context.Lists.Where(x => x.UserId == userId).Include(x => x.User).Include(x => x.ListItems).ToListAsync();
            if (lists == null) return NotFound();

            return lists;
        }
        // PUT: api/Lists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutList(int id, List list)
        {
            if (id != list.Id)
            {
                return BadRequest();
            }

            _context.Entry(list).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListExists(id))
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

        // POST: api/Lists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List>> PostList(CreateListDto listDto)
        {
            List list = new List() { 
                Name = listDto.Name,
                ListCategoryId = listDto.ListCategoryId,
                DateCreated = DateTime.Now,
                Total = listDto.Total,
                UserId = listDto.UserId
            };
            _context.Lists.Add(list);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetList", new { id = list.Id }, list);
        }

        // DELETE: api/Lists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(int id)
        {
            var list = await _context.Lists.FindAsync(id);
            if (list == null)
            {
                return NotFound();
            }

            _context.Lists.Remove(list);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListExists(int id)
        {
            return _context.Lists.Any(e => e.Id == id);
        }
    }
}
