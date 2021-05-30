using Entidades;
using System.Data;

namespace ddl_modulo
{
    public class DStock
    {
        public string Nuevo(DStock _Stock)
        {
            //conexion con bbdd
            return "Ok";
        }
        public string Editar(DStock _Stock)
        {
            //conexion con bbdd
            return "Ok";
        }
        public Stock Eliminar(int idProducto)
        {
            Stock eliminado = new Stock();
            //conexion con bbdd
            return eliminado;
        }
        public int ID_Stock()
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
