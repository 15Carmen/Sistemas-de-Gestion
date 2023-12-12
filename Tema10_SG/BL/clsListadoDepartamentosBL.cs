using DAL.Listados;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class clsListadoDepartamentosBL
    {

        public static List<clsDepartamento> getListadoDepartamentosBL()
        {
            return clsListadoDepartamentosDAL.getListadoDepartamentosDAL();
        }

        public static clsDepartamento obtenerDepartamentoPorIdBL(int id)
        {
            return clsListadoDepartamentosDAL.obtenerDepartamentoPorId(id);
        }

    }
}
