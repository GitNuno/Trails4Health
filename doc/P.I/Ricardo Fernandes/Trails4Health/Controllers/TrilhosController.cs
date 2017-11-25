using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trails4Health.Models;
using Microsoft.AspNetCore.Builder;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult DetalhesTrilho()
        {
            return View();
        }

        public ViewResult BackOffice()
        {
            return View();
        }

        // LISTAGEM DE DADOS SEEDDATA -------------------
        private ITrails4HealthRepository repository;

        // +++++++++++ CRIAR TRILHO NA BD A PARTIR DO FORMULARIO?? ++++++++++++
        //static IApplicationBuilder app;
        //static IServiceProvider serviceProvider = app.ApplicationServices;
        //ApplicationDbContext dbContext = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));

        // Controlador vai ver se existe um serviço para ITrails4HealthRepository
        // dependency injection
        public TrilhosController(ITrails4HealthRepository repository) // construtor
        {
            this.repository = repository;
        }
      
        // Listar Trilhos
        public ViewResult List()
        {
            return View(repository.Trilhos); // passa trilhos para view: @model IEnumerable<Trilho>

        }
        // INSERIR TRILHOS
        [HttpGet]
        public ViewResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Criar(Trilho trilho)
        {
            // validação
            if (ModelState.IsValid)
            {
                // +++++++++++ CRIAR TRILHO NA BD A PARTIR DO FORMULARIO?? ++++++++++++
                //dbContext.Trilhos.AddRange(trilho);
                //dbContext.SaveChanges();
                return View("List",repository.Trilhos);
            }
            else
            {
                // There are Validation Errors > devolve a view em que estava 
                return View();
            }

        }


    }
}

