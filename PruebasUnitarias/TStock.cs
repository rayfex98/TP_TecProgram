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

        [TestMethod]
        public void Agregarunproducto()//agrega un producto ya existente al stock, el producto debe existir para luego agregarlo al stock 
        {
            unproducto.ID = 5;
            unstock.Producto = unproducto;
            unstock.Cantidad = 10;
            Assert.AreEqual(newstock.CargarProductoEnStock(unstock), false);

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
            Assert.AreEqual(newstock.AgregarStock(2, 20), true);
        }
        [TestMethod]
        public void QuitarStock()// le paso un id_producto y la cantidad para restar el stock relacionado a ese producto 
        {
            Assert.AreEqual(newstock.RestarStock(2, 4), true);
        }
        [TestMethod]
        public void EliminarProductoDeStock()//
        {
            Assert.AreEqual(newstock.EliminarStock(4), true);
        }

        [TestMethod]
        public void ListaStockVista()
        {
            Assert.IsNotNull(newstock.ListarStockVista());
        }
    }
}
