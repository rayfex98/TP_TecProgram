using System.Data;
using Datos;
using CapaEntidad;

namespace Negocio
{
    class NOrdenCompra
    {
        DOrdenCompra unOrdenCompra = new DOrdenCompra();

        public string Nuevo(OrdenCompra _unOrdenCompra)
        {
            return unOrdenCompra.Nuevo(_unOrdenCompra);
        }
        public string Editar(OrdenCompra _unOrdenCompra)
        {
            return unOrdenCompra.Editar(_unOrdenCompra);
        }
        public OrdenCompra Eliminar(int _idOrden) //verID
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
