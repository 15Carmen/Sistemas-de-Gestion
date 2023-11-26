using Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tema9_SG.Models;

namespace Tema9_SG.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            clsPersona persona = new clsPersona()
            {
                Id = 1,
                Nombre = "Nombre",
                Apellidos = "Apellidos",
                FechaNac = new DateTime(),
                Direccion = "Dirección",
                Telefono = 34123456789
            };

            return View(persona);
        }

        [HttpPost]
        public IActionResult Index(clsPersona oPersona)
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
                //Todo Correcto
                //Mandamos al usuario a la vista de la persona modificada

                action = View("PersonaModificada", oPersona);

            }
            return action;

        }


       
    }
}