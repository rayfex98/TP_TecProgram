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
            string nombre;
            nombre = "celulares";
            Assert.AreEqual(Obj.AgregarCategoria(nombre), true);
            unObj.Nombre = "mascotas";
            Assert.AreEqual(Obj.AgregarCategoria(nombre), true);
            unObj.Nombre = "cereales";
            Assert.AreEqual(Obj.AgregarCategoria(nombre), true);
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
            int id = 3;
            Assert.AreEqual(Obj.EliminarCategoria(id), true);
        }
        [TestMethod]
        public void Listado()//lista las categorias habilitadas 
        {
            Assert.IsNotNull(Obj.RecuperarCategoria());
        }
    }
}
