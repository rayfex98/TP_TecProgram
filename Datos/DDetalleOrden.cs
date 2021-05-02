using System.Data;
using Entidades;

namespace Datos
{
    public class DDetalleOrden
    {
        public string Nuevo(DetalleOrden unDetalleOrden)
        {
            //conexion con bbdd
            return "Ok";
        }
        public string Editar(DetalleOrden unDetalleOrden)
        {
            //conexion con bbdd
            return "Ok";
        }
        public DetalleOrden Eliminar(int idDetalleOrden)
        {
            DetalleOrden eliminado = new DetalleOrden();
            //conexion con bbdd
            return eliminado;
        }
        public int ID_DetalleOrden()
        {
            return 0;
        }
        public DataTable ListadeDetalleOrden()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}