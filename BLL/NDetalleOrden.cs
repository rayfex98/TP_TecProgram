using DAL;
using Entidades;
using Excepciones;
using System.Data;

namespace BLL
{
    public class NDetalleOrden
    {
        DDetalleOrden unDetalleOrden = new DDetalleOrden();

        public bool Nuevo(DetalleOrden _unDetalleOrden, int _idOrden)
        {
            if(_idOrden < 0 || _unDetalleOrden.Cantidad < 0 || _unDetalleOrden.Producto.ID < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unDetalleOrden.Nuevo(_unDetalleOrden, _idOrden))
            {
                return true;
            }
            throw new FallaEnInsercion();
        }
        public bool Editar(DetalleOrden _unDetalleOrden, int _idOrden)
        {
            if (_idOrden < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unDetalleOrden.Editar(_unDetalleOrden, _idOrden))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        public bool Eliminar(int _idDetalleOrden, int _idOrden)
        {
            if (_idOrden < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unDetalleOrden.Eliminar(_idDetalleOrden, _idOrden))
            {
                return true;
            }
            throw new FallaEnEliminacion();
        }
        public bool EliminarPorOrden(int _idOrden)
        {
            if (_idOrden < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unDetalleOrden.EliminarPorOrden(_idOrden))
            {
                return true;
            }
            throw new FallaEnEliminacion();
        }
        public DataTable RecuperarDetalleOrden(int _idOrden)
        {
            DataTable dt = unDetalleOrden.ListadeDetalleOrden(_idOrden);
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
    }
}
