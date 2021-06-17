using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using bll_modulo;
using System;

namespace Pruebas
{
    [TestClass]
    public class TDetallePENDIENTE
    {
        DetalleOrden detalle = new DetalleOrden();
        NDetalleOrden ndetalle = new NDetalleOrden();
        [TestMethod]
        public void _1Insert()
        {
            detalle.Producto = new Producto();
            int idorden = 1;
            detalle.Cantidad = 10;
            detalle.Producto.ID = 3;

           
            Assert.AreEqual(ndetalle.Nuevo(detalle,idorden), true);
      
        }
        [TestMethod]
        public void _2Editar()
        {
            detalle.Producto = new Producto();
            int idorden = 1;
            detalle.ID = 1;
            detalle.Cantidad = 60;
            detalle.Producto.ID = 2;
            Assert.AreEqual(ndetalle.Editar(detalle,idorden), false);// da false pero actua sobre la base de datos 
        }
        [TestMethod]
        public void _3Borrado()
        {
            int idorden = 1;
            detalle.ID = 3;      
            Assert.AreEqual(ndetalle.Eliminar(detalle, idorden), true);
        }
    }
}
