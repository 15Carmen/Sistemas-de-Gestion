using Mandaloriano.DAL.GestionRegistrosDAL;
using Mandaloriano.DAL.ListadosDAL;
using Mandaloriano.Entidades;
using Mandaloriano.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mandaloriano.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<clsMision> listadoMisiones = clsListadoMisiones.getListaCompletaMisiones();
            return View(new ViewModel(listadoMisiones, new clsMision()));
        }

        [HttpPost]
        public IActionResult Index(int misionSeleccionada)
        {
            List<clsMision> listadoMisiones = clsListadoMisiones.getListaCompletaMisiones();
            clsMision misionMostrada = clsSelccionarMision.seleccionarMisionPorId(listadoMisiones, misionSeleccionada);
            return View(new ViewModel(listadoMisiones, misionMostrada));
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}