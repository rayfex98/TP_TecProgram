using Excepciones;
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
            DataTable dt = unDeposito.ListadeDeposito();
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
        public bool QuitarDeDeposito(OrdenDeCompra _unOrdenCompra)
        {
            if (unDeposito.QuitarDeDeposito(_unOrdenCompra))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        public bool AgregarADeposito(OrdenDeCompra _unOrdenCompra)
        {
            if (unDeposito.AgregarADeposito(_unOrdenCompra))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
    }
}
