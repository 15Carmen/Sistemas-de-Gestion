using Microsoft.AspNetCore.Mvc;

namespace Tema6_SG.Controllers
{
    public class HomeController : Controller
    {
        public String Index()
        {
            return "Carmen";
        }

        public String Apellidos()
        {
            return "Martín Núñez";
        }

        public ActionResult Saludo()
        {
            return View();
        }
    }
}
