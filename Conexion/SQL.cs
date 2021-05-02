using System;
using System.Data.SqlClient;
using System.Data;

namespace Conexion
{
    public class SQL
    {
        private string cadena = ""; //conectar BBDD local
        private SqlConnection conectar;

        public SqlConnection conectar_db()
        {
            conectar = new SqlConnection(cadena);

            if (conectar.State == ConnectionState.Open)
            {

                conectar.Close();
            }
            else
            {
                conectar.Open();
            }

            return conectar;

        }
    }
}
