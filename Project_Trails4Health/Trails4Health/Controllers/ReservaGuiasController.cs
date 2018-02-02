using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trails4Health.Models;

namespace Trails4Health.Controllers
{
    public class ReservaGuiasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservaGuiasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReservaGuias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ReservasGuia.Include(r => r.Guia).Include(r => r.Trilho).Include(r => r.Turista);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReservaGuias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaGuia = await _context.ReservasGuia
                .Include(r => r.Guia)
                .Include(r => r.Trilho)
                .Include(r => r.Turista)
                .SingleOrDefaultAsync(m => m.ReservaID == id);
            if (reservaGuia == null)
            {
                return NotFound();
            }

            return View(reservaGuia);
        }

        // GET: ReservaGuias/Create
        public IActionResult Create()
        {
            ViewData["GuiaID"] = new SelectList(_context.Guias, "GuiaID", "GuiaID");
            ViewData["TrilhoID"] = new SelectList(_context.Trilhos, "TrilhoID", "Detalhes");
            ViewData["TuristaID"] = new SelectList(_context.Turistas, "TuristaID", "TuristaID");
            return View();
        }

        // POST: ReservaGuias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservaID,ReservaParaDia,GuiaID,TuristaID,TrilhoID")] ReservaGuia reservaGuia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaGuia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuiaID"] = new SelectList(_context.Guias, "GuiaID", "GuiaID", reservaGuia.GuiaID);
            ViewData["TrilhoID"] = new SelectList(_context.Trilhos, "TrilhoID", "Detalhes", reservaGuia.TrilhoID);
            ViewData["TuristaID"] = new SelectList(_context.Turistas, "TuristaID", "TuristaID", reservaGuia.TuristaID);
            return View(reservaGuia);
        }

        // GET: ReservaGuias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaGuia = await _context.ReservasGuia.SingleOrDefaultAsync(m => m.ReservaID == id);
            if (reservaGuia == null)
            {
                return NotFound();
            }
            ViewData["GuiaID"] = new SelectList(_context.Guias, "GuiaID", "GuiaID", reservaGuia.GuiaID);
            ViewData["TrilhoID"] = new SelectList(_context.Trilhos, "TrilhoID", "Detalhes", reservaGuia.TrilhoID);
            ViewData["TuristaID"] = new SelectList(_context.Turistas, "TuristaID", "TuristaID", reservaGuia.TuristaID);
            return View(reservaGuia);
        }

        // POST: ReservaGuias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservaID,ReservaParaDia,GuiaID,TuristaID,TrilhoID")] ReservaGuia reservaGuia)
        {
            if (id != reservaGuia.ReservaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaGuia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaGuiaExists(reservaGuia.ReservaID))
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
            ViewData["GuiaID"] = new SelectList(_context.Guias, "GuiaID", "GuiaID", reservaGuia.GuiaID);
            ViewData["TrilhoID"] = new SelectList(_context.Trilhos, "TrilhoID", "Detalhes", reservaGuia.TrilhoID);
            ViewData["TuristaID"] = new SelectList(_context.Turistas, "TuristaID", "TuristaID", reservaGuia.TuristaID);
            return View(reservaGuia);
        }

        // GET: ReservaGuias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaGuia = await _context.ReservasGuia
                .Include(r => r.Guia)
                .Include(r => r.Trilho)
                .Include(r => r.Turista)
                .SingleOrDefaultAsync(m => m.ReservaID == id);
            if (reservaGuia == null)
            {
                return NotFound();
            }

            return View(reservaGuia);
        }

        // POST: ReservaGuias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaGuia = await _context.ReservasGuia.SingleOrDefaultAsync(m => m.ReservaID == id);
            _context.ReservasGuia.Remove(reservaGuia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaGuiaExists(int id)
        {
            return _context.ReservasGuia.Any(e => e.ReservaID == id);
        }
    }
}
