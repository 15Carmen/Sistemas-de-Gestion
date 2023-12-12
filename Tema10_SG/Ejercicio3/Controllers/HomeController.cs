using Ejercicio3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DAL.Listados;
using Entidades;
using DAL.Manejadoras;
using BL;
using Ejercicio3.Models.ViewModels;

namespace Ejercicio3.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
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

        public IActionResult Details(int id)
        {
            try
            {
                clsPersona persona = clsListadoPersonasBL.obtenerPersonaPorIdBL(id);              

                clsPersonaConNombreDepartamento vm = new clsPersonaConNombreDepartamento(persona);

                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        
        public ActionResult Insert()
        {
            try
            {
                clsPersonaConListadoDepartamentos vm = new clsPersonaConListadoDepartamentos();

                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [ActionName("Insert")]
        [HttpPost]
        public ActionResult InsertPost(clsPersona oPersona)
        {
            try
            {
                int numFilasAfectadas = clsHandlerPersonaBL.insertPersonaBL(oPersona);

                if (numFilasAfectadas > 0)
                {
                    ViewBag.Info = "La persona se ha creado correctamente";
                }

                return View("Index", clsListadoPersonasBL.getListadoPersonasBL());

            }catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                clsPersona persona = clsListadoPersonasBL.obtenerPersonaPorIdBL(id);

                clsPersonaConListadoDepartamentos vm = new clsPersonaConListadoDepartamentos(persona);

                return View(vm);
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }

        [ActionName ("Edit")]
        [HttpPost]
        public ActionResult EditPost(clsPersona oPersona)
        {

            try
            {
                int numFilasAfectadas = clsHandlerPersonaBL.updatePersonaBL(oPersona);

                if(numFilasAfectadas > 0)
                {
                    ViewBag.Info = "La persona se ha editado correctamente";
                }

                return View("Index", clsListadoPersonasBL.getListadoPersonasBL());
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        
        }

        public ActionResult Delete(int id)
        {
            try
            {
                clsPersona persona = clsListadoPersonasBL.obtenerPersonaPorIdBL(id);

                clsPersonaConNombreDepartamento vm = new clsPersonaConNombreDepartamento(persona);
                
                return View(vm);
            }
            catch(Exception ex)
            {
                return View("Error");
            }
           
        }

        [ActionName("Delete")]
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
                    ViewBag.Info = "Hoy es martes, por lo que no se puede borrar ninguna persona";

                }
                else
                {
                    ViewBag.Info = "La persona se ha borrado correctamente";
                    
                }

                return View("Index", clsListadoPersonasBL.getListadoPersonasBL());

            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }



       

      

        


      

    }
}