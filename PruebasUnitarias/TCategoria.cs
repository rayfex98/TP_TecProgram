using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class TCategoria
    {
        Categoria unObj = new Categoria();
        NCategoria Obj = new NCategoria();
        [TestMethod]
        public void _1Insert()
        {

            unObj.Nombre = "celulares";
            Assert.AreEqual(Obj.AgregarCategoria(unObj), true);
            unObj.Nombre = "perros";
            Assert.AreEqual(Obj.AgregarCategoria(unObj), true);
            unObj.Nombre = "ninjas";
            Assert.AreEqual(Obj.AgregarCategoria(unObj), true);
        }
        [TestMethod]
        public void _2Editar()
        {

            unObj.Nombre = "electro";
            unObj.ID = 5;
            Assert.AreEqual(Obj.EditarCategoria(unObj), true);
        }
        [TestMethod]
        public void _3Borrado() //FACU: deberia utilizar borrado logico en vez de fisico
        {

            unObj.ID = 2;
            Assert.AreEqual(Obj.EliminarCategoria(unObj), true); // va a tirar una excepcion porque hay productos que usan esta categoria 
        }
        [TestMethod]
        public void Listado()
        {
            Assert.IsNotNull(Obj.ListarCategoria());
        }
        [TestMethod]
        public void ListadoPorCategoria()
        {
            string Nombre = "d";
            Assert.IsNotNull(Obj.ListadeCategoriaPorCategoria(Nombre));
        }

    }
}
