using ExamenSGPrimerTrimestre.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Entidades;
using BL;
using ExamenSGPrimerTrimestre.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace ExamenSGPrimerTrimestre.Controllers
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
            List<clsMarcas> listadoMarcas = BL.ListadosBL.clsListadoMarcasBL.listadoCompletoMarcasBL();
            return View(listadoMarcas);
        }

        [HttpPost]
        public IActionResult IndexPost(int idMarca)
        {
            List<clsMarcas> listadoMarcas = BL.ListadosBL.clsListadoMarcasBL.listadoCompletoMarcasBL();
            List<clsModelos> listadoModelosPorMarca = BL.ListadosBL.clsListadoModelosBL.listadoModelosPorMarcaBL(idMarca);

            IndexVM vm = new IndexVM(listadoMarcas, listadoModelosPorMarca); 

            return View(vm);
        }

        public IActionResult DetallesModelo(int idModelo)
        {
            clsModelos modeloPorId = BL.ListadosBL.clsListadoModelosBL.seleccionarModeloPorIdBL(idModelo);
            DetallesModeloVM vm = new DetallesModeloVM(modeloPorId);
            
            return View(vm);
        }

        [HttpPost]
        public IActionResult DetallesModeloPost(clsModelos oModelo)
        {
            clsModelos modeloEditado = oModelo;
            DetallesModeloVM vm = new DetallesModeloVM(modeloEditado);

            return View(vm);
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