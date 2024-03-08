using Applicazione1.Data;
using Applicazione1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Applicazione1.Controllers
{
    public class PrenotazioneController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrenotazioneController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prenotazione
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Prenotazione.Include(p => p.Camera).Include(p => p.Cliente).Include(p => p.Pensione).Include(p => p.Servizi);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Prenotazione/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazione
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .Include(p => p.Servizi)
                .FirstOrDefaultAsync(m => m.IdPrenotazione == id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            return View(prenotazione);
        }

        // GET: Prenotazione/Create
        public IActionResult Create()
        {
            ViewData["IdCamera"] = new SelectList(_context.Camera, "IdCamera", "Tipo");
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Nome");
            ViewData["IdPensione"] = new SelectList(_context.Pensione, "IdPensione", "Tipo");
            return View();
        }

        // POST: Prenotazione/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,IdCamera,IdPensione,idServizio,DataInizio,DataFine,Acconto")] Prenotazione prenotazione)
        {
            ModelState.Remove("Cliente");
            ModelState.Remove("Camera");
            ModelState.Remove("Servizi");
            ModelState.Remove("Pensione");
            if (ModelState.IsValid)
            {
                if (PrenotazioneExists(prenotazione.IdCliente))
                {
                    ModelState.AddModelError("", "Esiste già una prenotazione per questo cliente.");
                    return View(prenotazione);
                }
                _context.Add(prenotazione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCamera"] = new SelectList(_context.Camera, "IdCamera", "Tipo", prenotazione.IdCamera);
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Nome", prenotazione.IdCliente);
            ViewData["IdPensione"] = new SelectList(_context.Pensione, "IdPensione", "Tipo", prenotazione.IdPensione);
            return View(prenotazione);
        }

        // GET: Prenotazione/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazione.FindAsync(id);
            if (prenotazione == null)
            {
                return NotFound();
            }
            ViewData["IdCamera"] = new SelectList(_context.Camera, "IdCamera", "Tipo", prenotazione.IdCamera);
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Nome", prenotazione.IdCliente);
            ViewData["IdPensione"] = new SelectList(_context.Pensione, "IdPensione", "Tipo", prenotazione.IdPensione);
            return View(prenotazione);
        }

        // POST: Prenotazione/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrenotazione,IdCliente,IdCamera,IdPensione,DataInizio,DataFine,Acconto")] Prenotazione prenotazione)
        {
            if (id != prenotazione.IdPrenotazione)
            {
                return NotFound();
            }

            ModelState.Remove("Cliente");
            ModelState.Remove("Camera");
            ModelState.Remove("Servizi");
            ModelState.Remove("Pensione");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prenotazione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrenotazioneExists(prenotazione.IdPrenotazione))
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
            ViewData["IdCamera"] = new SelectList(_context.Camera, "IdCamera", "Tipo", prenotazione.IdCamera);
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "Nome", prenotazione.IdCliente);
            ViewData["IdPensione"] = new SelectList(_context.Pensione, "IdPensione", "Tipo", prenotazione.IdPensione);
            return View(prenotazione);
        }

        // GET: Prenotazione/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazione
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .FirstOrDefaultAsync(m => m.IdPrenotazione == id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            return View(prenotazione);
        }

        // POST: Prenotazione/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prenotazione = await _context.Prenotazione.FindAsync(id);
            if (prenotazione != null)
            {
                _context.Prenotazione.Remove(prenotazione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrenotazioneExists(int id)
        {
            return _context.Prenotazione.Any(e => e.IdPrenotazione == id);
        }

        [HttpGet]
        public async Task<IActionResult> PrenotazioniCompleta()
        {
            var prenotazione = await _context.Prenotazione.Include(p => p.Pensione).Where(p => p.Pensione.Tipo == "Pensione Completa").Select(p => new
            {
                IdPrenotazione = p.IdPrenotazione,
                DataInizio = p.DataInizio,
                DataFine = p.DataFine,
                Acconto = p.Acconto,
                Pensione = p.Pensione.Tipo
            }).ToListAsync();
            return Json(prenotazione);
        }
    }
}
