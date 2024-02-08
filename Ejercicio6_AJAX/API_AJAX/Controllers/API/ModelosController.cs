using DAL.Handlers;
using DAL.Listados;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_AJAX.Controllers.API
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        // GET: api/<MarcasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;


            try
            {
                List <clsModelos> listaModelos = clsListadoModelosDAL.getListadoModelosDAL();
                if (listaModelos.Count() == 0)
                {
                    salida = NoContent(); //el listado está vacío.
                }
                else
                {
                    salida = Ok(listaModelos); //mandamos la lista
                }
            }
            catch (Exception ex)
            {
                salida = BadRequest(ex.Message);
            }

            return salida;

        }

        // PUT: ModelosController/Edit/5
        [HttpPut]
        public IActionResult Put(int idModelo, int precio)
        {
            IActionResult salida;

            try
            {
                int numFilasAfectadas = HandlerModelosDAL.updatePrecioModeloDAL(idModelo, precio);

                if (numFilasAfectadas == 0)
                {
                    salida = NotFound(); //no se ha hecho

                }
                else
                {
                    salida = Ok(); //se ha borrado 
                }

            }
            catch (Exception e)
            {
                salida = BadRequest(e);
            }

            return salida;
        }

    }
}
