using System.Data;
using Entidades;

namespace ddl_modulo
{
    public class DOrdenCompra
    {
        public string Nuevo(OrdenDeCompra unOrdenCompra)
        {
            //conexion con bbdd
            return "Ok";
        }
        public string Editar(OrdenDeCompra unOrdenCompra)
        {
            //conexion con bbdd
            return "Ok";
        }
        public OrdenDeCompra Eliminar(int idOrden)
        {
            OrdenDeCompra eliminado = new OrdenDeCompra();
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