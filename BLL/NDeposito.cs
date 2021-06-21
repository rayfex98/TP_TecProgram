using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using DAL;
using System.Data;

namespace BLL
{
    public class NDeposito
    {
        DDeposito unDeposito = new DDeposito();

        public DataTable ListarDeposito()
        {
            return unDeposito.ListadeDeposito();
        }
        public bool QuitarDeDeposito(OrdenDeCompra _unOrdenCompra)
        {
            return unDeposito.QuitarDeDeposito(_unOrdenCompra);
        }
        public bool AgregarADeposito(OrdenDeCompra _unOrdenCompra)
        {
            return unDeposito.AgregarADeposito(_unOrdenCompra);
        }
    }
}
