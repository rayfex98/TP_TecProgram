using System.Data;
using Datos;
using Entidades;

namespace Negocio
{
    public class NOrden
    {
        DOrden unOrden = new DOrden();

        public string Nuevo(Orden _unOrden)
        {
            return unOrden.Nuevo(_unOrden);
        }
        public string Editar(Orden _unOrden)
        {
            return unOrden.Editar(_unOrden);
        }
        public Orden Eliminar(int _idOrden)
        {
            return unOrden.Eliminar(_idOrden);
        }
        public int ID_Orden()
        {
            return unOrden.ID_Orden();
        }
        public DataTable ListarOrden()
        {
            return unOrden.ListadeOrden();
        }
    }
}
