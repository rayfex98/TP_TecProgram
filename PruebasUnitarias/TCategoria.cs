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
        public void _1Insert()//ingresa una categoria /no debe estar repetida 
        {

            unObj.Nombre = "celulares";
            Assert.AreEqual(Obj.AgregarCategoria(unObj), true);
            unObj.Nombre = "perros";
            Assert.AreEqual(Obj.AgregarCategoria(unObj), true);
            unObj.Nombre = "ninjas";
            Assert.AreEqual(Obj.AgregarCategoria(unObj), true);
        }
        [TestMethod]
        public void _2Editar()//edita una categoria utilizando el id para buscarla 
        {

            unObj.Nombre = "electro";
            unObj.ID = 5;
            Assert.AreEqual(Obj.EditarCategoria(unObj), true);
        }
        [TestMethod]
        public void _3Borrado() // desbahilita la categoria 
        {
            unObj.ID = 3;
            Assert.AreEqual(Obj.EliminarCategoria(unObj), true);
        }
        [TestMethod]
        public void Listado()//lista las categorias habilitadas 
        {
            Assert.IsNotNull(Obj.ListarCategoria());
        }
        [TestMethod]
        public void ListadoPorCategoria()//lista por descripcion / se puede utilizar para cuando ingresa un producto 
        {
            string Nombre = "d";
            Assert.IsNotNull(Obj.ListadeCategoriaPorCategoria(Nombre));
        }

    }
}
