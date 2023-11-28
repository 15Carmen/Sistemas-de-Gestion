using Ejercicio1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using DAL.Listados;
using Entidades;

namespace Ejercicio1.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            SqlConnection connection = new SqlConnection();
            ViewBag.ConnectionState = "No se ha intentado conectar";

            try
            {
                connection.ConnectionString = "server=isakatha.database.windows.net;database=BDIsaKatha;uid=prueba;pwd=fernandoG321;trustServerCertificate=true";
                connection.Open();
                ViewBag.ConnectionState = $"Se ha abierto la conexión: {connection.State}";
            }catch (Exception ex)
            {
                ViewBag.ConnectionState = $"Error al conectar: {ex.Message}";
            }

            return View();
        }

        public ActionResult clsListadoPersonasView()
        {
            try
            {
                return View(clsListadoPersonasDAL.getListadoPersonas());
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un error";
                return View("Error");
            }
        }

       
       

       
    }
}