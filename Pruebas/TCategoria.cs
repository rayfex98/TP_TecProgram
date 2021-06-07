using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using bll_modulo;
using System;

namespace Pruebas
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
            Assert.AreEqual(Obj.Nuevo(unObj), true);
            unObj.Nombre = "hogar";
            Assert.AreEqual(Obj.Nuevo(unObj), true);
            unObj.Nombre = "vinos";
            Assert.AreEqual(Obj.Nuevo(unObj), true);
        }
        [TestMethod]
        public void _2Editar()
        {
            Categoria unObj = new Categoria();
            NCategoria Obj = new NCategoria();
            unObj.Nombre = "electro";
            unObj.ID = 2;
            Assert.AreEqual(Obj.Editar(unObj), true);
        }
        [TestMethod]
        public void _3Borrado()
        {
            Categoria unObj = new Categoria();
            NCategoria Obj = new NCategoria();
            unObj.ID = 2;
            Assert.AreEqual(Obj.Eliminar(unObj), true);
        }    
    }
}
