using System.Data;
using Entidades;

namespace Datos
{
    public class DDireccion
    {
        public string Nuevo(Direccion unDireccion)
        {
            //conexion con bbdd
            return "Ok";
        }
        public string Editar(Direccion unDireccion)
        {
            //conexion con bbdd
            return "Ok";
        }
        public Direccion Eliminar(int idDireccion, int _DNI)
        {
            Direccion eliminado = new Direccion();
            //conexion con bbdd
            return eliminado;
        }
        public int ID_Direccion()
        {
            return 0;
        }
        public DataTable ListadeDireccion()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}
