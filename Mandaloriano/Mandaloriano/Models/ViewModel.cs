using Mandaloriano.Entidades;

namespace Mandaloriano.Models
{
    /// <summary>
    /// Clase que le pasa a la vista los que necesita mostrar, en este caso
    /// una lista de misiones y una mision
    /// </summary>
    public class ViewModel
    {
        #region Propiedades
        public List<clsMision> ListaMisiones { get; set; }
        public clsMision Mision { get; set; }
        
        #endregion

        #region Constructores
        public ViewModel() { }
        public ViewModel(List<clsMision> listaMisiones, clsMision mision)
        {
            this.ListaMisiones = listaMisiones;
            this.Mision = mision;
        }
        #endregion
    }
}

