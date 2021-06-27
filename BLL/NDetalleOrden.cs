using DAL;
using Entidades;
using Excepciones;
using System.Data;
using System.Collections.Generic;
namespace BLL
{
    public class NDetalleOrden
    {
        readonly DDetalleOrden unDetalleOrden = new DDetalleOrden();
        readonly List<DetalleOrden> detalles = new List<DetalleOrden>();

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
        /// <summary>
        /// columnas : 'cantidad','producto'
        /// </summary>
        /// <param name="_idOrden"></param>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public DataTable RecuperarDetalleOrden(int _idOrden)
        {
            DataTable dt = unDetalleOrden.ListadeDetalleOrden(_idOrden);
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
        public bool CargarListaDetalles(List<DetalleOrden> detalle, int id_orden )
        {
            NDetalleOrden NewDetalle = new NDetalleOrden();
            detalles = detalle;
            bool retorno= true;

            foreach (DetalleOrden item in detalles)
            {
                if (NewDetalle.Nuevo(item, id_orden) != false)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            return retorno;
        }
        public int RecuperarUltimoid()
        {
            int id= 0;
            DDetalleOrden NewDetalle = new DDetalleOrden();
            DataTable Totales = NewDetalle.UltimaOrden();
            foreach (DataRow item in Totales.Rows)
            {
                id = int.Parse(item.ItemArray[0].ToString());
            }
            return id;
        }
    }
}
