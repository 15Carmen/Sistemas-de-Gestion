using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Conexion;
using Microsoft.Data.SqlClient;

namespace DAL.Manejadoras
{
    public class clsManejadoraPersonasDAL
    {


        /// <summary>
        /// Función que borra una persona de la lista personas
        /// Pre: la lista no debe estar vacía
        /// Post: ninguna
        /// </summary>
        /// <param name="id"></param>
        /// <returns>numero de filas afectadas</returns>
        public int deletePersonaDAL(int id)
        {
            int numeroFilasAfectadas = 0;
            clsConexion miConexion = new clsConexion();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value=id;

            try
            {
                SqlConnection conn = miConexion.createConnection();
                cmd.CommandText = "DELETE FROM Personas WHERE ID=@id";
                cmd.Connection = conn;
                numeroFilasAfectadas = cmd.ExecuteNonQuery();

                conn.Close();

            }catch (Exception ex)
            {
                throw ex;
            }

            return numeroFilasAfectadas;

        }

        /// <summary>
        /// Función que actualiza la persona
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        

    }
}
