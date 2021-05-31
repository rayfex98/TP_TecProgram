using System.Data;
using Entidades;

namespace ddl_modulo
{
    public class DDetalleOrden
    {
        public bool Nuevo(DetalleOrden unDetalleOrden, int idOrden)
        {
            try
            {
                Conexion db = new Conexion();
                if (!ID_DetalleOrden(false, idOrden, unDetalleOrden.ID))
                {
                    string query = string.Format("EXEC DETALLEPROC @ID = NULL,@ORDEN={0},@PRODUCTO={1},@CANTIDAD={2},@TIPO = 'INSERT';"
                        , idOrden, unDetalleOrden.Producto.ID, unDetalleOrden.Cantidad);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
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
                Conexion db = new Conexion();
                if (!ID_DetalleOrden(true, unDetalleOrden.ID, -1))
                {
                    string query = string.Format("EXEC DETALLEPROC @ID = {0},@ORDEN={1},@PRODUCTO={2},@CANTIDAD={3},@TIPO = 'UPDATE';"
                        , unDetalleOrden.ID, idOrden, unDetalleOrden.Producto.ID, unDetalleOrden.Cantidad);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                    return true;
                }
                return false;
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
        public bool Eliminar(DetalleOrden unDetalle)
        {
            try
            {
                Conexion db = new Conexion();
                if (ID_DetalleOrden(true, unDetalle.ID, -1))
                {
                    string query = string.Format("EXEC DETALLEPROC @ID = {0},@ORDEN=NULL,@PRODUCTO=NULL,@CANTIDAD=NULL,@TIPO = 'DELETE';", unDetalle.ID);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
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
        public bool EliminarPorOrden(DetalleOrden unDetalle)
        {
            try
            {
                Conexion db = new Conexion();
                if (ID_DetalleOrden(true, unDetalle.ID, -1))
                {
                    string query = string.Format("EXEC DETALLEPROC @ID = NULL,@ORDEN={0},@PRODUCTO=NULL,@CANTIDAD=NULL,@TIPO = 'DELETE';", unDetalle.ID);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
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
        public bool ID_DetalleOrden(bool metodo, int orden, int producto)
        {
            try
            {
                Conexion db = new Conexion();
                string query;
                if (metodo == true)
                {
                    query = string.Format("EXEC DETALLEPROC @ID = {0},@ORDEN=NULL,@PRODUCTO=NULL,@CANTIDAD=NULL,@TIPO = 'SELECTONE';", orden);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                }
                else
                {
                    query = string.Format("EXEC DETALLEPROC @ID = NULL,@ORDEN={0},@PRODUCTO={1},@CANTIDAD=NULL,@TIPO = 'SELECTID';", orden, producto);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
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
        public DataTable ListadeDetalleOrden()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}