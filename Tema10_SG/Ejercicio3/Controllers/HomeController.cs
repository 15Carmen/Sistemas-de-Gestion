using Ejercicio3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DAL.Listados;
using Entidades;
using Ejercicio3.Models.ViewModels;

namespace Ejercicio3.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult ListaPersonasView()
        {
            try
            {

                List<clsPersona> listadoCompletoPersonas = clsListadoPersonasDAL.getListadoPersonas();
                clsPersona persona = new clsPersona();

                clsListadoPersonasVM listadoVM = new clsListadoPersonasVM(listadoCompletoPersonas, persona);

                return View(listadoVM);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}