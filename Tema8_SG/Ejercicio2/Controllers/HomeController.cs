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


        /*
         * Si en la clase Index ponemos  (Html.BeginForm ("Index", "Home", FormMethod.Post))
         * usamos este IActionResult que devuelve la vista de IndexPost al pasarla por parámetros
         */

        //Action cuando el usuario ha pulsado el botón.
        [HttpPost]
        public IActionResult Index(string nombre)
        {
            ViewBag.nombre = nombre;

            // Esto devuelve la vista Index, la misma vista donde recogemos los datos
            // return View();

            return View("IndexPost");
        }


        /*
         * Si en la clase index ponemos  (Html.BeginForm ("IndexPost", "Home", FormMethod.Post))
         * usamos este IActionResult que devuelve directamente la vista de IndexPost 
         */

        //public IActionResult IndexPost(string nombre)
        //{
        //    ViewBag.nombre = nombre;
        //    
        //    return View();
        //}
    }
}