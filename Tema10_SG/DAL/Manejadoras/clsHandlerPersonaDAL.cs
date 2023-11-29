using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Conexion;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL.Manejadoras
{
    public class clsHandlerPersonaDAL
    {


        /// <summary>
        /// Función que borra una persona de la lista personas
        /// Pre: la lista no debe estar vacía
        /// Post: ninguna
        /// </summary>
        /// <param name="id"></param>
        /// <returns>numero de filas afectadas</returns>
        public static int deletePersonaDAL(int id)
        {
            int numeroFilasAfectadas = 0;
            clsConexion miConexion = new clsConexion();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value=id;

            try
            {
                SqlConnection connOpen = miConexion.createConnection();
                cmd.CommandText = "DELETE FROM Personas WHERE ID=@id";
                cmd.Connection = connOpen;
                numeroFilasAfectadas = cmd.ExecuteNonQuery();

                connOpen.Close();

            }catch (SqlException ex)
            {
                throw ex;
            }

            return numeroFilasAfectadas;

        }

        /// <summary>
        /// Función que actualiza cualquiera de los campos de la persona seleccionada
        /// Pre: la persona debe existir
        /// Post: ninguna
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="telefono"></param>
        /// <param name="direccion"></param>
        /// <param name="foto"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="idDepartamento"></param>
        /// <returns>numero de filas afectadas</returns>
        public static int updatePersona(int id, string nombre, string apellido, string telefono, string direccion, string foto, DateOnly fechaNacimiento, int idDepartamento)
        {
            int numeroFilasAfectadas = 0;

            clsConexion conexion = new clsConexion();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 30).Value = nombre;    
            cmd.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar, 60).Value=apellido;
            cmd.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar, 15).Value = telefono;
            cmd.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar, 60).Value = direccion;
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.VarChar, 255).Value = foto;
            cmd.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = fechaNacimiento;
            cmd.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = idDepartamento;

            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection conexionAbierta = conexion.createConnection();

                cmd.CommandText = "UPDATE Personas SET IDDepartamento=@idDepartamento WHERE ID=@id";
                cmd.Connection = conexionAbierta;
                numeroFilasAfectadas = cmd.ExecuteNonQuery();

                //Cerramos la conexión
                conexionAbierta.Close();
            }catch(SqlException ex)
            {
                throw ex;
            }

            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Método que inserta una persona nueva en la tabla Personas.
        /// Pre: ninguna
        /// Post: ninguna
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="telefono"></param>
        /// <param name="direccion"></param>
        /// <param name="foto"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="idDepartamento"></param>
        /// <returns>numero de filas afectadas</returns>
        public static int insertPersonaDAL(clsPersona oPersona)
        {

            int numeroFilasAfectadas = 0;

            clsConexion conexion = new clsConexion();
            SqlCommand cmd = new SqlCommand();

            //Añadimos un parámetro que luego necesitaremos en el comando sql.
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 30).Value = oPersona.Nombre;
            cmd.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar, 60).Value = oPersona.Apellido;
            cmd.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar, 15).Value = oPersona.Telefono;
            cmd.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar, 60).Value = oPersona.Direccion;
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.VarChar, 255).Value = oPersona.Foto;
            cmd.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = oPersona.FechaNacimiento;
            cmd.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = oPersona.IdDepartamento;
            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection connOpen = conexion.createConnection();

                cmd.CommandText = "INSERT INTO Personas(Nombre, Apellido, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento)" +
                    "values (@nombre, @apellidos, @telefono, @direccion, @foto, @fechaNacimiento, @idDepartamento)";
                cmd.Connection = connOpen;
                numeroFilasAfectadas = cmd.ExecuteNonQuery();

                //Cerramos la conexión
                connOpen.Close();

            }
            catch (SqlException ex)
            {
                throw ex;
            }


            return numeroFilasAfectadas;

        }




    }
}
