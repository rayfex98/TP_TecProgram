using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using Entidades;

namespace PruebasUnitarias
{
    [TestClass]
    public class TOrdenCompra
    {
        OrdenDeCompra _unOrdencompra = new OrdenDeCompra();
        NOrdenCompra NordenCompra = new NOrdenCompra();

        [TestMethod]
        public void _1Insert()// inserta una orden de compra dentro de orden de compra, debe existir la orden para poder realizar una orden de compra (revisar) se le asigna un proveedor y un usuario que la aprueba 
        {
            _unOrdencompra.ID = 3;
            _unOrdencompra.Proveedor = new Proveedor();
            _unOrdencompra.Proveedor.ID = 3;
            _unOrdencompra.UsuarioAprobador = new Usuario();
            _unOrdencompra.UsuarioAprobador.ID = 1;
            Assert.AreEqual(NordenCompra.NuevaOrden(_unOrdencompra), true);
        }
        [TestMethod]
        public void AprobarOrden()// metodo para aprobar orden de compra, se puede enlazar con ordenes pendientes para que tenga mas sentido 
        {
            int idOrden = 1;
            int Aprobador = 1;
            Assert.AreEqual(NordenCompra.AprobarOrden(idOrden, Aprobador), true);
        }

        [TestMethod]
        public void ListarOrdenesPendientes()// devuelve un datatable con las ordenes que no esten habilitadas 
        {
            Assert.IsNotNull(NordenCompra.RecuperarOrdenPendiente());
        }
        [TestMethod]
        public void ListarOrdenes()// devuelve las ordenes habilitadas 
        {
            Assert.IsNotNull(NordenCompra.RecuperarOrdenCompra());
        }
        [TestMethod]
        public void PruebaSuma()// sirve para sumar el precio total de una orden de compra solo se le tiene que pasar el id de la orden 
        {
            int idOrden = 1;
            Assert.AreEqual(NordenCompra.RecuperarTotalCompra(idOrden),18000);
        }
    }
}
