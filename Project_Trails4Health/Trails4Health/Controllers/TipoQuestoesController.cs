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
    public class TipoQuestoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoQuestoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoQuestoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoQuestoes.ToListAsync());
        }

        // GET: TipoQuestoes/Detalhes/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoQuestao = await _context.TipoQuestoes
                .SingleOrDefaultAsync(m => m.TipoQuestaoID == id);
            if (tipoQuestao == null)
            {
                return NotFound();
            }

            return View(tipoQuestao);
        }

        // GET: TipoQuestoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoQuestoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoQuestaoID,Nome")] TipoQuestao tipoQuestao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoQuestao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoQuestao);
        }

        // GET: TipoQuestoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoQuestao = await _context.TipoQuestoes.SingleOrDefaultAsync(m => m.TipoQuestaoID == id);
            if (tipoQuestao == null)
            {
                return NotFound();
            }
            return View(tipoQuestao);
        }

        // POST: TipoQuestoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoQuestaoID,Nome")] TipoQuestao tipoQuestao)
        {
            if (id != tipoQuestao.TipoQuestaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoQuestao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoQuestaoExists(tipoQuestao.TipoQuestaoID))
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
            return View(tipoQuestao);
        }

        // GET: TipoQuestoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoQuestao = await _context.TipoQuestoes
                .SingleOrDefaultAsync(m => m.TipoQuestaoID == id);
            if (tipoQuestao == null)
            {
                return NotFound();
            }

            return View(tipoQuestao);
        }

        // POST: TipoQuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoQuestao = await _context.TipoQuestoes.SingleOrDefaultAsync(m => m.TipoQuestaoID == id);
            _context.TipoQuestoes.Remove(tipoQuestao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoQuestaoExists(int id)
        {
            return _context.TipoQuestoes.Any(e => e.TipoQuestaoID == id);
        }
    }
}
