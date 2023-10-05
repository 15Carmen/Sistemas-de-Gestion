using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class clsPersona
    {
        #region atributos
        private String nombre;
        #endregion

        #region constructores

        clsPersona() 
        {
            nombre = "";
        }

        clsPersona(String nombre)
        {
            this.nombre = nombre;
        }
        #endregion

        #region propiedades
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        #endregion

        #region funciones y metodos

        #endregion
    }
}
