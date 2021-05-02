using System.Data;
using Datos;
using Entidades;

namespace Negocio
{
    public class NProveedor
    {
        DProveedor ObjProveedor = new DProveedor();

        public string Nuevo(Proveedor _proveedor)
        {
            return ObjProveedor.Nuevo(_proveedor);
        }
        public string Editar(Proveedor _proveedor)
        {
            return ObjProveedor.Editar(_proveedor);
        }
        public Proveedor Eliminar(int _cuil)
        {
            return ObjProveedor.Eliminar(_cuil);
        }
        public int ID_Proveedor()
        {
            return ObjProveedor.ID_Proveedor();
        }
        public DataTable ListarProveedores()
        {
            return ObjProveedor.ListadeProveedores();
        }
    }
}
