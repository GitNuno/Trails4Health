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
    public class RespostasAvaliacaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RespostasAvaliacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RespostasAvaliacao
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RespostasAvaliacao.Include(r => r.Guia).Include(r => r.Opcao).Include(r => r.Questao).Include(r => r.Turista);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RespostasAvaliacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostaAvaliacao = await _context.RespostasAvaliacao
                .Include(r => r.Guia)
                .Include(r => r.Opcao)
                .Include(r => r.Questao)
                .Include(r => r.Turista)
                .SingleOrDefaultAsync(m => m.RespostaID == id);
            if (respostaAvaliacao == null)
            {
                return NotFound();
            }

            return View(respostaAvaliacao);
        }

        // GET: RespostasAvaliacao/Create
        public IActionResult Create()
        {
            ViewData["GuiaID"] = new SelectList(_context.Guias, "GuiaID", "GuiaID");
            ViewData["OpcaoID"] = new SelectList(_context.Opcoes, "OpcaoID", "OpcaoID");
            ViewData["QuestaoID"] = new SelectList(_context.Questoes, "QuestaoID", "QuestaoID");
            ViewData["TuristaID"] = new SelectList(_context.Turistas, "TuristaID", "TuristaID");
            return View();
        }

        // POST: RespostasAvaliacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RespostaID,Data,QuestaoID,TuristaID,GuiaID,OpcaoID")] RespostaAvaliacao respostaAvaliacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(respostaAvaliacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuiaID"] = new SelectList(_context.Guias, "GuiaID", "GuiaID", respostaAvaliacao.GuiaID);
            ViewData["OpcaoID"] = new SelectList(_context.Opcoes, "OpcaoID", "OpcaoID", respostaAvaliacao.OpcaoID);
            ViewData["QuestaoID"] = new SelectList(_context.Questoes, "QuestaoID", "QuestaoID", respostaAvaliacao.QuestaoID);
            ViewData["TuristaID"] = new SelectList(_context.Turistas, "TuristaID", "TuristaID", respostaAvaliacao.TuristaID);
            return View(respostaAvaliacao);
        }

        // GET: RespostasAvaliacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostaAvaliacao = await _context.RespostasAvaliacao.SingleOrDefaultAsync(m => m.RespostaID == id);
            if (respostaAvaliacao == null)
            {
                return NotFound();
            }
            ViewData["GuiaID"] = new SelectList(_context.Guias, "GuiaID", "GuiaID", respostaAvaliacao.GuiaID);
            ViewData["OpcaoID"] = new SelectList(_context.Opcoes, "OpcaoID", "OpcaoID", respostaAvaliacao.OpcaoID);
            ViewData["QuestaoID"] = new SelectList(_context.Questoes, "QuestaoID", "QuestaoID", respostaAvaliacao.QuestaoID);
            ViewData["TuristaID"] = new SelectList(_context.Turistas, "TuristaID", "TuristaID", respostaAvaliacao.TuristaID);
            return View(respostaAvaliacao);
        }

        // POST: RespostasAvaliacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RespostaID,Data,QuestaoID,TuristaID,GuiaID,OpcaoID")] RespostaAvaliacao respostaAvaliacao)
        {
            if (id != respostaAvaliacao.RespostaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(respostaAvaliacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespostaAvaliacaoExists(respostaAvaliacao.RespostaID))
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
            ViewData["GuiaID"] = new SelectList(_context.Guias, "GuiaID", "GuiaID", respostaAvaliacao.GuiaID);
            ViewData["OpcaoID"] = new SelectList(_context.Opcoes, "OpcaoID", "OpcaoID", respostaAvaliacao.OpcaoID);
            ViewData["QuestaoID"] = new SelectList(_context.Questoes, "QuestaoID", "QuestaoID", respostaAvaliacao.QuestaoID);
            ViewData["TuristaID"] = new SelectList(_context.Turistas, "TuristaID", "TuristaID", respostaAvaliacao.TuristaID);
            return View(respostaAvaliacao);
        }

        // GET: RespostasAvaliacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostaAvaliacao = await _context.RespostasAvaliacao
                .Include(r => r.Guia)
                .Include(r => r.Opcao)
                .Include(r => r.Questao)
                .Include(r => r.Turista)
                .SingleOrDefaultAsync(m => m.RespostaID == id);
            if (respostaAvaliacao == null)
            {
                return NotFound();
            }

            return View(respostaAvaliacao);
        }

        // POST: RespostasAvaliacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var respostaAvaliacao = await _context.RespostasAvaliacao.SingleOrDefaultAsync(m => m.RespostaID == id);
            _context.RespostasAvaliacao.Remove(respostaAvaliacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RespostaAvaliacaoExists(int id)
        {
            return _context.RespostasAvaliacao.Any(e => e.RespostaID == id);
        }
    }
}
