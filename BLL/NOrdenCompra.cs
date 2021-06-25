using DAL;
using Entidades;
using System.Data;
using Excepciones;

namespace BLL
{
    public class NOrdenCompra
    {
        DOrdenCompra unOrdenCompra = new DOrdenCompra();
        /// <summary>
        /// Carga de la orden de compra en bbdd,
        /// Requiero id_proveedor, id_usuarioCreador
        /// </summary>
        /// <param name="_unOrdenCompra"></param>
        /// <returns>True o excepcion "FallaEnInsercion"</returns>
        public bool NuevoOrden(OrdenDeCompra _unOrdenCompra)
        {
            if (_unOrdenCompra.Proveedor.ID < 0 || _unOrdenCompra.UsuarioCreador.ID < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unOrdenCompra.NuevoOrden(_unOrdenCompra))
            {
                return true;
            }
            throw new FallaEnInsercion();
        }
        public bool EditarOrden(OrdenDeCompra _unOrdenCompra)
        {
            if(_unOrdenCompra.ID < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unOrdenCompra.EditarOrden(_unOrdenCompra))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        public bool EliminarOrden(int _idOrden)
        {
            if (_idOrden < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unOrdenCompra.EliminarOrden(_idOrden))
            {
                return true;
            }
            throw new FallaEnEliminacion();
        }
        public DataTable ListarOrdenCompra()
        {
            return unOrdenCompra.ListadeOrdenCompra();
        }
        public DataTable OrdenPendiente()
        {
            return unOrdenCompra.OrdenPendiente();
        }
        public bool AprobarOrden(int id_orden)
        {
            if (id_orden < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unOrdenCompra.AprobarOrden(id_orden))
            {
                return true;
            }
            throw new FallaEnEdicion();
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
