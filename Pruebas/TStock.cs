using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using bll_modulo;

namespace Pruebas
{
    [TestClass]
    public class TStock
    {
        NStock newstock = new NStock();
        Stock unstock = new Stock();
        Producto unproducto = new Producto();
        Categoria unacategoria = new Categoria();

        [TestMethod]
        public void Agregarunproducto()//agrega un producto ya existente al stock, el producto debe existir para luego agregarlo al stock 
        {
            unproducto.ID = 4;
            unstock.Producto = unproducto;
            unstock.Cantidad = 10;
            Assert.AreEqual(newstock.Nuevo(unstock), true);

        }
        [TestMethod]
        public void EditarStock()
        {
            unproducto.ID = 4;
            unstock.Producto = unproducto;
            unstock.ID = 15;
            Assert.AreEqual(newstock.Editar(unstock), true);

        }

        [TestMethod]
        public void SumarStock()// le paso un id_producto y la cantidad para sumar el stock relacionado a ese producto 
        {
            Assert.AreEqual(newstock.AgregarStock(2, 2), true);
        }
        [TestMethod]
        public void QuitarStock()// le paso un id_producto y la cantidad para restar el stock relacionado a ese producto 
        {
            Assert.AreEqual(newstock.AgregarStock(2, 4), true);
        }
        [TestMethod]
        public void EliminarProductoDeStock()//
        {
            Assert.AreEqual(newstock.Eliminar(4), true);
        }

        [TestMethod]
        public void ListaStock()
        {
            Assert.IsNotNull(newstock.ListaStock());
        }

    }
}
