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
                "Recompensa: 5000 créditos."
                ));

            lista.Add(new clsMision(
                2,
                "Recuperar armadura Beskar",
                "La armadura de Bershka ha sido robada. Debes encontrarla.",
                "Recompensa: 2000 créditos"
                ));
            lista.Add(new clsMision(
                3,
                "Planeta Sorgon",
                "Debes llevar a un niño de vuelta a su planeta natal “Sorgon”.",
                "Recompensa: 500 créditos."
                ));
            lista.Add(new clsMision(
                4,
                "Renacuajos",
                "Debes llevar a una Dama Rana y sus huevos de Tatooine a la luna del estuario Trask, donde su esposo fertilizará los huevos.",
                "Recompensa: 500 créditos."
                ));

            return lista;
        }
    }

}

