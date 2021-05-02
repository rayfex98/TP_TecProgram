using System.Data;
using Datos;
using CapaEntidad;

namespace Negocio
{
    class NProducto
    {
        DProducto unProducto = new DProducto();

        public string Nuevo(Producto _proveedor)
        {
            return unProducto.Nuevo(_proveedor);
        }
        public string Editar(Producto _producto)
        {
            return unProducto.Editar(_producto);
        }
        public Producto Eliminar(int _idProducto)
        {
            return unProducto.Eliminar(_idProducto);
        }
        public int ID_Producto()
        {
            return unProducto.ID_Producto();
        }
        public DataTable ListarProductos()
        {
            return unProducto.ListadeProductos();
        }
    }
}
