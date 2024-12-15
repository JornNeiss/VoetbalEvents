using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoetbalEvents.Data;
using VoetbalEvents.Models;

namespace VoetbalEvents.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        // Voeg de ApplicationDbContext toe via dependency injection
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Haal de aankomende wedstrijden op
            var aankomendeWedstrijden = await _context.Wedstrijds
                .Where(w => w.Datum > DateTime.Now)
                .OrderBy(w => w.Datum)
                .Take(5) // Limiteer tot de eerstvolgende 5 wedstrijden
                .ToListAsync();

            // Zet de aankomende wedstrijden in de ViewData
            ViewData["AankomendeWedstrijden"] = aankomendeWedstrijden;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
