using Ejercicios01y02.Models.Entidades;

namespace Ejercicios01y02.Models.DAL
{
    public class clsListaDepartamentos
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<clsDepartamento> listadoCompletoDepartamentos()
        {
            List<clsDepartamento> listaDepartamentos = new List<clsDepartamento>()
            {
                new clsDepartamento( 1, "Financiero" ),
                new clsDepartamento( 2, "Producción" ),
                new clsDepartamento( 3, "Administración" ),
                new clsDepartamento( 4, "Recursos Humanos" ),
                new clsDepartamento( 5, "Marketing" ),
            };
            return listaDepartamentos;
        }
    }
}
