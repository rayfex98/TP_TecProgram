using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using bll_modulo;

namespace Pruebas
{
    [TestClass]
    public class TProducto
    {
        [TestMethod]
        public void _1Insert()
        {
            Producto unObj = new Producto();
            NProducto Obj = new NProducto();
            unObj.Nombre = "cereal";
            Assert.AreEqual(Obj.NuevoProducto(unObj), true);
            unObj.Nombre = "hogar";
            Assert.AreEqual(Obj.NuevoProducto(unObj), true);
            unObj.Nombre = "vinos";
            Assert.AreEqual(Obj.NuevoProducto(unObj), true);
            Assert.AreEqual(Obj.NuevoProducto(unObj), false); //no vuelve a agregar si tiene el mismo nombre
        }
        [TestMethod]
        public void _2Editar()
        {
            Producto unObj = new Producto();
            NProducto Obj = new NProducto();
            unObj.Nombre = "electro";
            unObj.ID = 2;
            Assert.AreEqual(Obj.EditarProducto (unObj), true);
        }
        [TestMethod]
        public void _3Borrado()
        {
            Producto unObj = new Producto();
            NProducto Obj = new NProducto();
            unObj.ID = 2;
            Assert.AreEqual(Obj.EditarProducto(unObj), true);
        }
    }
}
