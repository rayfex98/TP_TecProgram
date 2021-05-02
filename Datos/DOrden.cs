using System.Data;
using Entidades;

namespace Datos
{
    public class DOrden
    {
        public string Nuevo(Orden unOrden)
        {
            //conexion con bbdd
            return "Ok";
        }
        public string Editar(Orden unOrden)
        {
            //conexion con bbdd
            return "Ok";
        }
        public Orden Eliminar(int idOrden)
        {
            Orden eliminado = new Orden();
            //conexion con bbdd
            return eliminado;
        }
        public int ID_Orden()
        {
            return 0;
        }
        public DataTable ListadeOrden()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}
