using Mandaloriano.Entidades;

namespace Mandaloriano.DAL.ListadosDAL
{
    public class clsListadoMisiones
    {

        /// <summary>
        /// Método que devuelve la lista completa de las misiones
        /// </summary>
        /// <returns></returns>
        public static List<clsMision> getListaCompletaMisiones()
        {
            List<clsMision> lista = new List<clsMision>();
            lista.Add(new clsMision(
                1,
                "Rescate de Baby Yoda",
                "Debes hacerte con Grogu y llevárselo a Luke SkyWalker para su entrenamiento.",
                5000
                ));

            lista.Add(new clsMision(
                2,
                "Recuperar armadura Beskar",
                "La armadura de Bershka ha sido robada. Debes encontrarla.",
                2000
                ));
            lista.Add(new clsMision(
                3,
                "Planeta Sorgon",
                "Debes llevar a un niño de vuelta a su planeta natal “Sorgon”.",
                500
                ));
            lista.Add(new clsMision(
                4,
                "Renacuajos",
                "Debes llevar a una Dama Rana y sus huevos de Tatooine a la luna del estuario Trask, donde su esposo fertilizará los huevos.",
                500
                ));

            return lista;
        }

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

            foreach (clsMision m in misiones)
            {
                if (m.Id == idMision)
                {
                    return m;
                }
            }
            return new clsMision();

        }

    }

}

