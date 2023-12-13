using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL.ListadosDAL
{
    public class clsListadoModelosDAL
    {

        /// <summary>
        /// Función que devuelve el listado completo de los distintos modelos de coches
        /// Pre: ninguna
        /// Post: ninguna
        /// </summary>
        /// <returns></returns>
        public static List<clsModelos> listadoCompletoModelosDAL()
        {
            //Creamos la lista completa de modelos
            List<clsModelos> listaModelos = new List<clsModelos>();

            listaModelos.Add(new clsModelos(1, 1, "Focus", 25000));
            listaModelos.Add(new clsModelos(2, 1, "Kuga", 35000));
            listaModelos.Add(new clsModelos(3, 1, "Puma", 37000));
            listaModelos.Add(new clsModelos(4, 2, "Akana", 28000));
            listaModelos.Add(new clsModelos(5, 2, "Megane", 20000));
            listaModelos.Add(new clsModelos(6, 3, "C3", 14000));
            listaModelos.Add(new clsModelos(7, 3, "C4", 20000));
            listaModelos.Add(new clsModelos(8, 3, "C5", 27000));

            return listaModelos;

        }

        /// <summary>
        /// Función que devuelve un listado de modelos según el id de la
        /// marca que le pasemos por parámetros
        /// Pre: el id no debe ser nulo
        /// Post: ninguna
        /// </summary>
        /// <param name="idMArca"></param>
        /// <returns></returns>
        public static List<clsModelos> listadoModelosPorMarcaDAL(int idMarca)
        {
            //nos creamos la lista donde guardaremos los modelos
            List<clsModelos> listadoModelosPorMarca = new List<clsModelos>();

            //Recorremos la lista completa de modelos
            foreach(clsModelos modelos in listadoCompletoModelosDAL())
            {
                //Si el id introducido es igual que el id de la marca
                if(modelos.IdMarca == idMarca)
                {
                    //Añadimos el modelo a la lista
                    listadoModelosPorMarca.Add(modelos);

                }
            }

            return listadoModelosPorMarca;
        }

        /// <summary>
        /// Función que devuelve un modelo concreto según el id que se
        /// le pase por parámetro
        /// Pre: el id no debe ser nulo
        /// Post: ninguna
        /// </summary>
        /// <param name="idModelo"></param>
        /// <returns></returns>
        public static clsModelos seleccionarModeloPorIdDAL(int idModelo)
        {
            bool encontrado = false;
            int contadorBusqueda = 0;
            clsModelos modelo = null;

            //Mientras no se haya encontrado el modelo y no se haya recorrido la lista completa
            //recorremos la lista
            while (!encontrado && listadoCompletoModelosDAL().Count < contadorBusqueda)
            {
                //Si el id del modelo es igual al introducido por parámetro
                if (listadoCompletoModelosDAL()[contadorBusqueda].IdModelo == idModelo)
                {
                    //Devolvemos el modelo coincidente
                    modelo = listadoCompletoModelosDAL()[contadorBusqueda];
                    contadorBusqueda++;
                    encontrado = true;
                }
            }

            return modelo;

        }

    }
}
