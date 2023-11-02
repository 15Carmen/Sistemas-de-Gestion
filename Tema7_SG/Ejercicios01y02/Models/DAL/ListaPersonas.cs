using Ejercicios01y02.Models.Entidades;

namespace Ejercicios01y02.Models.DAL
{
    public class ListaPersonas
    {

        /// <summary>
        /// Función que devuelve un listado de personas completo
        /// Pre: Ninguna
        /// Post: Ninguna 
        /// </summary>
        /// <returns>listado personasreturns>
        public static List<clsPersona> listadoCompletoPersona()
        {
            List<clsPersona> listadoPersonas = new List<clsPersona>()
            {
                new clsPersona("Carmen", "Martin"),
                new clsPersona("Luisa", "Alejandra"),
                new clsPersona("Isabel", "Katharina"),
                new clsPersona("Paco", "López"),
                new clsPersona("Lydia", "Pérez")
            };

         
            return listadoPersonas; 

        }
    }
}
