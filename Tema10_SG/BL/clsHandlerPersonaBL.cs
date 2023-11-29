using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Manejadoras;

namespace BL
{
    public class clsHandlerPersonaBL
    {
        /// <summary>
        /// Función que llama a la DAL y devuelve el número de filas afectadas
        /// al borrar la persona que recibe como parámetro y aplica las normas de negocio
        /// Post: Mi salida será 0 cuando no haya id, -1 cuando ha un error en la BL y 1 cuando 
        ///       se haya conseguido borrar
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Numero filas afectadas</returns>
        public static int deletePersonaBL(int id)
        {
            int numFilasAfectadas = 0;
            DateTime fechaActual = DateTime.Now;

            //Si el dia de la semana es miercoles se devuelve un 0, ya que no se pude borrar ese dia
            if (fechaActual.DayOfWeek == DayOfWeek.Wednesday)
            {
                numFilasAfectadas = -1;
            }
            else
            {
                numFilasAfectadas = clsHandlerPersonaDAL.deletePersonaDAL(id);
            }

            return numFilasAfectadas;
        }
    }
}
