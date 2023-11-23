using Microsoft.Data.SqlClient;
using Entidades;


namespace DAL
{
    public class clsListadoPersonas
    {
      
        public static List<clsPersona> getListadoPersonas()
        {

            SqlConnection conn = new SqlConnection();

            List<clsPersona>listadoPersonas = new List<clsPersona>();

            SqlCommand cmd = new SqlCommand();

            SqlDataReader dr;

            clsPersona oPersona;

            conn.ConnectionString = "server=107-25\\SQLEXPRESS;database=Persona;uid=prueba;pwd=123;trustServerCertificate=true";

            try
            {
                conn.Open();


                cmd.CommandText = "SELECT * FROM Personas";
                cmd.Connection = conn;
                dr = cmd.ExecuteReader();
                
                if(dr.HasRows) { 
                    while(dr.Read())
                    {
                        oPersona = new clsPersona();
                        oPersona.Id = (int)dr["IdPersona"];
                        oPersona.Nombre = (string)dr["Nombre"];
                        oPersona.Apellido = (string)dr["Apellidos"];

                        if (dr["FechaNacimiento"] != System.DBNull.Value)
                        {
                            oPersona.FechaNacimiento = (DateTime)dr["FechaNacimiento"];
                        }

                        oPersona.Direccion = (string)dr["Direccion"];
                        oPersona.Telefono = (string)dr["Telefono"];

                        listadoPersonas.Add(oPersona);
                    }

                    dr.Close();
                    conn.Close();
                }

            }catch (SqlException ex)
            {
                throw ex;
            }


            return new List<clsPersona>();
        }


    }
}
