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
    public class RespostasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RespostasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Respostas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Respostas.Include(r => r.Opcao).Include(r => r.Turista);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Respostas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resposta = await _context.Respostas
                .Include(r => r.Opcao)
                .Include(r => r.Turista)
                .SingleOrDefaultAsync(m => m.OpcaoID == id);
            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // GET: Respostas/Create
        public IActionResult Create()
        {
            ViewData["OpcaoID"] = new SelectList(_context.Opcoes, "OpcaoID", "OpcaoID");
            ViewData["TuristaID"] = new SelectList(_context.Turistas, "TuristaID", "TuristaID");
            return View();
        }

        // POST: Respostas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TuristaID,OpcaoID")] Resposta resposta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resposta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OpcaoID"] = new SelectList(_context.Opcoes, "OpcaoID", "OpcaoID", resposta.OpcaoID);
            ViewData["TuristaID"] = new SelectList(_context.Turistas, "TuristaID", "TuristaID", resposta.TuristaID);
            return View(resposta);
        }

        // GET: Respostas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resposta = await _context.Respostas.SingleOrDefaultAsync(m => m.OpcaoID == id);
            if (resposta == null)
            {
                return NotFound();
            }
            ViewData["OpcaoID"] = new SelectList(_context.Opcoes, "OpcaoID", "OpcaoID", resposta.OpcaoID);
            ViewData["TuristaID"] = new SelectList(_context.Turistas, "TuristaID", "TuristaID", resposta.TuristaID);
            return View(resposta);
        }

        // POST: Respostas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TuristaID,OpcaoID")] Resposta resposta)
        {
            if (id != resposta.OpcaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resposta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespostaExists(resposta.OpcaoID))
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
            ViewData["OpcaoID"] = new SelectList(_context.Opcoes, "OpcaoID", "OpcaoID", resposta.OpcaoID);
            ViewData["TuristaID"] = new SelectList(_context.Turistas, "TuristaID", "TuristaID", resposta.TuristaID);
            return View(resposta);
        }

        // GET: Respostas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resposta = await _context.Respostas
                .Include(r => r.Opcao)
                .Include(r => r.Turista)
                .SingleOrDefaultAsync(m => m.OpcaoID == id);
            if (resposta == null)
            {
                return NotFound();
            }

            return View(resposta);
        }

        // POST: Respostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resposta = await _context.Respostas.SingleOrDefaultAsync(m => m.OpcaoID == id);
            _context.Respostas.Remove(resposta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RespostaExists(int id)
        {
            return _context.Respostas.Any(e => e.OpcaoID == id);
        }
    }
}
