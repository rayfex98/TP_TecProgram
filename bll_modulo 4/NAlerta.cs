using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo 
{
    public class NAlerta
    {
        DAlerta unAlerta = new DAlerta();

        public bool Nuevo(Alerta _unAlerta)
        {
            return unAlerta.Nuevo(_unAlerta);
        }
        public bool Editar(Alerta _unAlerta)
        {
            return unAlerta.Editar(_unAlerta);
        }
        public bool Eliminar(Alerta _unAlerta)
        {
            return unAlerta.Eliminar(_unAlerta);
        }
        public DataTable ListarAlerta()
        {
            return unAlerta.ListadeAlertas();
        }
    }
}