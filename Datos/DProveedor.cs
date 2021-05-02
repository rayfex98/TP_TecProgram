using System.Data;
using System.Data.SqlClient;
using Entidades;
//usar sql

namespace Datos
{
    public class DProveedor
    {
        public string Nuevo(Proveedor ObjProveedor)
        {
            //conexion con bbdd
            return "Ok";
        }
        public string Editar(Proveedor ObjProveedor)
        {
            //conexion con bbdd
            return "Ok";
        }
        public Proveedor Eliminar(int ObjProveedor)
        {
            Proveedor eliminado = new Proveedor();
            //conexion con bbdd
            return eliminado;
        }
        public int ID_Proveedor()
        {
            return 0;
        }

        public DataTable ListadeProveedores()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}
