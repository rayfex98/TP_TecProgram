using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using bll_modulo;
using Entidades;

namespace Pruebas
{
    [TestClass]
    public class TOrdenCompraPENDIENTE
    {
        OrdenDeCompra ordencompra = new OrdenDeCompra();
        DetalleOrden Detalle = new DetalleOrden();
        NOrdenCompra NordenCompra = new NOrdenCompra();
            [TestMethod]
            public void _1Insert()
            {
            Detalle.Producto = new Producto();
            Detalle.Cantidad = 10;
            Detalle.Producto.ID = 1;

                  ordencompra.Detalles.Add(Detalle);
            // no se como proseguir con esto, pensar como hacer para llamar a restar y saber si la orden esta aprobada 
                Assert.AreEqual(NordenCompra.NuevoOrden(ordencompra), true);
            }


        }
    
}
