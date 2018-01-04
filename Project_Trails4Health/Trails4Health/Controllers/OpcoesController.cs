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
    public class OpcoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpcoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Opcoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Opcoes.Include(o => o.Questao);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Opcoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opcao = await _context.Opcoes
                .Include(o => o.Questao)
                .SingleOrDefaultAsync(m => m.OpcaoID == id);
            if (opcao == null)
            {
                return NotFound();
            }

            return View(opcao);
        }

        // GET: Opcoes/Create
        public IActionResult Create()
        {
            ViewData["QuestaoID"] = new SelectList(_context.Questoes, "QuestaoID", "QuestaoID");
            return View();
        }

        // POST: Opcoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OpcaoID,QuestaoID")] Opcao opcao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opcao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuestaoID"] = new SelectList(_context.Questoes, "QuestaoID", "QuestaoID", opcao.QuestaoID);
            return View(opcao);
        }

        // GET: Opcoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opcao = await _context.Opcoes.SingleOrDefaultAsync(m => m.OpcaoID == id);
            if (opcao == null)
            {
                return NotFound();
            }
            ViewData["QuestaoID"] = new SelectList(_context.Questoes, "QuestaoID", "QuestaoID", opcao.QuestaoID);
            return View(opcao);
        }

        // POST: Opcoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OpcaoID,QuestaoID")] Opcao opcao)
        {
            if (id != opcao.OpcaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opcao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpcaoExists(opcao.OpcaoID))
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
            ViewData["QuestaoID"] = new SelectList(_context.Questoes, "QuestaoID", "QuestaoID", opcao.QuestaoID);
            return View(opcao);
        }

        // GET: Opcoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opcao = await _context.Opcoes
                .Include(o => o.Questao)
                .SingleOrDefaultAsync(m => m.OpcaoID == id);
            if (opcao == null)
            {
                return NotFound();
            }

            return View(opcao);
        }

        // POST: Opcoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opcao = await _context.Opcoes.SingleOrDefaultAsync(m => m.OpcaoID == id);
            _context.Opcoes.Remove(opcao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpcaoExists(int id)
        {
            return _context.Opcoes.Any(e => e.OpcaoID == id);
        }
    }
}
