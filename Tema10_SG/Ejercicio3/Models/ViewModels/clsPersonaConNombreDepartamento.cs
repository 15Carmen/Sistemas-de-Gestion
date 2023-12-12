using BL;
using Entidades;

namespace Ejercicio3.Models.ViewModels
{
    public class clsPersonaConNombreDepartamento : clsPersona
    {

        #region atributos

        private clsDepartamento departamentoVM;

        #endregion

        #region constructores

        public clsPersonaConNombreDepartamento(clsPersona persona)
        {
            //Indicamos que las propiedades heredadas de esta clase son iguales a las pasadas por parámetro
            this.Id = persona.Id;
            this.Nombre = persona.Nombre;
            this.Apellidos = persona.Apellidos;
            this.Telefono = persona.Telefono;
            this.Direccion = persona.Direccion;
            this.Foto = persona.Foto;
            this.FechaNacimiento = persona.FechaNacimiento;
            this.IdDepartamento = persona.IdDepartamento;

            //Indicamos que el objeto departamento de la clase es uno de la lista de departamentos 
            //Buscamos cual es segun el id de la persona pasada por parámetros
            this.departamentoVM = clsListadoDepartamentosBL.obtenerDepartamentoPorIdBL(persona.IdDepartamento);

        }

        #endregion

        #region propiedades


        public clsDepartamento DepartamentoVM
        {
            get { return departamentoVM; }
            //No le ponemos un set a los departamentos porque estos no se van a poder cambiar
            //set { departamentoVM = value;}
        }

        #endregion

    }
}
