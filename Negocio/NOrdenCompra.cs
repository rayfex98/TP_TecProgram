using System.Data;
using Datos;
using Entidades;

namespace Negocio
{
    public class NOrdenCompra
    {
        DOrdenCompra unOrdenCompra = new DOrdenCompra();

        public string Nuevo(OrdenDeCompra _unOrdenCompra)
        {
            return unOrdenCompra.Nuevo(_unOrdenCompra);
        }
        public string Editar(OrdenDeCompra _unOrdenCompra)
        {
            return unOrdenCompra.Editar(_unOrdenCompra);
        }
        public OrdenDeCompra Eliminar(int _idOrden) //verID
        {
            return unOrdenCompra.Eliminar(_idOrden);
        }
        public int ID_OrdenCompra()
        {
            return unOrdenCompra.ID_OrdenCompra();
        }
        public DataTable ListarOrdenCompra()
        {
            return unOrdenCompra.ListadeOrdenCompra();
        }
        public bool EstaAprobada(Usuario UsuarioAprovador)
        {
            //guardar el atributo
            return unOrdenCompra.EstaAprobada(UsuarioAprovador);
        }

    }
}
