using Ejercicios01y02.Models.Entidades;

namespace Ejercicios01y02.Models.DAL
{
    public class clsListaPersonas
    {

        /// <summary>
        /// Función que devuelve un listado de personas completo
        /// Pre: Ninguna
        /// Post: Ninguna 
        /// </summary>
        /// <returns>listado personas<returns>
        public static List<clsPersona> listadoCompletoPersona()
        {
            List<clsPersona> listadoPersonas = new List<clsPersona>()
            {
                new clsPersona(1, "Carmen", "Martín", 2),
                new clsPersona(2, "Luisa", "Alejandra", 4),
                new clsPersona(3, "Isabel", "Katharina", 5),
                new clsPersona(4, "Paco", "López", 1),
                new clsPersona(5, "Lydia", "Pérez", 3)
            };

         
            return listadoPersonas; 

        }
    }
}
