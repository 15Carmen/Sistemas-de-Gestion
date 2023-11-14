using Ejercicios01y02.Models.Entidades;
using Ejercicios01y02.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ejercicios01y02.Models.ViewModel;

namespace Ejercicios01y02.Controllers
{
    public class HomeController : Controller
    {
        clsPersona persona = new clsPersona();
        DateTime fechaYHoraActual = DateTime.Now;
       
        public IActionResult Index()
        {
            ViewBag.HoraActual = fechaYHoraActual.ToLongDateString();

            if (fechaYHoraActual.Hour >= 7 && fechaYHoraActual.Hour < 12)
            {
                ViewData["Saludo"] = "Buenos días";
            }
            else if (fechaYHoraActual.Hour >= 12 && fechaYHoraActual.Hour < 21)
            {
                ViewData["Saludo"] = "Buenas tardes";
            }
            else
            {
                ViewData["Saludo"] = "Buenas noches";
            }

            persona.Nombre = "Carmen";
            persona.Apellidos = "Martín";

            return View(persona);
        }

        public IActionResult listadoPersonas()
        {
            try
            {
                return View(clsListaPersonas.listadoCompletoPersona());

            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public ActionResult EditarPersonaVista()
        {
            clsListaPersonaConDepartamento viewModel = new clsListaPersonaConDepartamento();
            return View(viewModel);
        }

    }
}