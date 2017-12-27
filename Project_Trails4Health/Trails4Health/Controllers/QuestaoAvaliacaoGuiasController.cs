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
    public class QuestaoAvaliacaoGuiasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestaoAvaliacaoGuiasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestaoAvaliacaoGuias
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuestaoAvalicaoGuias.ToListAsync());
        }

        // GET: QuestaoAvaliacaoGuias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questaoAvaliacaoGuia = await _context.QuestaoAvalicaoGuias
                .SingleOrDefaultAsync(m => m.QuestaoID == id);
            if (questaoAvaliacaoGuia == null)
            {
                return NotFound();
            }

            return View(questaoAvaliacaoGuia);
        }

        // GET: QuestaoAvaliacaoGuias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestaoAvaliacaoGuias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestaoID,NomeQuestao,Desactivada,TipoRespostaID")] QuestaoAvaliacaoGuia questaoAvaliacaoGuia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questaoAvaliacaoGuia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questaoAvaliacaoGuia);
        }

        // GET: QuestaoAvaliacaoGuias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questaoAvaliacaoGuia = await _context.QuestaoAvalicaoGuias.SingleOrDefaultAsync(m => m.QuestaoID == id);
            if (questaoAvaliacaoGuia == null)
            {
                return NotFound();
            }
            return View(questaoAvaliacaoGuia);
        }

        // POST: QuestaoAvaliacaoGuias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestaoID,NomeQuestao,Desactivada,TipoRespostaID")] QuestaoAvaliacaoGuia questaoAvaliacaoGuia)
        {
            if (id != questaoAvaliacaoGuia.QuestaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questaoAvaliacaoGuia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestaoAvaliacaoGuiaExists(questaoAvaliacaoGuia.QuestaoID))
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
            return View(questaoAvaliacaoGuia);
        }

        // GET: QuestaoAvaliacaoGuias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questaoAvaliacaoGuia = await _context.QuestaoAvalicaoGuias
                .SingleOrDefaultAsync(m => m.QuestaoID == id);
            if (questaoAvaliacaoGuia == null)
            {
                return NotFound();
            }

            return View(questaoAvaliacaoGuia);
        }

        // POST: QuestaoAvaliacaoGuias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questaoAvaliacaoGuia = await _context.QuestaoAvalicaoGuias.SingleOrDefaultAsync(m => m.QuestaoID == id);
            _context.QuestaoAvalicaoGuias.Remove(questaoAvaliacaoGuia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestaoAvaliacaoGuiaExists(int id)
        {
            return _context.QuestaoAvalicaoGuias.Any(e => e.QuestaoID == id);
        }
    }
}
