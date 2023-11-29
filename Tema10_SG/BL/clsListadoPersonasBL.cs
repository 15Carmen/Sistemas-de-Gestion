using DAL.Listados;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class clsListadoPersonasBL
    {
        /// <summary>
        /// Función que devuelve un listado de persona obtenido de la DAL y aplicando 
        /// las reglas de negocio necesarias.
        /// </summary>
        /// <returns>listado de personas</returns>
        public static List<clsPersona> getListadoPersonasBL()
        {
            return clsListadoPersonasDAL.getListadoPersonasDAL();
        }

        /// <summary>
        /// Función que devuelve una persona obtenida de la DAL y aplicando las reglas 
        /// de negocio necesarias
        /// </summary>
        /// <param name="id"></param>
        /// <returns>una persona</returns>
        public static clsPersona obtenerPersonaPorIdBL(int id)
        {
            return clsListadoPersonasDAL.obtenerPersonaPorId(id);
        }

       
    }
}
