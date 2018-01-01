using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trails4Health.Models;
using Trails4Health.Models.ViewModels;

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
            //ViewData["DificuldadeID"] = new SelectList(_context.Dificuldades, "DificuldadeID", "Nome");
            return View(trilho);
        }

        // GET: Trilhoes/Create
        public IActionResult Create()
        {
            // viewBag recebe valores do tipo ViewData["DificuldadeID"] em runTime
            // Nome é o campo de texto referente ao DificuldadeID
            ViewData["DificuldadeID"] = new SelectList(_context.Dificuldades, "DificuldadeID", "Nome");
            ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "Nome");
            return View();
        }

        // POST: Trilhoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrilhoID,TrilhoNome,TrilhoInicio,TrilhoFim,TrilhoDetalhes,TrilhoDistancia,TrilhoFoto, TrilhoDesativado,DificuldadeID,EstadoID")] ViewModelTrilho VMTrilho)
        { 
            if (ModelState.IsValid)
            {
                ////// ++++ não atualiza TrilhoID na tb EstadoTrilho ???
                //estadoTrilho.TrilhoID = trilho.TrilhoID; //se fizer Ex: 7 funciona !
                //estadoTrilho.DataInicio = DateTime.Now;
                //estadoTrilho.EstadoID = 1;

                Trilho trilho = new Trilho
                {
                    Nome = VMTrilho.TrilhoNome,
                    Inicio = VMTrilho.TrilhoInicio,
                    Fim = VMTrilho.TrilhoFim,
                    Distancia = VMTrilho.TrilhoDistancia,
                    Foto = VMTrilho.TrilhoFoto,
                    Desativado = VMTrilho.TrilhoDesativado,
                    Detalhes = VMTrilho.TrilhoDetalhes,
                    DificuldadeID = VMTrilho.DificuldadeID
                };

                _context.Add(trilho);
                //await _context.SaveChangesAsync();

                EstadoTrilho estadoTrilho = new EstadoTrilho
                {
                    Trilho = trilho,
                    EstadoID = VMTrilho.EstadoID,
                    DataInicio = DateTime.Now,
                };

                _context.Add(estadoTrilho);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            ViewData["DificuldadeID"] = new SelectList(_context.Dificuldades, "DificuldadeID", "DificuldadeID", VMTrilho.DificuldadeID);
            return View(VMTrilho);
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
            ViewData["DificuldadeID"] = new SelectList(_context.Dificuldades, "DificuldadeID", "Nome", trilho.DificuldadeID);
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
            trilho.Desativado = true;
            //_context.Trilhos.Remove(trilho);
            _context.Trilhos.Update(trilho);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TrilhoExists(int id)
        {
            return _context.Trilhos.Any(e => e.TrilhoID == id);
        }
    }
}
