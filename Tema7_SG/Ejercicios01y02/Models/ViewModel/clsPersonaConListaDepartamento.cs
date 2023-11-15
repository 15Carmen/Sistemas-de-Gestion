using Ejercicios01y02.Models.DAL;
using Ejercicios01y02.Models.Entidades;

namespace Ejercicios01y02.Models.ViewModel
{
    public class clsPersonaConListaDepartamento : clsPersona
    {
        #region atributos
        private List<clsDepartamento> listaDepartamentosVM;
        
        #endregion


        #region constructor
        public clsPersonaConListaDepartamento(){        
            listaDepartamentosVM = clsListaDepartamentos.listadoCompletoDepartamentos();
            this.Nombre = "Carmen";
            this.Apellidos = "Martín";
            this.IdDepartamento = 2;
            this.Id = 1;
        }
        #endregion

        #region Propiedades
        public List<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentosVM; }
        }
        #endregion

    }
}
