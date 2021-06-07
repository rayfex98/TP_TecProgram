using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
{
    public class NOrdenCompra
    {
        DOrdenCompra unOrdenCompra = new DOrdenCompra();

        public bool Nuevo(OrdenDeCompra _unOrdenCompra)
        {
            return unOrdenCompra.Nuevo(_unOrdenCompra);
        }
        public bool Editar(OrdenDeCompra _unOrdenCompra)
        {
            return unOrdenCompra.Editar(_unOrdenCompra);
        }
        public bool Eliminar(int _idOrden)
        {
            return unOrdenCompra.Eliminar(_idOrden);
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
        public DataTable OrdenPendiente()
        {
            return unOrdenCompra.OrdenPendiente();
        }
    }
}
