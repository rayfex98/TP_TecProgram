using System;
using System.Data.SqlClient;
using System.Data;

/*Uso en CapaNegocio
Conexion cn = new Conexion(); 
SqlCommand cmd;

public void Metodo()
{
    cmd = new SqlCommand("Metodo", cn.conectar_db());
    *Operaciones de la BBDD*
}
*/


namespace Conexion
{
    public class SQL
    {
        private string cadena = "Server=(local);DataBase=NombreSistema;Integrated Security=True"; //conectar BBDD local
        /*private SqlConnection conectar;

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

        }*/
    }
}
