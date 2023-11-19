using Mandaloriano.Entidades;

namespace Mandaloriano.DAL.GestionRegistrosDAL
{
    public class clsSelccionarMision
    {
        /// <summary>
        /// Función que devuelve la misión de la lista que tenga el mismo id que el pasado por parámetro.
        /// Si no encuentra ninguna coincidencia devuelve un objeto misión creado sin parámetros
        /// Pre: los id deben ser unicos
        /// Post: ninguna
        /// </summary>
        /// <param name="misiones"></param>
        /// <param name="idMision"></param>
        /// <returns></returns>
        public static clsMision seleccionarMisionPorId(List<clsMision> misiones, int idMision)
        {

           foreach(clsMision m in misiones)
            {
                if(m.Id == idMision)
                {
                    return m;
                }
            }
           return new clsMision();

        }

    }
}
