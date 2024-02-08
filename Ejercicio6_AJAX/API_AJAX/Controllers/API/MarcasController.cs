using DAL.Listados;
using Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_AJAX.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        // GET: api/<MarcasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsMarcas> listaMarcas = new List<clsMarcas>();

            try
            {
                listaMarcas = clsListadoMarcasDAL.getListadoMarcasDAL();
                if (listaMarcas.Count() == 0)
                {
                    salida = NoContent(); //el listado está vacío.
                }
                else
                {
                    salida = Ok(listaMarcas); //mandamos la lista
                }
            }
            catch (Exception ex)
            {
                salida = BadRequest(ex.Message);
            }

            return salida;
        }

    }
}
