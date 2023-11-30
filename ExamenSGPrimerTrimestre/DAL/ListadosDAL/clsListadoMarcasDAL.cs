using Entidades;

namespace DAL.ListadosDAL
{
    public class clsListadoMarcasDAL
    {

        public static List<clsMarcas> listadoCompletoMarcasDAL()
        {
            List<clsMarcas> lista = new List<clsMarcas>();

            lista.Add(new clsMarcas(1, "Ford"));
            lista.Add(new clsMarcas(2, "Renault"));
            lista.Add(new clsMarcas(3, "Citroen"));

            return lista;
           
        }

    }
}
