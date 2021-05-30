using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo 
{
    public class NAlerta
    {
        DAlerta unAlerta = new DAlerta();

        public bool Nuevo(Alerta _unAlerta, Persona unapersona, Stock stock)
        {

            return unAlerta.Nuevo(_unAlerta, unapersona, stock);
        }
        public bool Editar(Alerta _unAlerta, int id_alerta)
        {
            return unAlerta.Editar(_unAlerta, id_alerta);
        }
        public bool Eliminar(int _idProducto)
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