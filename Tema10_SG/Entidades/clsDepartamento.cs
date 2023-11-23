using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class clsDepartamento
    {
        #region atributos

        public int idDepartamento;
        public string nombre;
        #endregion

        #region constructores

        public clsDepartamento() { 
        
            idDepartamento = 0;
            nombre = string.Empty;
        }

        public clsDepartamento(int idDepartamento, string nombre)
        {
            this.idDepartamento = idDepartamento;
            this.nombre = nombre;
        }

        #endregion



    }
}
