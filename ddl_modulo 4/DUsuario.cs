using System.Data;
using Entidades;

namespace ddl_modulo
{
    public class DUsuario
    {
        public string Nuevo(Usuario unUsuario)
        {
            //conexion con bbdd
            return "Ok";
        }
        public string Editar(Usuario unUsuario)
        {
            //conexion con bbdd
            return "Ok";
        }
        public Usuario Eliminar(int idUsuario)
        {
            Usuario eliminado = new Usuario();
            //conexion con bbdd
            return eliminado;
        }
        public int ID_Usuario()
        {
            return 0;
        }
        public DataTable ListadeUsuario()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}