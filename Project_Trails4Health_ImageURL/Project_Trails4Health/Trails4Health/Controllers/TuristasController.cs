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
    public class TuristasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TuristasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Turistas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Turistas.ToListAsync());
        }

        // GET: Turistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await _context.Turistas
                .SingleOrDefaultAsync(m => m.TuristaID == id);
            if (turista == null)
            {
                return NotFound();
            }

            return View(turista);
        }

        // GET: Turistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turistas/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TuristaID,Nome,Telefone,Morada,Email,DataNascimento,Idade,Nif")] Turista turista)
        {
            // EX NIF Válido: 504615947
            int ultimoDigitoNIF = turista.Nif % 10;
            int digitoControlo = DigitoControlo(turista.Nif);

            if(ultimoDigitoNIF != digitoControlo)
            {
                ViewData["ErroDigitoControlo"] = "*NIF inválido!";
                return View(turista);
            }

            if (ModelState.IsValid)
            {
                _context.Add(turista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turista);
        }

        // GET: Turistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await _context.Turistas.SingleOrDefaultAsync(m => m.TuristaID == id);
            if (turista == null)
            {
                return NotFound();
            }
            return View(turista);
        }

        // POST: Turistas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TuristaID,Nome,Telefone,Morada,Email,DataNascimento,Idade,Nif")] Turista turista)
        {
            if (id != turista.TuristaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuristaExists(turista.TuristaID))
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
            return View(turista);
        }

        // GET: Turistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await _context.Turistas
                .SingleOrDefaultAsync(m => m.TuristaID == id);
            if (turista == null)
            {
                return NotFound();
            }

            return View(turista);
        }

        // POST: Turistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turista = await _context.Turistas.SingleOrDefaultAsync(m => m.TuristaID == id);
            _context.Turistas.Remove(turista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TuristaExists(int id)
        {
            return _context.Turistas.Any(e => e.TuristaID == id);
        }

        private int DigitoControlo(int nif)
        {

            int digito;
            int[] arrDigitos = new int[8];
            int soma = 0;
            int n = 2;
            int resto;
            int digitoControlo;

            for (int i = 0; i < 8; i++)
            {
                nif /= 10;
                digito = nif % 10; // 1º valor é o 8º digito!
                arrDigitos[i] = digito;

                soma += arrDigitos[i] * n;
                n++;
            }

            resto = soma % 11;

            if (resto == 0 || resto == 1)
            {
                digitoControlo = 0;
            }
            else
            {
                digitoControlo = 11 - resto;
            }
            return digitoControlo;
        }
    }
}
