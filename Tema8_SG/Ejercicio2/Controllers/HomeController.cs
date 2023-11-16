using Ejercicio2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio2.Controllers
{
    public class HomeController : Controller
    {
        //Action de la primera vez que el usuario pide la página.
        public IActionResult Index()
        {
            return View();
        }

        //Action cuando el usuario ha pulsado el botón.
        [HttpPost]
        public IActionResult IndexPost(string nombre)
        {
            ViewBag.nombre = nombre;

            
             //Esto devuelve la vista Index, la misma vista deonde recogemos los datos
             return View();
            

            //Esto devuelve la vista de IndexPost
            //return View("IndexPost");
        }
    }
}