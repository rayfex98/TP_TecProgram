using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PruebasUnitarias
{
    [TestClass]
    public class TCategoria
    {
        Categoria unObj = new Categoria();
        NCategoria bll = new NCategoria();
        [TestMethod]
        public void _1Insert()//ingresa una categoria /no debe estar repetida 
        {
            string nombre = "Nueva";
            Assert.AreEqual(bll.AgregarCategoria(nombre), true);
            //Reviso insert
            bll.CargarLista();
            List<Categoria> lista = new List<Categoria>();
            lista = bll.RecuperarCategoria();
            bool prueba = lista.Exists(x => x.Nombre == nombre);
            Assert.AreEqual(prueba, true);
        }

        [TestMethod]
        public void _2Editar()//edita una categoria utilizando el id para buscarla 
        {

            unObj.Nombre = "Editada";
            unObj.ID = 13;
            Assert.AreEqual(bll.EditarCategoria(unObj), true);
            bll.CargarLista();
            List<Categoria> lista = new List<Categoria>();
            lista = bll.RecuperarCategoria();
            Assert.AreEqual(lista.Exists(x => x.Nombre == unObj.Nombre),true);
        }
        [TestMethod]
        public void _3Borrado() // desbahilita la categoria 
        {
            int id = 5;
            Assert.AreEqual(bll.EliminarCategoria(id), true);
            bll.CargarLista();
            List<Categoria> lista = new List<Categoria>();
            lista = bll.RecuperarCategoria(); //recupera habilitados
            Assert.AreEqual(lista.Exists(x => x.Nombre == "Editada"), false);
        }
        [TestMethod]
        public void Listado()//lista las categorias habilitadas 
        {
            bll.CargarLista();
            Assert.IsNotNull(bll.RecuperarCategoria());
        }
    }
}
