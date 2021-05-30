using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
{
    public class NProducto
    {
        DProducto unProducto = new DProducto();

        public bool Nuevo(Producto _proveedor)
        {
            return unProducto.Nuevo(_proveedor);
        }
        public bool Editar(Producto _producto)
        {
            return unProducto.Editar(_producto);
        }
        public bool Eliminar(Producto _idProducto)
        {
            return unProducto.Eliminar(_idProducto);
        }
        public DataTable ListarProductos()
        {
            return unProducto.ListadeProductos();
        }
    }
}
