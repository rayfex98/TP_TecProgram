using System.Data;
using Entidades;

namespace ddl_modulo
{
    public class DDetalleOrden
    {
        Conexion db = new Conexion();
        public bool Nuevo(DetalleOrden unDetalleOrden, int id_orden)
        {
            string query = string.Format("DETALLEPROC @ID = null,@ORDEN={0},@PRODUCTO={1},@CANTIDAD={2},@TIPO = 'INSERT'; ",id_orden,unDetalleOrden.Producto, unDetalleOrden.Producto,unDetalleOrden.Cantidad);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;
        }
        public bool Editar(DetalleOrden unDetalleOrden,int detalle, int id_orden)
        {
            string query = string.Format("DETALLEPROC @ID = {0}, @ORDEN ={ 1},@PRODUCTO ={ 2},@CANTIDAD ={ 3},@TIPO = 'UPDATE'; ", detalle,id_orden,unDetalleOrden.Producto,unDetalleOrden.Cantidad);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;
        }
        public bool Eliminar(short idDetalleOrden)
        {
            string query = string.Format("DETALLEPROC @ID = {0}, @ORDEN =null,@PRODUCTO =null,@CANTIDAD =null,@TIPO = 'DELETE';",idDetalleOrden );
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;
        }
        public int ID_DetalleOrden()
        {
            return 0;
        }
        public DataTable ListadeDetalleOrden()
        {

            return db.LeerPorStoreProcedure("VISTADETALLE");
        }
    }
}