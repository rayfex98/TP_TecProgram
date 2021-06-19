using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    class TOrdenCompra
    {
        OrdenDeCompra _unOrdencompra = new OrdenDeCompra();
        DetalleOrden _unDetalle = new DetalleOrden();
        NOrdenCompra NordenCompra = new NOrdenCompra();
        [TestMethod]
        public void _1Insert()
        {
            _unOrdencompra.Proveedor = new Proveedor();
            _unOrdencompra.Proveedor.ID = 1;
            _unOrdencompra.UsuarioAprobador = new Usuario();
            _unOrdencompra.UsuarioAprobador.ID = 1;
            Assert.AreEqual(NordenCompra.NuevoOrden(_unOrdencompra), true);
        }

        [TestMethod]
        public void ListarOrdenesPendientes()
        {
            Assert.IsNotNull(NordenCompra.OrdenPendiente());
        }
        [TestMethod]
        public void ListarOrdenes()
        {
            Assert.IsNotNull(NordenCompra.ListarOrdenCompra());
        }
    }
}
