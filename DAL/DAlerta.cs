using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAlerta
    {
        DataTable dt = new DataTable();
        readonly Conexion db = new Conexion();
        public bool CrearAlerta(Alerta unAlerta)
        {
            try
            {
                SqlParameter[] parametros =
                {
                    new SqlParameter("@STOCK",SqlDbType.Int),
                    new SqlParameter("@USUARIO",SqlDbType.Int),
                    new SqlParameter("@MINIMO",SqlDbType.Int),
                    new SqlParameter("@TIPO",SqlDbType.NVarChar),
                    new SqlParameter("@ID",SqlDbType.Int)
                };
                parametros[0].Value = unAlerta.Stock.ID;
                parametros[1].Value = unAlerta.UsuarioCreador.ID;
                parametros[1].Value = unAlerta.CantidadMinima;
                parametros[3].Value = "INSERT";
                parametros[4].Value = 0;
                if (1 != db.EscribirPorStoreProcedure("ALERTAPROC", parametros))
                {
                    return false;
                }
                return true;

            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }
        public bool EditarAlerta(Alerta unAlerta)
        {
            string query = string.Format(" ALERTAPROC @ID = {0}, @STOCK = {1}, @USUARIO = {2}, @MINIMO = {3}, @TIPO = 'UPDATE' ", unAlerta.ID, unAlerta.Stock.ID, unAlerta.UsuarioCreador.ID, unAlerta.CantidadMinima);
            if (1 == db.EscribirPorComando(query))
            {
                return true;
            }
            return false;

        }
        public bool EliminarAlerta(int unAlerta)
        {
            try
            {
                string query = string.Format("ALERTAPROC @ID = {0},@STOCK = null,@USUARIO = null,@MINIMO = null ,@TIPO = 'DELETE';", unAlerta);
                if (1 != db.EscribirPorComando(query))
                {
                    return false;
                }
                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
            catch (System.NullReferenceException)
            {
                return false;
            }
        }


        public DataTable ListadeAlertas()
        {
            string query = string.Format("VistaAlertas");
            dt = db.LeerPorComando(query);
            return dt;
        }
        public DataTable ListalertasCriticas()
        {
            string query = string.Format("VistaAlertasCriticas");
            dt = db.LeerPorComando(query);
            return dt;
        }

    }
}
