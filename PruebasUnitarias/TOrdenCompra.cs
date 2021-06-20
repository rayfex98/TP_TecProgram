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
        public void _1Insert()
        {
            _unOrdencompra.ID = 3;
            _unOrdencompra.Proveedor = new Proveedor();
            _unOrdencompra.Proveedor.ID = 3;
            _unOrdencompra.UsuarioAprobador = new Usuario();
            _unOrdencompra.UsuarioAprobador.ID = 1;
            Assert.AreEqual(NordenCompra.NuevoOrden(_unOrdencompra), true);
        }
        [TestMethod]
        public void aprobarorden()
        {
            _unOrdencompra.ID = 1;         
            Assert.AreEqual(NordenCompra.aprobarorden(_unOrdencompra), true);
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
        [TestMethod]
        public void pruebaSuma()
        {
            _unOrdencompra.ID = 1;
            Assert.AreEqual(NordenCompra.CalcularTotalOrden(_unOrdencompra),18000);
        }
    }
}
