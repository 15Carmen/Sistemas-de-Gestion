using DAL.Conexion;
using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Listados
{
    public class clsListadoDepartamentosDAL
    {


        /// <summary>
        /// Función que se conecta a la base de datos y devuelve la lista completa de los Deparatamentos 
        /// Pre: La bbdd no debe estar vacía
        /// Post: ninguna
        /// </summary>
        /// <returns>listado completo de departamentos</returns>
        public static List<clsDepartamento> getListadoDepartamentosDAL()
        {
            clsConexion miConexion = new clsConexion();

            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();

            SqlCommand cmd = new SqlCommand();

            SqlDataReader dr;

            clsDepartamento oDepartamento;

            try
            {
                SqlConnection connOpen = miConexion.createConnection();

                //Creamos el comando

                cmd.CommandText = "SELECT * FROM departamentos";
                cmd.Connection = connOpen;

                dr = cmd.ExecuteReader();

                //Si hay lineas en el lector
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        oDepartamento = new clsDepartamento();

                        if (dr["Id"] != DBNull.Value)
                        {
                            oDepartamento.IdDepartamento = (int)dr["Id"];
                        }

                        if (dr["Nombre"] != DBNull.Value)
                        {
                            oDepartamento.Nombre = (string)dr["Nombre"];
                        }
                    

                        listadoDepartamentos.Add(oDepartamento);
                    }

                    dr.Close();
                    connOpen.Close();
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }


            return listadoDepartamentos;
        }



        /// <summary>
        /// Método que lee los detalles de una persona.
        /// 
        /// Pre: recibe un id de la persona y un idDepartamento.
        /// Post: 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static clsDepartamento obtenerDepartamentoPorId(int id)
        {

            clsConexion miConnexion = new clsConexion();

            SqlCommand cmd = new SqlCommand();

            SqlDataReader dr;

            clsDepartamento oDepartamento = new clsDepartamento();

            //Añadimos un parámetro que luego necesitaremos en el comando sql.
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection connOpen = miConnexion.createConnection();

                cmd.CommandText = "Select * from departamentos where Id=@id";
                cmd.Connection = connOpen;

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        if (dr["Id"] != DBNull.Value)
                        {
                            oDepartamento.IdDepartamento = (int)dr["Id"];
                        }

                        if (dr["Nombre"] != DBNull.Value)
                        {
                            oDepartamento.Nombre = (string)dr["Nombre"];
                        }

                    }
                }

                dr.Close();
                connOpen.Close();


            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return oDepartamento;


        }

    }

    

}
