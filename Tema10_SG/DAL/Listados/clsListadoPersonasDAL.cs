using Microsoft.Data.SqlClient;
using Entidades;
using DAL.Conexion;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.Listados
{
    public class clsListadoPersonasDAL
    {
        /// <summary>
        /// Función que se conecta a la base de datos y devuelve la lista completa de las personas 
        /// Pre: La bbdd no debe estar vacía
        /// Post: ninguna
        /// </summary>
        /// <returns>listado completo de personas</returns>
        public static List<clsPersona> getListadoPersonasDAL()
        {

            clsConexion miConexion = new clsConexion();

            List<clsPersona> listadoPersonas = new List<clsPersona>();

            SqlCommand cmd = new SqlCommand();

            SqlDataReader dr;

            clsPersona oPersona;


            try
            {
                SqlConnection connOpen = miConexion.createConnection();

                //Creamos el comando

                cmd.CommandText = "SELECT * FROM Personas";
                cmd.Connection = connOpen;

                dr = cmd.ExecuteReader();

                //Si hay lineas en el lector
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        oPersona = new clsPersona();
                        oPersona.Id = (int)dr["Id"];
                        oPersona.Nombre = (string)dr["Nombre"];
                        oPersona.Apellidos = (string)dr["Apellidos"];
                        oPersona.Telefono = (string)dr["Telefono"];
                        oPersona.Direccion = (string)dr["Direccion"];
                        
                        //Si sospechamos que el campo puede ser Null en la BBDD                                           
                       
                        if (dr["Foto"] != DBNull.Value)
                        {
                            oPersona.Foto = (string)dr["Foto"];
                        }

                        if (dr["FechaNacimiento"] != DBNull.Value)
                        {
                            oPersona.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                        }

                        if (dr["IdDepartamento"] != DBNull.Value)
                        {
                            oPersona.IdDepartamento = (int)dr["IdDepartamento"];
                        }

                        listadoPersonas.Add(oPersona);
                    }

                    dr.Close();
                    connOpen.Close();
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }


            return listadoPersonas;
        }

        /// <summary>
        /// Función que devuelve la persona de la lista que tenga el mismo id que el pasado por parámetro.
        /// Si no encuentra ninguna coincidencia devuelve un objeto persona creado sin parámetros
        /// Pre: los id deben ser unicos
        /// Post: ninguna
        /// </summary>
        /// <param name="listaPersonas"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static clsPersona obtenerPersonaPorId(int id)
        {

            clsConexion miConexion = new clsConexion();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            clsPersona oPersona = new clsPersona();

            //Añadimos un parámetro que luego necesitaremos en el comando sql.
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection connOpen = miConexion.createConnection();

                cmd.CommandText = "Select * from Personas WHERE ID=@id";
                cmd.Connection = connOpen;

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        oPersona = new clsPersona();
                        oPersona.Id = (int)dr["Id"];
                        oPersona.Nombre = (string)dr["Nombre"];
                        oPersona.Apellidos = (string)dr["Apellidos"];
                        oPersona.Telefono = (string)dr["Telefono"];
                        oPersona.Direccion = (string)dr["Direccion"];

                        //Si sospechamos que el campo puede ser Null en la BBDD                                           

                        if (dr["Foto"] != DBNull.Value)
                        {
                            oPersona.Foto = (string)dr["Foto"];
                        }

                        if (dr["FechaNacimiento"] != DBNull.Value)
                        {
                            oPersona.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                        }

                        if (dr["IdDepartamento"] != DBNull.Value)
                        {
                            oPersona.IdDepartamento = (int)dr["IdDepartamento"];
                        }
                    }
                }
                dr.Close();
                //Cerramos la conexión
                connOpen.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return oPersona;


        }




    }
}
