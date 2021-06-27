using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DDetalleOrden
    {
        readonly Conexion db = new Conexion();
        DataTable dt = new DataTable();
        public bool Nuevo(DetalleOrden unDetalleOrden, int idOrden)
        {
            try
            {

                string query = string.Format("EXEC DETALLEPROC @ID = NULL,@ORDEN={0},@PRODUCTO={1},@CANTIDAD={2},@TIPO = 'INSERT';"
                    , idOrden, unDetalleOrden.Producto.ID, unDetalleOrden.Cantidad);
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
        public bool Editar(DetalleOrden unDetalleOrden, int idOrden)
        {
            try
            {
                string query = string.Format("EXEC DETALLEPROC @ID = {0},@ORDEN={1},@PRODUCTO={2},@CANTIDAD={3},@TIPO = 'UPDATE';"
                    , unDetalleOrden.ID, idOrden, unDetalleOrden.Producto.ID, unDetalleOrden.Cantidad);
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
        public bool Eliminar(int idDetalle, int idOrden)
        {
            try
            {
                string query = string.Format("EXEC DETALLEPROC @ID = {0},@ORDEN={1},@PRODUCTO=NULL,@CANTIDAD=NULL,@TIPO = 'DELETE';", idDetalle, idOrden);
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
        public bool EliminarPorOrden(int id)
        {
            try
            {

                string query = string.Format("EXEC DETALLEPROC @ID = NULL,@ORDEN={0},@PRODUCTO=NULL,@CANTIDAD=NULL,@TIPO = 'DELETE';", id);
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
        public DataTable ListadeDetalleOrden(int idOrden)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@idorden",SqlDbType.Int)
            };
            parametros[0].Value = idOrden;
            dt = db.LeerPorStoreProcedure("listadetalle", parametros);
            return dt;
        }
        public DataTable UltimaOrden()
        {
            Conexion db = new Conexion();
            string query = string.Format("ultimoidOrden");
            dt = db.LeerPorComando(query);
            return dt;

        }
    }
}
