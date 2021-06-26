using System;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DOrden
    {
        DataTable dt = new DataTable();
        readonly Conexion db = new Conexion();
        public bool Nuevo(Orden unOrden)
        {
            try
            {
                SqlParameter[] parametros =
                {
                    new SqlParameter("@USUARIO",SqlDbType.Int),
                    new SqlParameter("@TIPO",SqlDbType.NVarChar)
                };
                parametros[0].Value = unOrden.UsuarioCreador.ID;
                parametros[1].Value = "INSERT";
                if (db.EscribirPorStoreProcedure("ORDENPROC", parametros) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }
        public bool Editar(Orden unOrden)
        {
            try
            {
                Conexion db = new Conexion();
                string query = string.Format("EXEC ORDENPROD @ID={0},@USUARIO={1},@FECHA=NULL,@TIPO = 'UPDATE';", unOrden.ID, unOrden.UsuarioCreador.ID);
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
        public bool Deshabilitar(int idOrden)
        {
            try
            {
                Conexion db = new Conexion();
                string query = string.Format("EXEC ORDENPROD @ID={0},@USUARIO=NULL,@FECHA=NULL,@TIPO = 'DESHABILITAR';", idOrden);
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
        public bool Eliminar(int idOrden)
        {
            try
            {
                string query = string.Format("EXEC ORDENPROD @ID={0},@USUARIO=NULL,@FECHA=NULL,@TIPO = 'DELETE';", idOrden);
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
        public int UltimaOrden()
        {
            try
            {
                string query = string.Format("SELECT MAX([ID]) FROM [dbo].[orden]");
                dt = db.LeerPorComando(query);
                return int.Parse(dt.Rows[0].ItemArray[0].ToString());

            }
            catch (System.Data.SqlClient.SqlException)
            {
                return -1;
            }
            catch (System.NullReferenceException)
            {
                return -1;
            }
        }
    }
}
