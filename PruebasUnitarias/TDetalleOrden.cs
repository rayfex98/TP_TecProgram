using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class TDetalleOrden
    {
        DetalleOrden detalle = new DetalleOrden();
        NDetalleOrden ndetalle = new NDetalleOrden();
        [TestMethod]
        public void _1Insert()
        {
            detalle.Producto = new Producto();
            int idorden = 2;
            detalle.Cantidad = 20;
            detalle.Producto.ID = 2;


            Assert.AreEqual(ndetalle.Nuevo(detalle, idorden), true);

        }
        [TestMethod]
        public void _2Editar()
        {
            detalle.Producto = new Producto();
            int idorden = 2;
            detalle.ID = 12;
            detalle.Cantidad = 60;
            detalle.Producto.ID = 4;
            Assert.AreEqual(ndetalle.Editar(detalle, idorden), false);
        }
        [TestMethod]
        public void _3Borrado()
        {
            int idorden = 1;
            detalle.ID = 9;
            Assert.AreEqual(ndetalle.Eliminar(detalle, idorden), true);
        }
        [TestMethod]
        public void ListarDetall()
        {

            Assert.IsNotNull(ndetalle.ListarDetalleOrden());
        }
    }
}
