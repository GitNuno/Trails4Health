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
    public class QuestaoAvaliacaoTrilhosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestaoAvaliacaoTrilhosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestaoAvaliacaoTrilhos
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuestaoAvalicaoTrilhos.ToListAsync());
        }

        // GET: QuestaoAvaliacaoTrilhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questaoAvaliacaoTrilho = await _context.QuestaoAvalicaoTrilhos
                .SingleOrDefaultAsync(m => m.QuestaoID == id);
            if (questaoAvaliacaoTrilho == null)
            {
                return NotFound();
            }

            return View(questaoAvaliacaoTrilho);
        }

        // GET: QuestaoAvaliacaoTrilhos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestaoAvaliacaoTrilhos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestaoID,NomeQuestao,Desactivada,TipoRespostaID")] QuestaoAvaliacaoTrilho questaoAvaliacaoTrilho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questaoAvaliacaoTrilho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questaoAvaliacaoTrilho);
        }

        // GET: QuestaoAvaliacaoTrilhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questaoAvaliacaoTrilho = await _context.QuestaoAvalicaoTrilhos.SingleOrDefaultAsync(m => m.QuestaoID == id);
            if (questaoAvaliacaoTrilho == null)
            {
                return NotFound();
            }
            return View(questaoAvaliacaoTrilho);
        }

        // POST: QuestaoAvaliacaoTrilhos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestaoID,NomeQuestao,Desactivada,TipoRespostaID")] QuestaoAvaliacaoTrilho questaoAvaliacaoTrilho)
        {
            if (id != questaoAvaliacaoTrilho.QuestaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questaoAvaliacaoTrilho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestaoAvaliacaoTrilhoExists(questaoAvaliacaoTrilho.QuestaoID))
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
            return View(questaoAvaliacaoTrilho);
        }

        // GET: QuestaoAvaliacaoTrilhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questaoAvaliacaoTrilho = await _context.QuestaoAvalicaoTrilhos
                .SingleOrDefaultAsync(m => m.QuestaoID == id);
            if (questaoAvaliacaoTrilho == null)
            {
                return NotFound();
            }

            return View(questaoAvaliacaoTrilho);
        }

        // POST: QuestaoAvaliacaoTrilhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questaoAvaliacaoTrilho = await _context.QuestaoAvalicaoTrilhos.SingleOrDefaultAsync(m => m.QuestaoID == id);
            _context.QuestaoAvalicaoTrilhos.Remove(questaoAvaliacaoTrilho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestaoAvaliacaoTrilhoExists(int id)
        {
            return _context.QuestaoAvalicaoTrilhos.Any(e => e.QuestaoID == id);
        }
    }
}
