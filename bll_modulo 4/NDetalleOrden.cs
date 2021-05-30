using System;
using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
{
    public class NDetalleOrden
    {
        DDetalleOrden unDetalleOrden = new DDetalleOrden();

        public bool Nuevo(DetalleOrden _unDetalleOrden, int id_orden)
        {
            return unDetalleOrden.Nuevo(_unDetalleOrden,id_orden);
        }
        public bool Editar(DetalleOrden _unDetalleOrden, int detalle, int id_orden)
        {
            return unDetalleOrden.Editar(_unDetalleOrden,detalle,id_orden);
        }
        public bool Eliminar(short _idDetalle)
        {
            return unDetalleOrden.Eliminar(_idDetalle);
        }
        public int ID_DetalleOrden()
        {
            return unDetalleOrden.ID_DetalleOrden();
        }
        public DataTable ListarDetalleOrden()
        {
            return unDetalleOrden.ListadeDetalleOrden();
        }
    }
}
