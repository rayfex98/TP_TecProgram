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
        /// Crear nuevo stock de un producto
        /// </summary>
        /// <param name="_Stock">requiero id del producto y cantidad a setear</param>
        /// <returns></returns>
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
