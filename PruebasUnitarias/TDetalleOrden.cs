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
        public void _1Insert()// se asocia a un id orden, necesita una cantidad y un id de producto // en la pantalla podria tener un desplegable de lista de prodcutos, y una cantidad para ingresar
        {
            detalle.Producto = new Producto();
            int idorden = 2;
            detalle.Cantidad = 20;
            detalle.Producto.ID = 2;


            Assert.AreEqual(ndetalle.Nuevo(detalle, idorden), true);

        }
        [TestMethod]
        public void _2Editar() // edita una orden de compra, pero se debe acceder al id de ese detalle, podria tener una lista de detalle y al seleccionar ese detalle editar esa row 
        {
            detalle.Producto = new Producto();
            int idorden = 2;
            detalle.ID = 12;
            detalle.Cantidad = 60;
            detalle.Producto.ID = 4;
            Assert.AreEqual(ndetalle.Editar(detalle, idorden), false);
        }
        [TestMethod]
        public void _3Borrado()// esta funcion borra un detalle de una orden/ no es un borrado logico 
        {
            int idorden = 1;
            detalle.ID = 9;
            Assert.AreEqual(ndetalle.Eliminar(detalle, idorden), true);
        }
        [TestMethod]
        public void ListarDetall()// lista todos los detalles 
        {
            int idorden = 1;
            Assert.IsNotNull(ndetalle.ListarDetalleOrden(idorden));
        }


    }
}
