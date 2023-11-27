using Ejercicio1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using DAL;

namespace Ejercicio1.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {

            SqlConnection conn = new SqlConnection();

            ViewBag.ConnectionState = "No se ha intentado conectar";

            try
            {
                conn.ConnectionString = "server=ODENADOR-CARMEN\\SQLEXPRESS;database=Persona;uid=prueba;pwd=Marnu;trustServerCertificate=true";
                conn.Open();
                ViewBag.ConnectionState = $"Conectado: {conn.State}";
            }
            catch (Exception ex)
            {
                ViewBag.ConnectionState = $"Error al conectar: {ex.Message}";
            }

            return View();
        }


        public ActionResult Lista()
        {
            try
            {
                return View(DAL.clsListadoPersonas.getListadoPersonas());
            }catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error";
                return View("Error");
            }
        }

       
    }
}