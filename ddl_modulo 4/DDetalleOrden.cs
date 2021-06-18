using System.Data;
using Entidades;
using ExcepcionesControladas;

namespace ddl_modulo
{
    public class DDetalleOrden
    {
        Conexion db = new Conexion();
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
        public bool Eliminar(DetalleOrden unDetalle , int idorden )
        {
            try
            {          
                    string query = string.Format("EXEC DETALLEPROC @ID = {0},@ORDEN={1},@PRODUCTO=NULL,@CANTIDAD=NULL,@TIPO = 'DELETE';", unDetalle.ID, idorden );
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
        public bool EliminarPorOrden(DetalleOrden unDetalle)
        {
            try
            {
              
                    string query = string.Format("EXEC DETALLEPROC @ID = {0},@ORDEN=null,@PRODUCTO=NULL,@CANTIDAD=NULL,@TIPO = 'DELETE';", unDetalle.ID);
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
        public DataTable ListadeDetalleOrden()
        {

                  string query = string.Format("ListaCategorias");
            dt = db.LeerPorComando(query);
            return dt;
        }
    }
}