using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL.Conexion
{
    public class clsConexion
    {

        // conn.ConnectionString = "server=isakatha.database.windows.net;database=BDIsaKatha;uid=prueba;pwd=fernandoG321;trustServerCertificate=true";

        #region atributos

        private string server;
        private string database;
        private string uid;
        private string pwd;

        #endregion

        #region constructores

        public clsConexion()
        {
            server = "isakatha.database.windows.net";
            database = "BDIsaKatha";
            uid = "prueba";
            pwd = "fernandoG321";

        }

        public clsConexion(String server, String database, String uid, String pwd)
        {
            this.server = server;
            this.database = database;
            this.uid = uid;
            this.pwd = pwd;
           
        }

        #endregion

        #region funciones y metodos

        /// <summary>
        /// Función que crea y abre una conexión con la base de datos
        /// Pre: ninguna
        /// Post: ninguna
        /// </summary>
        /// <returns>conexion con la base de datos</returns>
        public SqlConnection createConnection()
        {

            SqlConnection conn = new SqlConnection();

            try
            {
                conn.ConnectionString = $"server={server};database={database};uid={uid};pwd={pwd};trustServerCertificate=true;";
                conn.Open();

            }catch (SqlException ex)
            {
                throw;
            }

            return conn;
        }
       


        #endregion


    }
}
