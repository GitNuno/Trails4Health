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
    public class TrilhoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrilhoesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Trilhoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trilhos.Include(t => t.Dificuldade);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Trilhoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilhos
                .Include(t => t.Dificuldade)
                .SingleOrDefaultAsync(m => m.TrilhoID == id);
            if (trilho == null)
            {
                return NotFound();
            }

            return View(trilho);
        }

        // GET: Trilhoes/Create
        public IActionResult Create()
        {
            ViewData["DificuldadeID"] = new SelectList(_context.Dificuldades, "DificuldadeID", "DificuldadeID");
            return View();
        }

        // POST: Trilhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrilhoID,Nome,Inicio,Fim,Detalhes,Distancia,Foto,Desativado,DificuldadeID")] Trilho trilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trilho);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DificuldadeID"] = new SelectList(_context.Dificuldades, "DificuldadeID", "DificuldadeID", trilho.DificuldadeID);
            return View(trilho);
        }

        // GET: Trilhoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilhos.SingleOrDefaultAsync(m => m.TrilhoID == id);
            if (trilho == null)
            {
                return NotFound();
            }
            ViewData["DificuldadeID"] = new SelectList(_context.Dificuldades, "DificuldadeID", "DificuldadeID", trilho.DificuldadeID);
            return View(trilho);
        }

        // POST: Trilhoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrilhoID,Nome,Inicio,Fim,Detalhes,Distancia,Foto,Desativado,DificuldadeID")] Trilho trilho)
        {
            if (id != trilho.TrilhoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrilhoExists(trilho.TrilhoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["DificuldadeID"] = new SelectList(_context.Dificuldades, "DificuldadeID", "DificuldadeID", trilho.DificuldadeID);
            return View(trilho);
        }

        // GET: Trilhoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilho = await _context.Trilhos
                .Include(t => t.Dificuldade)
                .SingleOrDefaultAsync(m => m.TrilhoID == id);
            if (trilho == null)
            {
                return NotFound();
            }

            return View(trilho);
        }

        // POST: Trilhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trilho = await _context.Trilhos.SingleOrDefaultAsync(m => m.TrilhoID == id);
            _context.Trilhos.Remove(trilho);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TrilhoExists(int id)
        {
            return _context.Trilhos.Any(e => e.TrilhoID == id);
        }
    }
}
