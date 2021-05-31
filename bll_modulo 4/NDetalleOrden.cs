using System;
using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
{
    public class NDetalleOrden
    {
        DDetalleOrden unDetalleOrden = new DDetalleOrden();

        public bool Nuevo(DetalleOrden _unDetalleOrden, int _idOrden)
        {
            return unDetalleOrden.Nuevo(_unDetalleOrden, _idOrden);
        }
        public bool Editar(DetalleOrden _unDetalleOrden, int _idOrden)
        {
            return unDetalleOrden.Editar(_unDetalleOrden, _idOrden);
        }
        public bool Eliminar(DetalleOrden _unDetalleOrden)
        {
            return unDetalleOrden.Eliminar(_unDetalleOrden);
        }
        public bool EliminarPorOrden(DetalleOrden _unDetalleOrden)
        {
            return unDetalleOrden.EliminarPorOrden(_unDetalleOrden);
        }
        public DataTable ListarDetalleOrden()
        {
            return unDetalleOrden.ListadeDetalleOrden();
        }
    }
}
