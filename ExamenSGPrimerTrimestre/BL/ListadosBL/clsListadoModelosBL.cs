using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;
using DAL.ListadosDAL;

namespace BL.ListadosBL
{
    public class clsListadoModelosBL
    {
        /// <summary>
        /// Función que se conecta a la base de datos (el listado completo de modelos)
        /// y devuelve la lista completa de los modelos 
        /// Pre: La bbdd no debe estar vacía
        /// Post: ninguna
        /// </summary>
        /// <returns>listado completo de modelos</returns>
        public static List <clsModelos> listadoCompletoModelosBL()
        {
            return clsListadoModelosDAL.listadoCompletoModelosDAL();
        }

        /// <summary>
        /// Función que se conecta a la base de datos (el listado completo de modelos)
        /// y devuelve una lista de modelos según el id de la marca introducida por parámetro
        /// Pre: La bbdd no debe estar vacía
        /// Post: ninguna
        /// </summary>
        /// <returns>listado de modelos segun su marca</returns>
        public static List <clsModelos> listadoModelosPorMarcaBL(int idMarca)
        {
            return clsListadoModelosDAL.listadoModelosPorMarcaDAL(idMarca);
        }

        /// <summary>
        /// Función que se conecta a la base de datos (el listado completo de modelos)
        /// y devuelve un modelo en concreto según el id del modelo introducido por parámetro
        /// Pre: La bbdd no debe estar vacía
        /// Post: ninguna
        /// </summary>
        /// <param name="idModelo"></param>
        /// <returns>modelo de coche</returns>
        public static clsModelos seleccionarModeloPorIdBL(int idModelo)
        {
            return clsListadoModelosDAL.seleccionarModeloPorIdDAL(idModelo);
        }
    }
}
