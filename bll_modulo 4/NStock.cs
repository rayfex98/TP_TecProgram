using System;
using System.Data;
using Entidades;
using ddl_modulo;

namespace bll_modulo
{
    class NStock
    {
        DStock unStock = new DStock();

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
    }
}
