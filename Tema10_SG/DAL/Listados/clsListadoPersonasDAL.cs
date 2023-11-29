﻿using Microsoft.Data.SqlClient;
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

            clsConexion conexion = new clsConexion();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            clsPersona oPersona = new clsPersona();

            //Añadimos un parámetro que luego necesitaremos en el comando sql.
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                //abrimos la conexion y la guardamos en una variable
                SqlConnection conexionAbierta = conexion.createConnection();

                cmd.CommandText = "Select * from Personas WHERE ID=@id";
                cmd.Connection = conexionAbierta;

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        oPersona.Id = (int)reader["ID"];
                        oPersona.Nombre = (string)reader["Nombre"];
                        oPersona.Apellido = (string)reader["Apellido"];
                        oPersona.Telefono = (string)reader["Telefono"];
                        oPersona.Direccion = (string)reader["Direccion"];
                        oPersona.Foto = (string)reader["Foto"];
                        oPersona.FechaNacimiento = (DateTime)reader["FechaNacimiento"];
                        oPersona.IdDepartamento = (int)reader["IDDepartamento"];

                    }
                }
                reader.Close();
                //Cerramos la conexión
                conexionAbierta.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return oPersona;


        }




    }
}