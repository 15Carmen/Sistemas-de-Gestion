using Ejercicios01y02.Models.DAL;
using Ejercicios01y02.Models.Entidades;

namespace Ejercicios01y02.Models.ViewModel
{
    public class clsListaPersonaConDepartamento : clsPersona
    {
        #region atributos
        private List<clsDepartamento> listaDepartamentos;
        private clsPersona persona;
        #endregion


        #region constructor
        public clsListaPersonaConDepartamento()
        {
            listaDepartamentos = clsListaDepartamentos.listadoCompletoDepartamentos();
            persona = clsUtilidadesPersona.obtenerPersonaId(2);

        }
        #endregion

        #region Propiedades
        public List<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
        }
        #endregion

    }
}
