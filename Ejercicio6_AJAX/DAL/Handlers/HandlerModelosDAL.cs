using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Handlers
{
    public class HandlerModelosDAL
    {
        public static int updatePrecioModeloDAL(clsModelos modelo)
        {
            int numeroFilasAfectadas = 0;
            clsConnection conn = new clsConnection();
            SqlCommand cmd = new SqlCommand();

            //Añadimos los parámetros que nos hacen falta. 
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = modelo.IdModelo;
            cmd.Parameters.Add("@precio", System.Data.SqlDbType.Int).Value = modelo.Precio;

            try
            {
                //abrimos la conexión y la guardamos en una variable.
                SqlConnection connAbierta = conn.getConnection();

                cmd.CommandText = "UPDATE Modelos set precio=@precio where idModelo=@idModelo";

                cmd.Connection = connAbierta;

                numeroFilasAfectadas = cmd.ExecuteNonQuery();

                //cerramos la conexión
                connAbierta.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return numeroFilasAfectadas;

        }

    }
}
