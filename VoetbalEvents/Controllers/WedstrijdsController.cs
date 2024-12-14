using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VoetbalEvents.Data;
using VoetbalEvents.Models;

namespace VoetbalEvents.Controllers
{
    public class WedstrijdsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WedstrijdsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wedstrijds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Wedstrijds.ToListAsync());
        }

        // GET: Wedstrijds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wedstrijd = await _context.Wedstrijds
                .FirstOrDefaultAsync(m => m.WedstrijdID == id);
            if (wedstrijd == null)
            {
                return NotFound();
            }

            return View(wedstrijd);
        }

        // GET: Wedstrijds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wedstrijds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WedstrijdID,Naam,Beschrijving,Datum,MaxKaarten,Toeschouwers,Foto")] Wedstrijd wedstrijd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wedstrijd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wedstrijd);
        }

        // GET: Wedstrijds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wedstrijd = await _context.Wedstrijds.FindAsync(id);
            if (wedstrijd == null)
            {
                return NotFound();
            }
            return View(wedstrijd);
        }

        // POST: Wedstrijds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WedstrijdID,Naam,Beschrijving,Datum,MaxKaarten,Toeschouwers,Foto")] Wedstrijd wedstrijd)
        {
            if (id != wedstrijd.WedstrijdID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wedstrijd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WedstrijdExists(wedstrijd.WedstrijdID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(wedstrijd);
        }

        // GET: Wedstrijds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wedstrijd = await _context.Wedstrijds
                .FirstOrDefaultAsync(m => m.WedstrijdID == id);
            if (wedstrijd == null)
            {
                return NotFound();
            }

            return View(wedstrijd);
        }

        // POST: Wedstrijds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wedstrijd = await _context.Wedstrijds.FindAsync(id);
            if (wedstrijd != null)
            {
                _context.Wedstrijds.Remove(wedstrijd);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WedstrijdExists(int id)
        {
            return _context.Wedstrijds.Any(e => e.WedstrijdID == id);
        }
    }
}
