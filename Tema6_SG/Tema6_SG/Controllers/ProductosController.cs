using Microsoft.AspNetCore.Mvc;

namespace Tema6_SG.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult ListadoProductos()
        {
            return View();
        }
    }
}
