using DAL;
using Entidades;
using System.Data;

namespace BLL
{
    public class NOrdenCompra
    {
        DOrdenCompra unOrdenCompra = new DOrdenCompra();

        public bool NuevoOrden(OrdenDeCompra _unOrdenCompra)
        {
            return unOrdenCompra.NuevoOrden(_unOrdenCompra);
        }
        public bool EditarOrden(OrdenDeCompra _unOrdenCompra)
        {
            return unOrdenCompra.EditarOrden(_unOrdenCompra);
        }
        public bool EliminarOrden(int _idOrden)
        {
            return unOrdenCompra.EliminarOrden(_idOrden);
        }
        public DataTable ListarOrdenCompra()
        {
            return unOrdenCompra.ListadeOrdenCompra();
        }
        public DataTable OrdenPendiente()
        {
            return unOrdenCompra.OrdenPendiente();
        }
        public bool AprobarOrden(OrdenDeCompra _unOrdenCompra)
        {
            return unOrdenCompra.AprobarOrden(_unOrdenCompra);
        }
        public float CalcularTotalOrden(OrdenDeCompra _unOrdenCompra)
        {
            float total = 0;
            int cantidad;
            float precio;
            DataTable Totales = unOrdenCompra.CalcularTotal(_unOrdenCompra);
            foreach (DataRow item in Totales.Rows)
            {
                cantidad = int.Parse(item.ItemArray[0].ToString());
                precio = float.Parse(item.ItemArray[1].ToString());
                total += cantidad * precio;
            }
            return total;
        }
    }
}
