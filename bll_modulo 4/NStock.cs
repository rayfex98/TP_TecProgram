using System;
using System.Data;
using Entidades;
using ddl_modulo;
using System.Collections.Generic;

namespace bll_modulo
{
    public class NStock
    {
        DStock unStock = new DStock();

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
            if (unStock.AgregarStock(id_producto, cantidad))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region RestarStock
        public bool RestarStock(int id_producto, int cantidad)
        {
            if (unStock.RestarStock(id_producto, cantidad))
            {
                return true;
            }
            else
            {
                return false;
            }
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