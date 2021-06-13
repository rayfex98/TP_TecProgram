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
        private List<Stock> stocks;

        #region NuevoStock
        public bool Nuevo(Stock _Stock)
        {
            return unStock.Nuevo(_Stock);
        }
        #endregion
        #region EditarStock
        public bool Editar(Stock _Stock)
        {
            return unStock.Editar(_Stock);
        }
        #endregion
        #region EliminarDeStock
        public bool Eliminar(int _idProducto)
        {
            return unStock.Eliminar(_idProducto);
        }
        #endregion
        #region listarStock
        public List<Stock> ListaStock(string filtro)
        {
            if (string.Compare(filtro, "TODOS") == 0)
            {
                foreach (Stock item in stocks)
                {

                }
            }
            return stocks;
        }
        #endregion
        #region CargarLista
        public List<Stock> CargarLista()
        {
            stocks = unStock.ListadoStock();
            return stocks;
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



    }
}