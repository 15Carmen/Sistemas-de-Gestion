using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tema8_SG.Models;

namespace Tema8_SG.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

       public IActionResult Saludo(string nombre)
        {
            ViewBag.nombre = nombre;
            return View();
        }
    }
}