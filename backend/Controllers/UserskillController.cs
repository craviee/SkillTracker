using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillTracker.DTO;
using SkillTracker.Entities;

namespace SkillTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserskillController : ControllerBase
    {
        private readonly SkilltrackerContext _context;

        public UserskillController(SkilltrackerContext context)
        {
            _context = context;
        }

        // GET: api/Userskill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserskillDTO>>> GetUserskills()
        {
            if (_context.Userskills == null)
            {
                return NotFound();
            }

            List<Userskill> userskill = await _context.Userskills.ToListAsync();
            return UserskillDTO.FromEntityList(userskill);
        }

        // GET: api/Userskill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserskillDTO>> GetUserskill(int id)
        {
            if (_context.Userskills == null)
            {
                return NotFound();
            }

            var userskill = await _context.Userskills.FindAsync(id);

            if (userskill == null)
            {
                return NotFound();
            }

            return new UserskillDTO(userskill);
        }

        // PUT: api/Userskill/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserskill(int id, UserskillDTO userskillDTO)
        {
            if (id != userskillDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(userskillDTO.ToEntity()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserskillExists(id))
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

        // POST: api/Userskill
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserskillDTO>> PostUserskill(UserskillDTO userskillDTO)
        {
            if (_context.Userskills == null)
            {
                return Problem("Entity set 'SkilltrackerContext.Userskills'  is null.");
            }

            Userskill UserskillEntity = userskillDTO.ToEntity();
            _context.Userskills.Add(UserskillEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserskill", new { id = userskillDTO.Id }, new UserskillDTO(UserskillEntity));
        }

        // DELETE: api/Userskill/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserskill(int id)
        {
            if (_context.Userskills == null)
            {
                return NotFound();
            }

            var userskill = await _context.Userskills.FindAsync(id);
            if (userskill == null)
            {
                return NotFound();
            }

            _context.Userskills.Remove(userskill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserskillExists(int id)
        {
            return (_context.Userskills?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}