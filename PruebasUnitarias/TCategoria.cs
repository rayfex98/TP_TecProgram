using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class TCategoria
    {
        [TestMethod]
        public void _1Insert()
        {
            Categoria unObj = new Categoria();
            NCategoria Obj = new NCategoria();
            unObj.Nombre = "cereal";
            Assert.AreEqual(Obj.AgregarCategoria(unObj), false);
            unObj.Nombre = "hogar";
            Assert.AreEqual(Obj.AgregarCategoria(unObj), false);
            unObj.Nombre = "vinos";
            Assert.AreEqual(Obj.AgregarCategoria(unObj), false);
        }
        [TestMethod]
        public void _2Editar()
        {
            Categoria unObj = new Categoria();
            NCategoria Obj = new NCategoria();
            unObj.Nombre = "electro";
            unObj.ID = 5;
            Assert.AreEqual(Obj.EditarCategoria(unObj), true);
        }
        [TestMethod]
        public void _3Borrado() //FACU: deberia utilizar borrado logico en vez de fisico
        {
            Categoria unObj = new Categoria();
            NCategoria Obj = new NCategoria();
            unObj.ID = 2;
            Assert.AreEqual(Obj.EliminarCategoria(unObj), false); // va a tirar una excepcion porque hay productos que usan esta categoria 
        }
    }
}
