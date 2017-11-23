using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Trails4Health.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult About()
        {
            //ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult BackOffice2()
        {
            return View();
        }

        public IActionResult AvaliarTrilho()
        {
            return View();
        }

        public IActionResult AvaliarGuia()
        {
            return View();
        }

        public IActionResult InserirQuestoesAvaliacaoGuia()
        {
            return View();
        }

        public IActionResult InserirQuestoesAvaliacaoTrilho()
        {
            return View();
        }

    }
}
