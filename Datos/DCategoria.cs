using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace Datos
{
    public class DCategoria
    {
        public string Nuevo(Categoria unCategoria)
        {
            //conexion con bbdd
            return "Ok";
        }
        public string Editar(Categoria unCategoria)
        {
            //conexion con bbdd
            return "Ok";
        }
        public Categoria Eliminar(int idCategoria)
        {
            Categoria eliminado = new Categoria();
            //conexion con bbdd
            return eliminado;
        }
        public int ID_Categoria()
        {
            return 0;
        }

        public DataTable ListadeCategoria()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}