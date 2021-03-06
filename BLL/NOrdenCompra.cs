using DAL;
using Entidades;
using System.Data;
using Excepciones;
using System.Collections.Generic;

namespace BLL
{
    public class NOrdenCompra
    {
        DOrdenCompra unOrdenCompra = new DOrdenCompra();
        DataTable dt = new DataTable();
        NDetalleOrden NewDetalle = new NDetalleOrden();
        DOrden NewOrden = new DOrden();
        NOrden NOrden = new NOrden();
        /// <summary>
        /// Carga de la orden de compra en bbdd,
        /// Requiero id_proveedor, id_usuarioCreador y lista de detalles(con idproducto y cantidades)
        /// </summary>
        /// <param name="_unOrdenCompra"></param>
        /// <returns>True o excepcion "FallaEnInsercion"</returns>
        public bool NuevaOrden(OrdenDeCompra _unOrdenCompra)
        {
            NOrden.Nuevo(_unOrdenCompra.UsuarioCreador.ID);
            _unOrdenCompra.ID = NewOrden.UltimaOrden();
            NewDetalle.CargarListaDetalles(_unOrdenCompra.Detalles, _unOrdenCompra.ID);
            if (_unOrdenCompra.Proveedor.ID < 0 || _unOrdenCompra.UsuarioCreador.ID < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unOrdenCompra.NuevoOrden(_unOrdenCompra))
            {
                return true;
            }
            throw new FallaEnInsercion();
        }
        public bool EditarOrden(OrdenDeCompra _unOrdenCompra)
        {
            if(_unOrdenCompra.ID < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unOrdenCompra.EditarOrden(_unOrdenCompra))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        public bool EliminarOrden(int _idOrden)
        {
            if (_idOrden < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unOrdenCompra.EliminarOrden(_idOrden))
            {
                return true;
            }
            throw new FallaEnEliminacion();
        }
        /// <summary>
        /// columnas: 'Orden','Creador','Creacion','Aprobador','Fecha Aprobacion','Proveedor'
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public DataTable RecuperarOrdenCompra()
        {
            dt = unOrdenCompra.ListadeOrdenCompra();
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
        /// <summary>
        /// columnas: 'Orden','Creador','Creacion','Aprobador','Fecha Aprobacion','Proveedor'
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public DataTable RecuperarOrdenPendiente()
        {
            dt = unOrdenCompra.OrdenPendiente();
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
        /// <summary>
        /// Toma id de orden y usuario para aprobar en la bbdd
        /// </summary>
        /// <param name="id_orden"></param>
        /// <param name="id_usuario"></param>
        /// <returns>True, ExcepcionDeDatos o FallaEnEdicion </returns>
        public bool AprobarOrden(int id_orden, int id_usuario)
        {
            if (id_orden < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unOrdenCompra.AprobarOrden(id_orden, id_usuario))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        public float RecuperarTotalCompra(int idOrden)
        {
            float total = 0;
            int cantidad;
            float precio;
            DataTable Totales = unOrdenCompra.CalcularTotal(idOrden);
            foreach (DataRow item in Totales.Rows)
            {
                cantidad = int.Parse(item.ItemArray[0].ToString());
                precio = float.Parse(item.ItemArray[1].ToString());
                total += cantidad * precio;
            }
            return total;
        }
        /// <summary>
        /// columnas: 'id orden ','cantidad','producto','razon social','fecha aprobacion'
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>DataTable, Excepcion "NoEncontrado" o "ExcepcionDeDatos"</returns>
        public DataTable RecuperarPorProducto(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ExcepcionDeDatos();
            }
            dt = unOrdenCompra.ListaPorProducto(nombre);
            if(dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
        /// <summary>
        /// columnas: 'id orden ','cantidad','producto','razon social','fecha aprobacion'
        /// </summary>
        /// <param name="razonSocial"></param>
        /// <returns>DataTable, Excepcion "NoEncontrado" o "ExcepcionDeDatos"</returns>
        public DataTable RecuperarPorProveedor(string razonSocial)
        {
            if (string.IsNullOrEmpty(razonSocial))
            {
                throw new ExcepcionDeDatos();
            }
            dt = unOrdenCompra.ListaPorProveedor(razonSocial);
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
    }
}
