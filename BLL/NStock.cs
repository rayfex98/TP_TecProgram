using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{
    public class NStock
    {
        readonly DStock unStock = new DStock();

        #region NuevoStock
        public bool CargarProductoEnStock(Stock _Stock)
        {
            return unStock.CargarProductoEnStock(_Stock);
        }
        #endregion
      
        #region EditarStock
        public bool EditarStock(Stock _Stock)
        {
            return unStock.EditarStock(_Stock);
        }
        #endregion
        
        #region EliminarDeStock
        public bool EliminarStock(int _idProducto)
        {
            return unStock.EliminarStock(_idProducto);
        }
        #endregion

        #region AgregarStock
        public bool AgregarStock(int id_producto, int cantidad)
        {
            return unStock.AgregarStock(id_producto, cantidad);
        }
        #endregion
      
        #region RestarStock
        public bool RestarStock(int id_producto, int cantidad)
        {
            return unStock.RestarStock(id_producto, cantidad);
        }
        #endregion
       
        #region ListarStockVista
        public DataTable ListarStockVista()
        {
            return unStock.ListarStockVista();
        }
        #endregion
    }
}
