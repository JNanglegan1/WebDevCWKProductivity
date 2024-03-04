using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDevCWK.Models;

namespace WebDevCWK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Manager,User")]
    public class MilestonesController : ControllerBase
    {
        private readonly ProductivityContext _context;

        public MilestonesController(ProductivityContext context)
        {
            _context = context;
        }

        // GET: api/Milestones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Milestones>>> GetMilestones()
        {
            return await _context.Milestones.ToListAsync();
        }

        // GET: api/Milestones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Milestones>> GetMilestones(int id)
        {
            var milestones = await _context.Milestones.FindAsync(id);

            if (milestones == null)
            {
                return NotFound();
            }

            return milestones;
        }

        // PUT: api/Milestones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMilestones(int id, Milestones milestones)
        {
            if (id != milestones.MilestoneID)
            {
                return BadRequest();
            }

            _context.Entry(milestones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MilestonesExists(id))
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

        // POST: api/Milestones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Milestones>> PostMilestones(Milestones milestones)
        {
            _context.Milestones.Add(milestones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMilestones", new { id = milestones.MilestoneID }, milestones);
        }

        // DELETE: api/Milestones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMilestones(int id)
        {
            var milestones = await _context.Milestones.FindAsync(id);
            if (milestones == null)
            {
                return NotFound();
            }

            _context.Milestones.Remove(milestones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MilestonesExists(int id)
        {
            return _context.Milestones.Any(e => e.MilestoneID == id);
        }
    }
}
