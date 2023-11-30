using Entidades;
using DAL;

namespace ExamenSGPrimerTrimestre.Models.ViewModels
{
    public class DetallesModeloVM
    {
        #region atributos
        clsModelos ModeloEditado { get; set; }

        #endregion

        #region constructores

        public DetallesModeloVM() { }

        public DetallesModeloVM(clsModelos ModeloEditado)
        {
            this.ModeloEditado = ModeloEditado;
        }

        #endregion

    }
}
