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
    public class TrilhoCRUDController : Controller
    {
        // para listar EstadoTrilhos em Detalhes
        private IEnumerable<EstadoTrilho> ListaEstadoTrilhosBD;
        private IEnumerable<EstadoTrilho> ListaEstadoTrilhosBD2;
        // para pesquisar Nome em dbo.Trilho: msg ErroNomeTrilho em Criar
        private IEnumerable<Trilho> ListaTrilhosBD;        
        // usada em Editar: GET
        private int estadoId;


        private readonly ApplicationDbContext _context;
        private ITrails4HealthRepository repository;  // para Listar Trilhos em BackOffice

        // ORIG: TrilhoCRUDController(ApplicationDbContext context)
        public TrilhoCRUDController(ApplicationDbContext context, ITrails4HealthRepository repository)
        {
            _context = context;
            this.repository = repository; 
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trilhos.Include(t => t.Dificuldade);
            return View(await applicationDbContext.ToListAsync());
        }

        // paginação
        // Listar Trilhos em BackOffice
        public int TamanhoPagina = 3;
        public ViewResult ListaTrilhos(int pagina = 1)
        {
            return View(
                new ViewModelListaTrilhos
                {
                    Trilho = repository.Trilhos
                        .Skip(TamanhoPagina * (pagina - 1))
                        .Take(TamanhoPagina),
                    InfoPaginacao = new InfoPaginacao
                    {
                        PaginaAtual = pagina,
                        ItemsPorPagina = TamanhoPagina,
                        TotalItems = repository.Trilhos.Count()
                    }
                }); // BEFORE ViewModel: return View(repository.Trilhos)
        }

        // GET: Detalhes
        public async Task<IActionResult> Detalhes(int? id)
        {

            if (id == null)
            {
                return NotFound("ID NotFound");
            }

            var trilho = await _context.Trilhos
                .Include(t => t.Dificuldade)
                .SingleOrDefaultAsync(m => m.TrilhoID == id);


            var estadoTrilhos = _context.EstadoTrilhos
                .Include(et => et.Estado)
                .Include(et => et.Trilho);

            ListaEstadoTrilhosBD = estadoTrilhos.ToListAsync().Result;

            ViewModelTrilho viewModelTrilho = new ViewModelTrilho
            {
                TrilhoID = trilho.TrilhoID,
                TrilhoNome = trilho.Nome,
                TrilhoInicio = trilho.Inicio,
                TrilhoFim = trilho.Fim,
                TrilhoSumario = trilho.Sumario,
                TrilhoDetalhes = trilho.Detalhes,
                TrilhoFoto = trilho.Foto,
                TrilhoDistancia = trilho.Distancia,
                TrilhoDesativado = trilho.Desativado,
                Dificuldade = trilho.Dificuldade,
                EstadoTrilhos = ListaEstadoTrilhosBD
            };

            if (trilho == null)
            {
                return NotFound();
            }
            //ViewData["DificuldadeID"] = new SelectList(_context.Dificuldades, "DificuldadeID", "Nome");
            return View(viewModelTrilho);
        }

        // GET: Create
        public IActionResult Criar()
        {
            // viewBag recebe valores do tipo ViewData["DificuldadeID"] em runTime
            // SelectList(tabelaBD,valoresColuna,nomeColuna) | nota: valores vao ser recebidos num dropDownList
            ViewData["DificuldadeID"] = new SelectList(_context.Dificuldades, "DificuldadeID", "Nome");
            ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "Nome");
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("TrilhoID,TrilhoNome,TrilhoInicio,TrilhoFim,TrilhoDetalhes,TrilhoSumario,TrilhoDistancia,TrilhoFoto, TrilhoDesativado,DificuldadeID,EstadoID")] ViewModelTrilho trilhoVM)
        {
            // Colocar registos da dbo.Trilhos numa lista
            var trilhos = _context.Trilhos
              .Include(t => t.Dificuldade);

            ListaTrilhosBD = trilhos.ToListAsync().Result;

            // se existir um trilho com o mesmo Nome, reinsere dados introduzidos na mma View c\ msg ErroNomeTrilho!
            foreach (var et in ListaTrilhosBD)
            {
                if (et.Nome.Equals(trilhoVM.TrilhoNome))
                {
                    ViewData["ErroNomeTrilho"] = "*Já existe um trilho com esse nome!";
                    ViewData["DificuldadeID"] = new SelectList(_context.Dificuldades, "DificuldadeID", "Nome", trilhoVM.DificuldadeID);
                    ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "Nome", trilhoVM.EstadoID);
                    return View(trilhoVM);
                }
            }

            if (ModelState.IsValid)
            {
                // crio novo trilho a partir dos valores introduzidos no form (ver Bind)
                Trilho trilho = new Trilho
                {
                    Nome = trilhoVM.TrilhoNome,
                    Inicio = trilhoVM.TrilhoInicio,
                    Fim = trilhoVM.TrilhoFim,
                    Distancia = trilhoVM.TrilhoDistancia,
                    Foto = trilhoVM.TrilhoFoto,
                    Desativado = trilhoVM.TrilhoDesativado,
                    Detalhes = trilhoVM.TrilhoDetalhes,
                    Sumario = trilhoVM.TrilhoSumario,
                    DificuldadeID = trilhoVM.DificuldadeID
                };

                // coloco trilho na tabela dbo.Trilhos
                _context.Add(trilho);
               
                // crio novo EstadoTrilho a partir de trilho, EstadoID(Bind) e DataInicio(DateTime)
                EstadoTrilho estadoTrilho = new EstadoTrilho
                {
                    Trilho = trilho,
                    EstadoID = trilhoVM.EstadoID,
                    DataInicio = DateTime.Now,
                    // ?? if trilhoVM.EstadoID == 2 (fechado) ...
                };

                // coloco estadoTrilho na tabela dbo.EstadoTrilhos
                _context.Add(estadoTrilho);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            // se modelo inválido fica na mma view com os dados introduzidos no form
            ViewData["DificuldadeID"] = new SelectList(_context.Dificuldades, "DificuldadeID", "Nome", trilhoVM.DificuldadeID);
            ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "Nome", trilhoVM.EstadoID);
            return View(trilhoVM);
        }

        // GET:Editar
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // devolve registo do trilho cujo id seja o do trilho seleccionado
            Trilho trilho = await _context.Trilhos.SingleOrDefaultAsync(m => m.TrilhoID == id);

            var estadoTrilhos = _context.EstadoTrilhos
                .Include(et => et.Estado)
                .Include(et => et.Trilho);

            ListaEstadoTrilhosBD2 = estadoTrilhos.ToListAsync().Result;

            
            foreach(EstadoTrilho et in ListaEstadoTrilhosBD2)
            {
                if (et.TrilhoID == id && (et.DataInicio == new DateTime(0001, 01, 01) || et.DataFim == new DateTime(0001, 01, 01)))
                {
                    estadoId = et.EstadoID;
                } 
            }


            if (trilho == null)
            {
                return NotFound();
            }

            ViewModelTrilho VMTrilho = new ViewModelTrilho
            {
                TrilhoID = trilho.TrilhoID,
                TrilhoNome = trilho.Nome,
                TrilhoInicio = trilho.Inicio,
                TrilhoFim = trilho.Fim,
                TrilhoDistancia = trilho.Distancia,
                TrilhoFoto = trilho.Foto,
                TrilhoDesativado = trilho.Desativado,
                TrilhoDetalhes = trilho.Detalhes,
                TrilhoSumario = trilho.Sumario,
                DificuldadeID = trilho.DificuldadeID,
                EstadoID = estadoId // se for a criar 1 nova entrada em EstadoTrilho de cada vez que mudo de Estado(POST), preciso de ler
                                    // aqui qual é o Estado(GET) - nota: pensar na repetiçao da chave primaria(composta)
            };

            // passa campos do trilho para a view
            ViewData["DificuldadeID"] = new SelectList(_context.Dificuldades, "DificuldadeID", "Nome", VMTrilho.DificuldadeID);
            ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "Nome", VMTrilho.EstadoID);
            return View(VMTrilho);
        }

        // POST: Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("TrilhoID,TrilhoNome,TrilhoInicio,TrilhoFim,TrilhoDetalhes,TrilhoSumario,TrilhoDistancia,TrilhoFoto, TrilhoDesativado,DificuldadeID,EstadoID")] ViewModelTrilho VMTrilho)
        {

            // crio novo trilho a partir dos valores introduzidos no form (ver Bind)
            Trilho trilho = new Trilho
            {
                TrilhoID = VMTrilho.TrilhoID,
                Nome = VMTrilho.TrilhoNome,
                Inicio = VMTrilho.TrilhoInicio,
                Fim = VMTrilho.TrilhoFim,
                Distancia = VMTrilho.TrilhoDistancia,
                Foto = VMTrilho.TrilhoFoto,
                Desativado = VMTrilho.TrilhoDesativado,
                Detalhes = VMTrilho.TrilhoDetalhes,
                Sumario = VMTrilho.TrilhoSumario,
                DificuldadeID = VMTrilho.DificuldadeID
            };

            if (id != trilho.TrilhoID)
            {
                return NotFound("TrilhoID NotFound");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Update de dbo.trilhos
                    _context.Update(trilho);
                    //_context.Update(estadoTrilho);
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
            // se modelo inválido fica na mma view com os dados introduzidos no form
            ViewData["DificuldadeID"] = new SelectList(_context.Dificuldades, "DificuldadeID", "Nome", VMTrilho.DificuldadeID);
            ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "Nome", VMTrilho.DificuldadeID);
            return View(VMTrilho);
        }

        // GET: Desativar
        public async Task<IActionResult> Desativar(int? id)
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

        // POST: Desativar
        [HttpPost, ActionName("Desativar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DesativacaoConfirmada(int id)
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
