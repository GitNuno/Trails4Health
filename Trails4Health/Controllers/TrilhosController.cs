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

       
    }
}

