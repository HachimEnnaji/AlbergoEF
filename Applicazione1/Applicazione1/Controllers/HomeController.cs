using Applicazione1.Data;
using Applicazione1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Applicazione1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
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

        [HttpGet]
        public async Task<IActionResult> PrenotazioneCliente(string codiceFiscale)
        {
            try
            {
                var datiCliente = await _context.Cliente.SingleOrDefaultAsync(c => c.CodiceFiscale == codiceFiscale);
                if (datiCliente == null)
                {
                    return NotFound(new { message = "Cliente non trovato" });
                }
                return Ok(datiCliente);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero delle spedizioni di oggi");
                return StatusCode(500, new { message = "Errore interno del server" });
            }
        }

    }
}
