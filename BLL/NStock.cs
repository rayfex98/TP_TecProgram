using DAL;
using Entidades;
using Excepciones;
using System.Data;

namespace BLL
{
    public class NStock
    {
        readonly DStock unStock = new DStock();

        /// <summary>
        /// Crear nuevo stock de un producto,
        /// Requiero id_producto y cantidad
        /// </summary>
        /// <param name="_Stock">requiero id del producto y cantidad a setear</param>
        /// <returns>True o Excepcion "FallaEnInsercion"</returns>
        #region NuevoStock
        public bool CargarProductoEnStock(Stock _Stock)
        {
            if (_Stock.Cantidad < 0 || _Stock.Producto.ID < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unStock.CargarProductoEnStock(_Stock))
            {
                return true;
            }
            throw new FallaEnInsercion();
        }
        #endregion
      
        #region EditarStock
        public bool EditarStock(Stock _Stock)
        {
            if (_Stock.ID < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unStock.EditarStock(_Stock))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        #endregion
        
        #region EliminarDeStock
        public bool EliminarStock(int _idProducto)
        {
            if (_idProducto < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unStock.EliminarStock(_idProducto))
            {
                return true;
            }
            throw new FallaEnEliminacion();
        }
        #endregion

        #region AgregarStock
        /// <summary>
        /// Reducir cantidad de stock del producto,
        /// Requiero id_producto y cantidad
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="Cantidad">Entero positivo</param>
        /// <returns>True o Excepcion "FallaEnEdicion"</returns>
        public bool AgregarStock(int idProducto, int Cantidad)
        {
            if (idProducto < 0 || Cantidad < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unStock.AgregarStock(idProducto, Cantidad))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        #endregion

        #region RestarStock
        /// <summary>
        /// Reducir cantidad de stock del producto,
        /// Requiero id_producto y cantidad
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="Cantidad">Entero positivo</param>
        /// <returns>True o Excepcion "FallaEnEdicion"</returns>
        public bool RestarStock(int idProducto, int Cantidad)
        {
            if (idProducto < 0 || Cantidad < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unStock.RestarStock(idProducto, Cantidad))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        #endregion

        #region ListarStockVista
        /// <summary>
        /// Llena DT con Stock
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public DataTable ListarStockVista()
        {
            DataTable dt = unStock.ListarStockVista();
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
        #endregion
    }
}
