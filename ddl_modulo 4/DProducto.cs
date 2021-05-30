using System.Data;
using Entidades;

namespace ddl_modulo
{
    public class DProducto
    {
        public string Nuevo(Producto unProducto)
        {
            //conexion con bbdd
            return "Ok";
        }
        public string Editar(Producto unProducto)
        {
            //conexion con bbdd
            return "Ok";
        }
        public Producto Eliminar(int idProducto)
        {
            Producto eliminado = new Producto();
            //conexion con bbdd
            return eliminado;
        }
        public int ID_Producto()
        {
            return 0;
        }

        public DataTable ListadeProductos()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}
