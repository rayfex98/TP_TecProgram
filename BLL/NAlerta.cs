using DAL;
using Entidades;
using System;
using System.Data;

namespace BLL
{
    public class NAlerta
    {
        DAlerta unAlerta = new DAlerta();

        public bool CrearAlerta(Alerta _unAlerta)
        {
            return unAlerta.CrearAlerta(_unAlerta);
        }
        public bool EditarAlerta(Alerta _unAlerta)
        {
            return unAlerta.EditarAlerta(_unAlerta);
        }
        public bool EliminarAlerta(int idAlerta)
        {
            return unAlerta.EliminarAlerta(idAlerta);
        }
        public DataTable ListarAlerta()
        {
            return unAlerta.ListadeAlertas();
        }
        public DataTable ListarAlertasCriticas()
        {
            return unAlerta.ListalertasCriticas();
        }
    }
}
