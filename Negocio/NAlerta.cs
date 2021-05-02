using System.Data;
using Datos;
using CapaEntidad;

namespace Negocio
{
    public class NAlerta
    {
        DAlerta unAlerta = new DAlerta();

        public string Nuevo(Alerta _unAlerta)
        {
            return unAlerta.Nuevo(_unAlerta);
        }
        public string Editar(Alerta _unAlerta)
        {
            return unAlerta.Editar(_unAlerta);
        }
        public Alerta Eliminar(int _idProducto)
        {
            return unAlerta.Eliminar(_idProducto);
        }
        public int ID_Alerta()
        {
            return unAlerta.ID_Alerta();
        }
        public DataTable ListarAlerta()
        {
            return unAlerta.ListadeAlertas();
        }
    }
}