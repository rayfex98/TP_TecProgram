using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using bll_modulo;
using Entidades;
using System.Collections.Generic;

namespace Pruebas
{
    [TestClass]
    public class TOrdenCompra
    {
        OrdenDeCompra ordencompra = new OrdenDeCompra();
        DetalleOrden Detalle = new DetalleOrden();
        NOrdenCompra NordenCompra = new NOrdenCompra();
        [TestMethod]
        public void _1Insert()
        {
            ordencompra.Proveedor = new Proveedor();
            ordencompra.Proveedor.ID = 1;
            ordencompra.UsuarioAprobador = new Usuario();
            ordencompra.UsuarioAprobador.ID = 1;      
                Assert.AreEqual(NordenCompra.NuevoOrden(ordencompra), true);
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
