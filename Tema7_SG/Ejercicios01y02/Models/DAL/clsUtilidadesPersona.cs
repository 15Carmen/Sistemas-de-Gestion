using Ejercicios01y02.Models.Entidades;

namespace Ejercicios01y02.Models.DAL
{
    public class clsUtilidadesPersona
    {
        /// <summary>
        /// Accedemos a la base de datos y devolvemos un objeto clsPersona cuyo id coincida con el id del parametro.
        /// Precondiciones: la base de datos y el servidor deber estar accesible, y el id tiene que existir en ella
        /// </summary>
        /// <param name="id"></param>
        /// <returns>clsPersona</returns>
        public static clsPersona obtenerPersonaId(int id)
        {
            List<clsPersona> listaPersonas = clsListaPersonas.listadoCompletoPersona();

            return listaPersonas.Find(modelodepersona => modelodepersona.Id == id);
        }

        /// <summary>
        /// Actualiza o guarda una persona en la base de datos y devuelve el numero de filas afectadas.
        /// Precondicion: la base de datos debe estar accesible
        /// Postcondicion: numeroFilasAfectadas es mayor o igual a 0
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>int</returns>
        public int guardarPersona(clsPersona persona)
        {
            int numeroFilasAfectadas = 0;
            //... codigo del update o insert
            return numeroFilasAfectadas;
        }
    }
}
