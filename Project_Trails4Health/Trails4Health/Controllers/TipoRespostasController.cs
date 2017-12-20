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
    public class TipoRespostasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoRespostasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoRespostas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposRespostas.ToListAsync());
        }

        // GET: TipoRespostas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoResposta = await _context.TiposRespostas
                .SingleOrDefaultAsync(m => m.TipoRespostaID == id);
            if (tipoResposta == null)
            {
                return NotFound();
            }

            return View(tipoResposta);
        }

        // GET: TipoRespostas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoRespostas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoRespostaID,Descricao")] TipoResposta tipoResposta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoResposta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoResposta);
        }

        // GET: TipoRespostas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoResposta = await _context.TiposRespostas.SingleOrDefaultAsync(m => m.TipoRespostaID == id);
            if (tipoResposta == null)
            {
                return NotFound();
            }
            return View(tipoResposta);
        }

        // POST: TipoRespostas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoRespostaID,Descricao")] TipoResposta tipoResposta)
        {
            if (id != tipoResposta.TipoRespostaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoResposta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoRespostaExists(tipoResposta.TipoRespostaID))
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
            return View(tipoResposta);
        }

        // GET: TipoRespostas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoResposta = await _context.TiposRespostas
                .SingleOrDefaultAsync(m => m.TipoRespostaID == id);
            if (tipoResposta == null)
            {
                return NotFound();
            }

            return View(tipoResposta);
        }

        // POST: TipoRespostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoResposta = await _context.TiposRespostas.SingleOrDefaultAsync(m => m.TipoRespostaID == id);
            _context.TiposRespostas.Remove(tipoResposta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoRespostaExists(int id)
        {
            return _context.TiposRespostas.Any(e => e.TipoRespostaID == id);
        }
    }
}
