using System.Data;
using Datos;
using Entidades;

namespace Negocio
{
    class NProducto
    {
        DProducto unProducto = new DProducto();

        public string Nuevo(Producto _proveedor)
        {
            return unProducto.Nuevo(_proveedor);
        }
        public string Editar(Producto _proveedor)
        {
            return unProducto.Editar(_proveedor);
        }
        public string Eliminar(int _idProducto)
        {
            return unProducto.Eliminar(_idProducto);
        }
        public int ID_Proveedor()
        {
            return unProducto.ID_Producto();
        }
        public DataTable ListarProductos()
        {
            return unProducto.ListadeProveedores();
        }
    }
}
