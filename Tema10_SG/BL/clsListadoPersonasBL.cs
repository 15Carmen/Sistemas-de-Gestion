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
        /// <returns></returns>
        public static List<clsPersona> getListadoPersonasBL()
        {
            return clsListadoPersonasDAL.getListadoPersonasDAL();
        }

       
    }
}
