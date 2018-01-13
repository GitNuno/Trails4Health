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
    public class QuestoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Questoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Questoes.Include(q => q.TipoQuestao);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Questoes/Detalhes/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questao = await _context.Questoes
                .Include(q => q.TipoQuestao)
                .SingleOrDefaultAsync(m => m.QuestaoID == id);
            if (questao == null)
            {
                return NotFound();
            }

            return View(questao);
        }

        // GET: Questoes/Create
        public IActionResult Create()
        {
            ViewData["TipoQuestaoID"] = new SelectList(_context.TipoQuestoes, "TipoQuestaoID", "TipoQuestaoID");
            return View();
        }

        // POST: Questoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestaoID,NomeQuestao,Desactivada,TipoResposta,ValorMaximo,ValorMinimo,NumeroOpcoes,TipoQuestaoID")] Questao questao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoQuestaoID"] = new SelectList(_context.TipoQuestoes, "TipoQuestaoID", "TipoQuestaoID", questao.TipoQuestaoID);
            return View(questao);
        }

        // GET: Questoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questao = await _context.Questoes.SingleOrDefaultAsync(m => m.QuestaoID == id);
            if (questao == null)
            {
                return NotFound();
            }
            ViewData["TipoQuestaoID"] = new SelectList(_context.TipoQuestoes, "TipoQuestaoID", "TipoQuestaoID", questao.TipoQuestaoID);
            return View(questao);
        }

        // POST: Questoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestaoID,NomeQuestao,Desactivada,TipoResposta,ValorMaximo,ValorMinimo,NumeroOpcoes,TipoQuestaoID")] Questao questao)
        {
            if (id != questao.QuestaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestaoExists(questao.QuestaoID))
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
            ViewData["TipoQuestaoID"] = new SelectList(_context.TipoQuestoes, "TipoQuestaoID", "TipoQuestaoID", questao.TipoQuestaoID);
            return View(questao);
        }

        // GET: Questoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questao = await _context.Questoes
                .Include(q => q.TipoQuestao)
                .SingleOrDefaultAsync(m => m.QuestaoID == id);
            if (questao == null)
            {
                return NotFound();
            }

            return View(questao);
        }

        // POST: Questoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questao = await _context.Questoes.SingleOrDefaultAsync(m => m.QuestaoID == id);
            _context.Questoes.Remove(questao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestaoExists(int id)
        {
            return _context.Questoes.Any(e => e.QuestaoID == id);
        }
    }
}
