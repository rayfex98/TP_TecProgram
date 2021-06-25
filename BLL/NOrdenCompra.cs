using DAL;
using Entidades;
using System.Data;
using Excepciones;

namespace BLL
{
    public class NOrdenCompra
    {
        DOrdenCompra unOrdenCompra = new DOrdenCompra();

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
        public DataTable OrdenCompraBuscarProducto(string nombre)
        {
            return unOrdenCompra.OrdenCompraBuscarProducto(nombre);
        }
            public bool AprobarOrden(OrdenDeCompra _unOrdenCompra)
        {
            if (_unOrdenCompra.ID < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unOrdenCompra.AprobarOrden(_unOrdenCompra))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        public float CalcularTotalOrden(int id)
        {
            float total = 0;
            int cantidad;
            float precio;
            DataTable Totales = unOrdenCompra.CalcularTotal(id);
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
