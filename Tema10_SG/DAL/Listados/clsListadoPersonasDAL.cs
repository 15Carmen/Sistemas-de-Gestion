using Microsoft.Data.SqlClient;
using Entidades;
using DAL.Conexion;

namespace DAL.Listados
{
    public class clsListadoPersonasDAL
    {

        public static List<clsPersona> getListadoPersonas()
        {

            clsConexion miConexion = new clsConexion();

            List<clsPersona> listadoPersonas = new List<clsPersona>();

            SqlCommand cmd = new SqlCommand();

            SqlDataReader dr;

            clsPersona oPersona;


            try
            {
                SqlConnection conn = miConexion.createConnection();

                //Creamos el comando

                cmd.CommandText = "SELECT * FROM Personas";
                cmd.Connection = conn;

                dr = cmd.ExecuteReader();

                //Si hay lineas en el lector
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        oPersona = new clsPersona();
                        oPersona.Id = (int)dr["Id"];
                        oPersona.Nombre = (string)dr["Nombre"];
                        oPersona.Apellido = (string)dr["Apellidos"];
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
                    conn.Close();
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }


            return listadoPersonas;
        }


    }
}
