using Microsoft.AspNetCore.Mvc;

namespace Ejercicio2.Controllers
{
    public class ProductosController : Controller
    {

        public String Index()
        {
            return "Listado de productos";
        }
        public ActionResult ListadoProductos()
        {
            return View();
        }
    }
}
