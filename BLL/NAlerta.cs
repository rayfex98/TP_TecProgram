using DAL;
using Entidades;
using Excepciones;
using System.Data;

namespace BLL
{
    public class NAlerta
    {
        readonly DAlerta unAlerta = new DAlerta();
        /// <summary>
        /// Carga Alerta en bbdd,
        /// Requiero id_stock, id_usuario, cantidad minima
        /// </summary>
        /// <param name="_unAlerta"></param>
        /// <returns>True o Excepcion "FallaEnInsercion"</returns>
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
        /// <summary>
        /// columnas: 'id alerta','Descripcion', 'producto','usuario', 'cantidad minima','cantidad stock'
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public DataTable RecuperarAlerta()
        {
            Alerta _alerta = new Alerta
            {
                TablaReporte = unAlerta.ListadeAlertas()
            };
            if (_alerta.TablaReporte.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return _alerta.TablaReporte;
        }
        /// <summary>
        /// columnas: 'id alerta','Descripcion', 'producto','usuario', 'cantidad minima','cantidad stock'
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public DataTable RecuperarAlertasCriticas()
        {
            Alerta _alerta = new Alerta
            {
                TablaReporte = unAlerta.ListalertasCriticas()
            };
            if (_alerta.TablaReporte.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return _alerta.TablaReporte;
        }
    }
}
