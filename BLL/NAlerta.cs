using DAL;
using Entidades;
using Excepciones;
using System.Data;

namespace BLL
{
    public class NAlerta
    {
        DAlerta unAlerta = new DAlerta();

        public bool CrearAlerta(Alerta _unAlerta)
        {
            if ((_unAlerta.CantidadMinima < 0) || (_unAlerta.Stock.ID < 0) || (_unAlerta.UsuarioCreador.ID < 0)) throw new ExcepcionDeDatos();
            if (unAlerta.CrearAlerta(_unAlerta))
            {
                return true;
            }
            throw new FallaEnInsercion();
        }
        public bool EditarAlerta(Alerta _unAlerta)
        {
            if (unAlerta.EditarAlerta(_unAlerta))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        public bool EliminarAlerta(int idAlerta)
        {
            if(idAlerta < 0) throw new ExcepcionDeDatos();
            if (unAlerta.EliminarAlerta(idAlerta))
            {
                return true;
            }
            throw new FallaEnEliminacion();
        }
        public DataTable ListarAlerta()
        {
            DataTable dt = unAlerta.ListadeAlertas();
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
        public DataTable ListarAlertasCriticas()
        {
            DataTable dt = unAlerta.ListalertasCriticas();
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
    }
}
