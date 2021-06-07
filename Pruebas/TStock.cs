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
        public void Agregarunproducto()
        {
            unproducto.Nombre = "Heladera";
            unproducto.PrecioCompra = 100;
            unproducto.PrecioVenta = 200;
            unacategoria.Nombre = "Electrodomestico";
            unproducto.Categoria = unacategoria;
            unstock.Producto = unproducto;
            unstock.Cantidad = 10;
            Assert.AreEqual(newstock.Nuevo(unstock), true);

        }
    }
}
