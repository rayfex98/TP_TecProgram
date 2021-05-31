using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
{
    public class NProveedor
    {
        DProveedor ObjProveedor = new DProveedor();

        public bool Nuevo(Proveedor _proveedor)
        {
            return ObjProveedor.Nuevo(_proveedor);
        }
        public bool Editar(Proveedor _proveedor)
        {
            return ObjProveedor.Editar(_proveedor);
        }
        public bool Eliminar(Proveedor _proveedor)
        {
            return ObjProveedor.Eliminar(_proveedor);
        }
        public DataTable ListarProveedores()
        {
            return ObjProveedor.ListadeProveedores();
        }
    }
}
