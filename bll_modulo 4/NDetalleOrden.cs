using System;
using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
{
    public class NDetalleOrden
    {
        DDetalleOrden unDetalleOrden = new DDetalleOrden();

        public string Nuevo(DetalleOrden _unDetalleOrden)
        {
            return unDetalleOrden.Nuevo(_unDetalleOrden);
        }
        public string Editar(DetalleOrden _unDetalleOrden)
        {
            return unDetalleOrden.Editar(_unDetalleOrden);
        }
        public DetalleOrden Eliminar(int _idDetalle)
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
