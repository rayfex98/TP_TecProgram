using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
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
        public bool Eliminar(Producto _idProducto)
        {
            return unProducto.EliminarProducto(_idProducto);
        }
        public DataTable ListarProductos()
        {
            return unProducto.ListadeProductos();
        }
    }
}
