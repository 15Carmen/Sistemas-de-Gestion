using Entidades;

namespace Ejercicio3.Models.ViewModels
{
    public class clsDeleteVM
    {
        #region atributos

        public List<clsPersona> ListaPersonasVM { get; set; }
        public clsPersona PersonaVM { get; set; }

        #endregion

        #region constructores

        public clsDeleteVM() { }

        public clsDeleteVM(List<clsPersona> listaPersonasVM, clsPersona personaVM)
        {
            this.ListaPersonasVM = listaPersonasVM;
            this.PersonaVM = personaVM;
        }

        #endregion
    }
}
