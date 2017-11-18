using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trails4Health.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        //??? devo criar 2 novos controladores: /AvaliarServico /AvaliarTrilho para as operaçoes CRUD destes modulos
        //    ou faço tudo neste controlador ???
        public ViewResult BackOffice()
        {
            return View();
        }

        // LISTAGEM DE DADOS SEEDDATA -------------------
        private ITrails4HealthRepository repository;

        // Controlador vai ver se existe um serviço para ITrails4HealthRepository
        // dependency injection
        public TrilhosController(ITrails4HealthRepository repository) // construtor
        {
            this.repository = repository;
        }

        // CAMINHO DADOS:
        //   .[serviços]: ITrails4HealthRepository recebeu dados de EFTrails4HealthRepository>() (ver startup.cs)
        //   .[EFTrails4HealthRepository:ITrails4HealthRepository]: recebeu dados da BD usando ApplicationDbContext (:DbContext)
        //   .[ApplicationDbContext:DbContext]: mapeou BD com a classe Trilho (DbSet<Trilho> Trilhos { get; set; })
        //      .Nota: A BD foi populada usando SeedData.cs (ver startup.cs) que usa ApplicationDbContext 
        //   .[view List]: é do tipo IEnumerable<Trilho> e exibe campos de Trilho com: foreach (Trilho p in Model)
        public ViewResult List()
        {
            return View(repository.Trilhos); // passa trilhos para view: @model IEnumerable<Trilho>

        }

    }
}

