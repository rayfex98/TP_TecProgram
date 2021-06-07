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

        public bool Nuevo(Stock _Stock)
        {
            return unStock.Nuevo(_Stock);
        }
        public bool Editar(Stock _Stock)
        {
            return unStock.Editar(_Stock);
        }
        public bool Eliminar(int _idProducto)
        {
            return unStock.Eliminar(_idProducto);
        }
        #region listarStock
        public List<Stock> ListaStock()
        {
            stocks = unStock.ListadoStock();
            return stocks;

        }
        #endregion
        public List<Stock> CargarLista()
        {
            stocks = unStock.ListadoStock();
            return stocks;
        }

        public List<Stock> AgregarStock(int id_producto, int cantidad)
        {
            stocks = unStock.AgregarStock(id_producto,cantidad);

            return stocks;
        }
        public List<Stock> RestarStock(int id_producto, int cantidad)
        {
            stocks = unStock.RestarStock(id_producto, cantidad);

            return stocks;
        }



    }
}