using Ejercicios01y02.Models.DAL;
using Ejercicios01y02.Models.Entidades;

namespace Ejercicios01y02.Models.ViewModel
{
    public class EditarPersonaVM : clsPersona
    {
        #region atributos
        private List<clsDepartamento> listaDepartamentos;
        #endregion

        #region constructor

        public EditarPersonaVM() {
            this.listaDepartamentos = clsListaDepartamentos.listadoCompletoDepartamentos();
        }

        #endregion

        #region propiedades

        public List<clsDepartamento> ListaDepartamentos { 
            get {  return listaDepartamentos; } 
            //No ponemos un set para que nadie me machaque la lista
        }

        #endregion
    }
}
