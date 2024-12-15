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
    public class reserveringsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public reserveringsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: reserverings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.reserverings.Include(r => r.Wedstrijd);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: reserverings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.reserverings
                .Include(r => r.Wedstrijd)
                .FirstOrDefaultAsync(m => m.ReserveringID == id);
            if (reservering == null)
            {
                return NotFound();
            }

            return View(reservering);
        }

        // GET: reserverings/Create
        public IActionResult Create()
        {
            ViewData["WedstrijdID"] = new SelectList(_context.Wedstrijds, "WedstrijdID", "Naam");
            return View();
        }

        // POST: reserverings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReserveringID,Datum,WedstrijdID")] reservering reservering)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservering);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WedstrijdID"] = new SelectList(_context.Wedstrijds, "WedstrijdID", "Naam", reservering.WedstrijdID);
            return View(reservering);
        }

        // GET: reserverings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.reserverings.FindAsync(id);
            if (reservering == null)
            {
                return NotFound();
            }
            ViewData["WedstrijdID"] = new SelectList(_context.Wedstrijds, "WedstrijdID", "Naam", reservering.WedstrijdID);
            return View(reservering);
        }

        // POST: reserverings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReserveringID,Datum,WedstrijdID")] reservering reservering)
        {
            if (id != reservering.ReserveringID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!reserveringExists(reservering.ReserveringID))
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
            ViewData["WedstrijdID"] = new SelectList(_context.Wedstrijds, "WedstrijdID", "Naam", reservering.WedstrijdID);
            return View(reservering);
        }

        // GET: reserverings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservering = await _context.reserverings
                .Include(r => r.Wedstrijd)
                .FirstOrDefaultAsync(m => m.ReserveringID == id);
            if (reservering == null)
            {
                return NotFound();
            }

            return View(reservering);
        }

        // POST: reserverings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservering = await _context.reserverings.FindAsync(id);
            if (reservering != null)
            {
                _context.reserverings.Remove(reservering);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool reserveringExists(int id)
        {
            return _context.reserverings.Any(e => e.ReserveringID == id);
        }
    }
}
