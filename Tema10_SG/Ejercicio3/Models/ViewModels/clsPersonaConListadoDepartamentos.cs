using BL;
using Entidades;

namespace Ejercicio3.Models.ViewModels
{
    //Como necesitamos tenr una persona con el nombre del departamento en vez del id, hacemos que herede de la clase persona
    public class clsPersonaConListadoDepartamentos : clsPersona
    {

        #region atributos

        private List<clsDepartamento> listaDepartamentosVM;

        #endregion

        #region constructores
        public clsPersonaConListadoDepartamentos()
        { 
            //Aunque sea el constructor vacío instanciamos la lista de todos los departamentos, ya que
            //la necesitaremos para cuando queramos crear una persona
            this.listaDepartamentosVM = clsListadoDepartamentosBL.getListadoDepartamentosBL();
        }

        public clsPersonaConListadoDepartamentos( clsPersona persona)
        {
            //Instanciamos una lista con todos los departamentos de la base de datos
            this.listaDepartamentosVM = clsListadoDepartamentosBL.getListadoDepartamentosBL();

            this.Id = persona.Id;
            this.Nombre = persona.Nombre;
            this.Apellidos = persona.Apellidos;
            this.Telefono = persona.Telefono;
            this.Direccion = persona.Direccion;
            this.Foto = persona.Foto;
            this.FechaNacimiento = persona.FechaNacimiento;
            this.IdDepartamento = persona.IdDepartamento;

        }

        #endregion

        #region propiedades

        public List<clsDepartamento> ListaDepartamentosVM
        {
            get { return listaDepartamentosVM; }
            //NO le ponemos un set a la lista, pues esta no se va a porder cambiar
            //set {  listaDepartamentosVM = value;}
        }
        #endregion

    }
}
