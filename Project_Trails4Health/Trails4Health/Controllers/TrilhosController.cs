using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trails4Health.Models;
using Microsoft.AspNetCore.Builder;
using Trails4Health.Models.ViewModels;


// CAMINHO DADOS:
//   .[serviços]: ITrails4HealthRepository recebeu dados de EFTrails4HealthRepository>() (ver startup.cs)
//   .[EFTrails4HealthRepository:ITrails4HealthRepository]: recebeu dados da BD usando ApplicationDbContext (:DbContext)
//   .[ApplicationDbContext:DbContext]: mapeou BD com a classe Trilho (DbSet<Trilho> Trilhos { get; set; })
//      .Nota: A BD foi populada usando SeedData.cs (ver startup.cs) que usa ApplicationDbContext 
//   .[view List]: é do tipo IEnumerable<Trilho> e exibe campos de Trilho com: foreach (Trilho p in Model)

namespace Trails4Health.Controllers
{
    public class TrilhosController : Controller
    {

        private ITrails4HealthRepository repository;

        // Controlador vai ver se existe um serviço para ITrails4HealthRepository
        // dependency injection
        public TrilhosController(ITrails4HealthRepository repository) // construtor
        {
            this.repository = repository;
        }

        // paginação
        public int TamanhoPagina = 4;
        public ViewResult Index(int pagina = 1)
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
                }); // BEFORE VIEW_MODEL:  return View(repository.Trilhos)
        }           // passa trilhos para view: @model IEnumerable<Trilho>



        // devolve o trilho selecionado (de acordo com o id: botão saber_mais - ver taghelper Detalhes.cshtml)
        public ViewResult Detalhes(int? id)
        {
            if (id == null)
            {
                return View("../Shared/Error");
            }

            var trilho = repository.Trilhos.SingleOrDefault(t => t.TrilhoID == id);

            if (trilho == null)
            {
                return View("../Shared/Error");
            }

            return View(trilho);
        }
    }
}

