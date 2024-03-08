using Applicazione1.Data;
using Applicazione1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Applicazione1.Controllers
{
    public class ServizioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServizioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Servizio
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Servizio.Include(s => s.Prenotazione);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Servizio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servizio = await _context.Servizio
                .Include(s => s.Prenotazione)
                .FirstOrDefaultAsync(m => m.IdServizio == id);
            if (servizio == null)
            {
                return NotFound();
            }

            return View(servizio);
        }

        // GET: Servizio/Create
        public IActionResult Create()
        {
            ViewBag.TipoServizio = new SelectList(TipoServizio.ListaServizi);
            ViewBag.IdPrenotazione = new SelectList(_context.Prenotazione, "IdPrenotazione", "IdPrenotazione");

            return View();
        }

        // POST: Servizio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdServizio,IdPrenotazione,Tipo,Costo")] Servizio servizio)
        {
            ModelState.Remove("Prenotazione");
            if (ModelState.IsValid)
            {
                _context.Add(servizio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.TipoServizio = new SelectList(TipoServizio.ListaServizi);
            ViewBag.IdPrenotazione = new SelectList(_context.Prenotazione, "IdPrenotazione", "IdPrenotazione");



            return View(servizio);
        }

        // GET: Servizio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servizio = await _context.Servizio.FindAsync(id);
            if (servizio == null)
            {
                return NotFound();
            }
            ViewBag.TipoServizio = new SelectList(TipoServizio.ListaServizi);
            ViewBag.IdPrenotazione = new SelectList(_context.Prenotazione, "IdPrenotazione", "IdPrenotazione");


            return View(servizio);
        }

        // POST: Servizio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdServizio,IdPrenotazione,Tipo,Costo")] Servizio servizio)
        {
            if (id != servizio.IdServizio)
            {
                return NotFound();
            }
            ModelState.Remove("Prenotazione");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servizio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServizioExists(servizio.IdServizio))
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
            ViewBag.TipoServizio = new SelectList(TipoServizio.ListaServizi);
            ViewBag.IdPrenotazione = new SelectList(_context.Prenotazione, "IdPrenotazione", "IdPrenotazione");


            return View(servizio);
        }

        // GET: Servizio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servizio = await _context.Servizio
                .Include(s => s.Prenotazione)
                .FirstOrDefaultAsync(m => m.IdServizio == id);
            if (servizio == null)
            {
                return NotFound();
            }

            return View(servizio);
        }

        // POST: Servizio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servizio = await _context.Servizio.FindAsync(id);
            if (servizio != null)
            {
                _context.Servizio.Remove(servizio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServizioExists(int id)
        {
            return _context.Servizio.Any(e => e.IdServizio == id);
        }
    }
}
