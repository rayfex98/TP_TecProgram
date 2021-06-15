using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using bll_modulo;

namespace Pruebas
{
    [TestClass]
    public class TProducto
    {
         Producto unObj = new Producto();
         NProducto Obj = new NProducto();
        [TestMethod]
        public void _1Insert()
        {
            unObj.Categoria = new Categoria();
            unObj.Nombre = "lavavajilla";
            unObj.Categoria.ID = 1;
            unObj.PrecioCompra = 100;
            unObj.PrecioVenta = 200;
            Assert.AreEqual(Obj.NuevoProducto(unObj), true);
            unObj.Nombre = "coches";
            unObj.Categoria.ID =1;
            unObj.PrecioCompra = 100;
            unObj.PrecioVenta = 200;
            Assert.AreEqual(Obj.NuevoProducto(unObj), true);
            unObj.Nombre = "VINOS";
            unObj.Categoria.ID =1;
            unObj.PrecioCompra = 100;
            unObj.PrecioVenta = 200;
            Assert.AreEqual(Obj.NuevoProducto(unObj), true);
            Assert.AreEqual(Obj.NuevoProducto(unObj), false); //no vuelve a agregar si tiene el mismo nombre
        }
        [TestMethod]
        public void _2Editar()
        {
            unObj.ID = 9;
            unObj.Nombre = "electro";
            unObj.Categoria = new Categoria();
            unObj.Categoria.ID = 2;
            unObj.PrecioCompra = 200;
            unObj.PrecioVenta = 300;
            Assert.AreEqual(Obj.EditarProducto(unObj), false);
            unObj.ID = 8;
            unObj.Nombre = "libro";
            unObj.Categoria = new Categoria();
            unObj.Categoria.ID = 3;
            unObj.PrecioCompra = 200;
            unObj.PrecioVenta = 300;
            Assert.AreEqual(Obj.EditarProducto(unObj), true);
        }
        [TestMethod]
        public void _3Borrado()
        {

            unObj.ID = 2;
            Assert.AreEqual(Obj.EliminarProducto(unObj), true);
        }
        [TestMethod]
        public void ListaProductos()
        {
            NProducto Obj = new NProducto();
            Assert.IsNotNull(Obj.ListarProductos());
        }
    }
}
