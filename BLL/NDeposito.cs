using Excepciones;
using Entidades;
using DAL;
using System.Data;

namespace BLL
{
    public class NDeposito
    {
        DDeposito unDeposito = new DDeposito();
        /// <summary>
        /// Llena DT con stocks
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public DataTable ListarDeposito()
        {
            DataTable dt = unDeposito.ListadeDeposito();
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
        /// <summary>
        /// Quita en bbdd los detalles pertenecientes a una orden
        /// </summary>
        /// <param name="idOrden"></param>
        /// <returns>True o Excepcion "FallaEnEdicion"</returns>
        public bool QuitarDeDeposito(int idOrden)
        {
            if (unDeposito.QuitarDeDeposito(idOrden))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        /// <summary>
        /// Carga en bbdd los detalles pertenecientes a una orden
        /// </summary>
        /// <param name="idOrden"></param>
        /// <returns>True o Excepcion "FallaEnEdicion"</returns>
        public bool AgregarADeposito(int idOrden)
        {
            if (unDeposito.AgregarADeposito(idOrden))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
    }
}
