using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace Datos
{
    public class DOrdenCompra
    {
        public string Nuevo(OrdenCompra unOrdenCompra)
        {
            //conexion con bbdd
            return "Ok";
        }
        public string Editar(OrdenCompra unOrdenCompra)
        {
            //conexion con bbdd
            return "Ok";
        }
        public OrdenCompra Eliminar(int idOrden)
        {
            OrdenCompra eliminado = new OrdenCompra();
            //conexion con bbdd
            return eliminado;
        }
        public int ID_OrdenCompra()
        {
            return 0;
        }

        public DataTable ListadeOrdenCompra()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
        public bool EstaAprobada(Usuario UsuarioAprovador)
        {
            //conexion
            return true;
        }
    }
}