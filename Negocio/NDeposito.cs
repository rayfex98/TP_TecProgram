using System;
using System.Data;
using Datos;
using CapaEntidad;

namespace Negocio
{
    public class NDeposito
    {
        DDeposito unDeposito = new DDeposito();

        public string Nuevo(Deposito _unDeposito)
        {
            return unDeposito.Nuevo(_unDeposito);
        }
        public string Editar(Deposito _unDeposito)
        {
            return unDeposito.Editar(_unDeposito);
        }
        public Deposito Eliminar(int _idDeposito)
        {
            return unDeposito.Eliminar(_idDeposito);
        }
        public int ID_Deposito()
        {
            return unDeposito.ID_Deposito();
        }
        public DataTable ListarDeposito()
        {
            return unDeposito.ListadeDeposito();
        }
    }
}
