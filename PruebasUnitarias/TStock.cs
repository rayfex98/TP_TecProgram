using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PruebasUnitarias
{
    [TestClass]
    public class TStock
    {
        NStock newstock = new NStock();
        Stock unstock = new Stock();
        Producto unproducto = new Producto();
        NDeposito undeposito = new NDeposito();

        //agrega un producto ya existente al stock, el producto debe existir para luego agregarlo al stock 
        //la idea de este metodo es usarlo cuando se crea un nuevo producto por primera vez dentro de stock 
        [TestMethod]
        public void Agregarunproducto()
        {
            unproducto.ID = 13;
            unstock.Producto = unproducto;
            unstock.Cantidad = 10;
            Assert.AreEqual(newstock.CargarProductoEnStock(unstock), true);
            List<Stock> lista = new List<Stock>();
            lista = undeposito.RecuperarDeposito();
            bool prueba = lista.Exists(x => x.Producto.ID == unstock.Producto.ID && x.Cantidad == unstock.Cantidad);
            Assert.AreEqual(prueba, true);
        }
        //este metodo sirve para cambiar el producto dentro de stock usando el id de stock para encontrarlo 
        [TestMethod]
        public void EditarStock()
        {
            unstock.Cantidad = 14;
            unstock.Producto = unproducto;
            unstock.ID = 13;
            Assert.AreEqual(newstock.EditarStock(unstock), true);
            List<Stock> lista = new List<Stock>();
            lista = undeposito.RecuperarDeposito();
            bool prueba = lista.Exists(x => x.Producto.ID == unstock.ID && x.Cantidad == unstock.Cantidad);
            Assert.AreEqual(prueba, true);
        }

        [TestMethod]
        public void SumarStock()// le paso un id_producto y la cantidad para sumar el stock relacionado a ese producto se utiliza para realizar orden de compra
        {
            Assert.AreEqual(newstock.AgregarStock(10, 20), true);
            List<Stock> lista = new List<Stock>();
            lista = undeposito.RecuperarDeposito();
            bool prueba = lista.Exists(x => x.Producto.ID == 10 && x.Cantidad == 30);
            Assert.AreEqual(prueba, true);
        }
        [TestMethod]
        public void RestarStock()// le paso un id_producto y la cantidad para restar el stock relacionado a ese producto se utiliza para realizar orden de venta
        {
            int id = 10;
            Assert.AreEqual(newstock.RestarStock(id, 5), true);
        }
        [TestMethod]
        public void EliminarProductoDeStock()//elimina de forma logica un producto de la bdd deshabilitando el producto de stock 
        {
            int id = 11;
            Assert.AreEqual(newstock.EliminarStock(id), true);
        }
        [TestMethod]
        //este metodo se utilizaria para quitar productos que se vendieron del stock 
        //deberia usarse luego de realizarse una venta 
        public void Quitardedeposito()
        {
            int idOrden = 2;
            Assert.AreEqual(undeposito.QuitarDeDeposito(idOrden),true);
        }
        [TestMethod]
        // Necesita el id de una orden de compra// este metodo sirve para agregar en el deposito los productos de el detalle orden utiliza id orden
        // para poder ingresar el producto con el id asociado y su cantidad, este metodo deberia ejecutarse luego de que la orden se realizo 
        public void Agregardeposito()
        {
            int idOrden = 2;
            Assert.AreEqual(undeposito.AgregarADeposito(idOrden), true);
        }
        [TestMethod]
        //devuelve una lista de los productos dentro de deposito que esten habilitados 
        public void Listadeposito()
        {
            Assert.IsNotNull(undeposito.RecuperarDeposito());
        }



    }
}
