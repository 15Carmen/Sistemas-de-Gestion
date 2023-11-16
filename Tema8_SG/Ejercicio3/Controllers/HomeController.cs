using Ejercicio3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio3.Controllers
{
    public class HomeController : Controller
    {
       
       
        public IActionResult Editar()
        {
            clsPersona persona = new clsPersona()
            {
                Nombre = "Carmen",
                Apellido = "Martin",
                Edad = 20
            };
                       
            return View(persona);
        }

        [HttpPost]
        public IActionResult Editar(clsPersona oPersona)
        {
            IActionResult action;
            if (!ModelState.IsValid)
            {

                //Mandamos el objeto a la misma vista (un formulario)

                //para que se muestren los mensajes de error
                action = View(oPersona);
            }
            else
            {
                // Todo Correcto

                //Podemos mandar a una página de éxito

                action = View("PersonaModificada", oPersona);

             }
            return action;
        }

       
    }
}