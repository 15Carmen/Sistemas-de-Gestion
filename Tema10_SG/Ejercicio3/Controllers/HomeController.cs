using Ejercicio3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DAL.Listados;
using Entidades;
using DAL.Manejadoras;
using BL;

namespace Ejercicio3.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult ListaPersonasView()
        {
            try
            {

                List<clsPersona> listadoCompletoPersonas = clsListadoPersonasBL.getListadoPersonasBL();
                

                return View(listadoCompletoPersonas);

            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        public ActionResult InsertPersonaView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertPost(clsPersona oPersona)
        {
            try
            {
                //cambiar a la capa bl
                clsHandlerPersonaDAL.insertPersonaDAL(oPersona);
                return RedirectToAction("ListaPersonasView");
            }catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult EditPersonaView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditPost(clsPersona oPersona)
        {
            return View();
        }

        public ActionResult DeletePersonaView(int id)
        {
            try
            {
                clsPersona persona = clsListadoPersonasBL.obtenerPersonaPorIdBL(id);
                
                return View(persona);
            }
            catch(Exception ex)
            {
                return View("Error");
            }
           
        }

        [ActionName("DeletePersonaView")]
        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            try
            {
                int numeroFilas = clsHandlerPersonaBL.deletePersonaBL(id);
                
                if (numeroFilas == 0)
                {
                    ViewBag.Info = "No existe esa persona";
                }else if (numeroFilas == -1)
                {
                    ViewBag.Info = "Hoy es miércoles, por lo que no se puede borrar ninguna persona";

                }
                else
                {
                    ViewBag.Info = "La persona se ha borrado correctamente";
                    return RedirectToAction("Listado");
                }

                return View(clsListadoPersonasBL.obtenerPersonaPorIdBL(id));

            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }



       

      

        


      

    }
}