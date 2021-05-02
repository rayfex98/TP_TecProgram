using System;
using System.Data;
using Entidades;
using Datos;

namespace Negocio
{
    class NStock
    {
        DStock unStock = new DStock();

        public string Nuevo(DStock _Stock)
        {
            return unStock.Nuevo(_Stock);
        }
        public string Editar(DStock _Stock)
        {
            return unStock.Editar(_Stock);
        }
        public Stock Eliminar(int _idProducto)
        {
            return unStock.Eliminar(_idProducto);
        }
        public int ID_Stock()
        {
            return unStock.ID_Stock();
        }
        public DataTable ListarStock()
        {
            return unStock.ListadeProveedores();
        }
    }
    }
}
