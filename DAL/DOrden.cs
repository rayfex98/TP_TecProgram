using System;
using Entidades;
using System.Data;

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
                Conexion db = new Conexion();
                string query = string.Format("EXEC ORDENPROD @ID = NULL,@USUARIO={0},@FECHA=NULL,@TIPO = 'INSERT';", unOrden.UsuarioCreador.ID);
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
    }
}
