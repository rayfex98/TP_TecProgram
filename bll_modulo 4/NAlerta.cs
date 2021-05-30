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