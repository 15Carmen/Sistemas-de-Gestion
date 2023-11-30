using DAL;
using Entidades;

namespace ExamenSGPrimerTrimestre.Models.ViewModels
{
    public class IndexVM
    {
        #region atributos
        List<clsMarcas> ListaMarcas { get; set; }
        List<clsModelos> ListaModelosPorMarca { get; set; }
        #endregion

        #region constructores
        public IndexVM() { }

        public IndexVM(List<clsMarcas> listaMarcas, List<clsModelos> listaModelosPorMarca)
        {
            this.ListaMarcas = listaMarcas;
            this.ListaModelosPorMarca = listaModelosPorMarca;
        }

        #endregion
    }
}
