using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class TStock
    {
        NStock newstock = new NStock();
        Stock unstock = new Stock();
        Producto unproducto = new Producto();
        NDeposito undeposito = new NDeposito();
        [TestMethod]
        public void Agregarunproducto()//agrega un producto ya existente al stock, el producto debe existir para luego agregarlo al stock 
        {
            unproducto.ID = 39;
            unstock.Producto = unproducto;
            unstock.Cantidad = 10;
            Assert.AreEqual(newstock.CargarProductoEnStock(unstock), true);

        }
        [TestMethod]
        public void EditarStock()
        {
            unproducto.ID = 2;
            unstock.Producto = unproducto;
            unstock.ID = 1;
            Assert.AreEqual(newstock.EditarStock(unstock), true);

        }

        [TestMethod]
        public void SumarStock()// le paso un id_producto y la cantidad para sumar el stock relacionado a ese producto 
        {
            Assert.AreEqual(newstock.AgregarStock(39, 20), true);
        }
        [TestMethod]
        public void QuitarStock()// le paso un id_producto y la cantidad para restar el stock relacionado a ese producto 
        {
            Assert.AreEqual(newstock.RestarStock(39, 4), true);
        }
        [TestMethod]
        public void EliminarProductoDeStock()//
        {
            Assert.AreEqual(newstock.EliminarStock(32), true);
        }

        [TestMethod]
        public void ListaStockVista()
        {
            Assert.IsNotNull(newstock.ListarStockVista());
        }
        [TestMethod]
        public void quitardedeposito()
        {
            OrdenDeCompra unaorden = new OrdenDeCompra();
            unaorden.ID = 2;
            Assert.AreEqual(undeposito.QuitarDeDeposito(unaorden),true);
        }
        [TestMethod]
        public void agregardeposito()// necesita el id de una orden de compra
        {
            OrdenDeCompra unaorden = new OrdenDeCompra();
            unaorden.ID = 2;
            Assert.AreEqual(undeposito.agregaradeposito(unaorden), true);
        }

    }
}
