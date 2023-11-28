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

        public IActionResult DeleteView(int id)
        {
            try{
                List<clsPersona> listaPersonas = clsListadoPersonasDAL.getListadoPersonas();
                clsPersona oPersona = clsListadoPersonasDAL.obtenerPersonaPorId(listaPersonas,id);
                return View(oPersona);
            }catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error";
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult DeleteView()
        {
            return RedirectToAction("borrar");

        }

        public ActionResult borrar(clsPersona persona)
        {
            try
            {

                int cantRows = DAL.Manejadoras.clsManejadoraPersonasDAL.deletePersonaDAL(persona.Id);

                ViewBag.cantRows = cantRows;

                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error";
                return View("Error");
            }
        }

    }
}