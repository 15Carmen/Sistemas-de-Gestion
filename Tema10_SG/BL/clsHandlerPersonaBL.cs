using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Manejadoras;
using Entidades;

namespace BL
{
    public class clsHandlerPersonaBL
    {
        /// <summary>
        /// Función que llama a la DAL y devuelve el número de filas afectadas
        /// al borrar la persona que recibe como parámetro y aplica las normas de negocio necesarias
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
            if (fechaActual.DayOfWeek == DayOfWeek.Tuesday)
            {
                numFilasAfectadas = -1;
            }
            else
            {
                numFilasAfectadas = clsHandlerPersonaDAL.deletePersonaDAL(id);
            }

            return numFilasAfectadas;
        }


        /// <summary>
        /// Función que llama a la DAL y devuelve el número de filas afectadas
        /// al actualizar la persona que recibe como parámetro y aplica las normas de negocio necesarias
        /// Pre: ninguna
        /// Post: ninguna
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>numero de filas afectadas</returns>
        public static int updatePersonaBL(clsPersona persona)
        {
            int numFilasAfectadas = 0;

            numFilasAfectadas = clsHandlerPersonaDAL.updatePersonaDAL(persona);

            return numFilasAfectadas;
        }

        /// <summary>
        ///  Función que llama a la DAL y devuelve el número de filas afectadas
        /// al insertae la persona que recibe como parámetro y aplica las normas de negocio necesarias
        /// Pre: ninguna
        /// Post: ninguna
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>numero de filas afectadas</returns>
        public static int insertPersonaBL(clsPersona persona)
        {

            int numFilasAfectadas = 0;

            numFilasAfectadas = clsHandlerPersonaDAL.insertPersonaDAL(persona);

            return numFilasAfectadas;

        }
    }
}
