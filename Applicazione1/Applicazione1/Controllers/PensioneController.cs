using Applicazione1.Data;
using Applicazione1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Applicazione1.Controllers
{
    public class PensioneController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PensioneController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pensiones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pensione.ToListAsync());
        }

        // GET: Pensiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pensione = await _context.Pensione
                .FirstOrDefaultAsync(m => m.IdPensione == id);
            if (pensione == null)
            {
                return NotFound();
            }

            return View(pensione);
        }

        // GET: Pensiones/Create
        public IActionResult Create()
        {
            ViewBag.TipoPensione = new SelectList(TipoPensione.ListaPensioni);
            return View();
        }

        // POST: Pensiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPensione,Tipo,Costo")] Pensione pensione)
        {
            ModelState.Remove("Prenotazione");
            if (ModelState.IsValid)
            {
                _context.Add(pensione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TipoPensione = new SelectList(TipoPensione.ListaPensioni);
            return View(pensione);
        }

        // GET: Pensiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.TipoPensione = new SelectList(TipoPensione.ListaPensioni);
            if (id == null)
            {
                return NotFound();
            }

            var pensione = await _context.Pensione.FindAsync(id);
            if (pensione == null)
            {
                return NotFound();
            }
            return View(pensione);
        }

        // POST: Pensiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPensione,Tipo,Costo")] Pensione pensione)
        {
            if (id != pensione.IdPensione)
            {
                return NotFound();
            }
            ModelState.Remove("Prenotazione");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pensione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PensioneExists(pensione.IdPensione))
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
            ViewBag.TipoPensione = new SelectList(TipoPensione.ListaPensioni);

            return View(pensione);
        }

        // GET: Pensiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pensione = await _context.Pensione
                .FirstOrDefaultAsync(m => m.IdPensione == id);
            if (pensione == null)
            {
                return NotFound();
            }

            return View(pensione);
        }

        // POST: Pensiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pensione = await _context.Pensione.FindAsync(id);
            if (pensione != null)
            {
                _context.Pensione.Remove(pensione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PensioneExists(int id)
        {
            return _context.Pensione.Any(e => e.IdPensione == id);
        }
    }
}
