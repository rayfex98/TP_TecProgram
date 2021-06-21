using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{
    public class NProducto
    {
        DProducto unProducto = new DProducto();

        public bool NuevoProducto(Producto _proveedor)
        {
            return unProducto.NuevoProducto(_proveedor);
        }
        public bool EditarProducto(Producto _producto)
        {
            return unProducto.EditarProducto(_producto);
        }
        public bool EliminarProducto(int _idProducto)
        {
            return unProducto.EliminarProducto(_idProducto);
        }
        public DataTable ListarProductos()
        {
            return unProducto.ListadeProductos();
        }
    }
}
