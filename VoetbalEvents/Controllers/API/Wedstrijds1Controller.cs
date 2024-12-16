using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoetbalEvents.Data;
using VoetbalEvents.Models;

namespace VoetbalEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Wedstrijds1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Wedstrijds1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Wedstrijds1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wedstrijd>>> GetWedstrijds()
        {
            return await _context.Wedstrijds.ToListAsync();
        }

        // GET: api/Wedstrijds1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wedstrijd>> GetWedstrijd(int id)
        {
            var wedstrijd = await _context.Wedstrijds.FindAsync(id);

            if (wedstrijd == null)
            {
                return NotFound();
            }

            return wedstrijd;
        }

        // PUT: api/Wedstrijds1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWedstrijd(int id, Wedstrijd wedstrijd)
        {
            if (id != wedstrijd.WedstrijdID)
            {
                return BadRequest();
            }

            _context.Entry(wedstrijd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WedstrijdExists(id))
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

        // POST: api/Wedstrijds1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wedstrijd>> PostWedstrijd(Wedstrijd wedstrijd)
        {
            _context.Wedstrijds.Add(wedstrijd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWedstrijd", new { id = wedstrijd.WedstrijdID }, wedstrijd);
        }

        // DELETE: api/Wedstrijds1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWedstrijd(int id)
        {
            var wedstrijd = await _context.Wedstrijds.FindAsync(id);
            if (wedstrijd == null)
            {
                return NotFound();
            }

            _context.Wedstrijds.Remove(wedstrijd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WedstrijdExists(int id)
        {
            return _context.Wedstrijds.Any(e => e.WedstrijdID == id);
        }
    }
}
