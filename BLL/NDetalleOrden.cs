using DAL;
using Entidades;
using System;
using System.Data;

namespace BLL
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
        public bool Eliminar(int _idDetalleOrden, int _idorden)
        {
            return unDetalleOrden.Eliminar(_idDetalleOrden, _idorden);
        }
        public bool EliminarPorOrden(int _unOrden)
        {
            return unDetalleOrden.EliminarPorOrden(_unOrden);
        }
        public DataTable ListarDetalleOrden(int _idOrden)
        {
            return unDetalleOrden.ListadeDetalleOrden(_idOrden);
        }
    }
}
