using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using bll_modulo;
using System.Data;

namespace Pruebas
{
    [TestClass]
    public class TAlerta
    {
        [TestMethod]
        public void _1Insert()
        {
            Alerta unCat = new Alerta();
            NAlerta Cat = new NAlerta();
            unCat.Stock.ID = 1;
            unCat.Stock.Producto.ID = 1;
            unCat.UsuarioCreador.ID = 1;
            Assert.AreEqual(Cat.Nuevo(unCat), true);
            unCat.Stock.ID = 2;
            unCat.UsuarioCreador.ID = 1;
            Assert.AreEqual(Cat.Nuevo(unCat), true);
            unCat.Stock.ID = 3;
            unCat.UsuarioCreador.ID = 2;
            Assert.AreEqual(Cat.Nuevo(unCat), true);
            Assert.AreEqual(Cat.Nuevo(unCat), false); //no vuelve a agregar si tiene el mismo nombre
        }
        [TestMethod]
        public void _2Editar()
        {
            Alerta unObj = new Alerta();
            NAlerta Obj = new NAlerta();
            unObj.Stock.ID = 1;
            unObj.UsuarioCreador.ID = 2;
            unObj.ID = 1;
            Assert.AreEqual(Obj.Editar(unObj), true);
        }
        [TestMethod]
        public void _3Borrado()
        {
            Alerta unObj = new Alerta();
            NAlerta Cat = new NAlerta();
            unObj.ID = 2;
            Assert.AreEqual(Cat.Eliminar(unObj), true);
        }
    }
}
