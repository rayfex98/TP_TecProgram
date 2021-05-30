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
            Categoria unCat = new Categoria();
            NCategoria Cat = new NCategoria();
            unCat.Nombre = "cereal";
            Assert.AreEqual(Cat.Nuevo(unCat), true);
            unCat.Nombre = "hogar";
            Assert.AreEqual(Cat.Nuevo(unCat), true);
            unCat.Nombre = "vinos";
            Assert.AreEqual(Cat.Nuevo(unCat), true);
            Assert.AreEqual(Cat.Nuevo(unCat), false); //no vuelve a agregar si tiene el mismo nombre
        }
        [TestMethod]
        public void _2Editar()
        {
            Categoria unCat = new Categoria();
            NCategoria Cat = new NCategoria();
            unCat.Nombre = "electro";
            unCat.ID = 2;
            Assert.AreEqual(Cat.Editar(unCat), true);
        }
        [TestMethod]
        public void _3Borrado()
        {
            NCategoria Cat = new NCategoria();
            int id = 2;
            Assert.AreEqual(Cat.Eliminar(id), true);
        }    
    }
}
