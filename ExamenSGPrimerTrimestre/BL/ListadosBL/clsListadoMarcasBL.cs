using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ListadosDAL;
using Entidades;


namespace BL.ListadosBL
{
    public class clsListadoMarcasBL
    {
        /// <summary>
        /// Función que se conecta a la base de datos (el listado completo de marcas)
        /// y devuelve la lista completa de las marcas 
        /// Pre: La bbdd no debe estar vacía
        /// Post: ninguna
        /// </summary>
        /// <returns>listado completo de marcas</returns>
        public static List<clsMarcas> listadoCompletoMarcasBL()
        {
            return clsListadoMarcasDAL.listadoCompletoMarcasDAL();
        }
    }
}
