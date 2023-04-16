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
    public class SkillController : ControllerBase
    {
        private readonly SkilltrackerContext _context;

        public SkillController(SkilltrackerContext context)
        {
            _context = context;
        }

        // GET: api/Skill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDTO>>> GetSkills()
        {
            if (_context.Skills == null)
            {
                return NotFound();
            }

            List<Skill> skills = await _context.Skills.ToListAsync();
            return SkillDTO.FromEntityList(skills);
        }

        // GET: api/Skill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillDTO>> GetSkill(int id)
        {
            if (_context.Skills == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills.FindAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            return new SkillDTO(skill);
        }

        // PUT: api/Skill/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(int id, SkillDTO skillDTO)
        {
            if (id != skillDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(skillDTO.ToEntity()).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
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

        // POST: api/Skill
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SkillDTO>> PostSkill(SkillDTO skillDTO)
        {
            if (_context.Skills == null)
            {
                return Problem("Entity set 'SkilltrackerContext.Skills'  is null.");
            }

            Skill skillEntity = skillDTO.ToEntity();
            _context.Skills.Add(skillEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkill", new { id = skillDTO.Id }, new SkillDTO(skillEntity));
        }

        // DELETE: api/Skill/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            if (_context.Skills == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillExists(int id)
        {
            return (_context.Skills?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}