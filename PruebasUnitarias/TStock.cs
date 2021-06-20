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

        //agrega un producto ya existente al stock, el producto debe existir para luego agregarlo al stock 
        //la idea de este metodo es usarlo cuando se crea un nuevo producto por primera vez dentro de stock 
        [TestMethod]
        public void Agregarunproducto()
        {
            unproducto.ID = 39;
            unstock.Producto = unproducto;
            unstock.Cantidad = 10;
            Assert.AreEqual(newstock.CargarProductoEnStock(unstock), true);

        }
        //este metodo sirve para cambiar el producto dentro de stock usando el id de stock para encontrarlo 
        [TestMethod]
        public void EditarStock()
        {
            unproducto.ID = 2;
            unstock.Producto = unproducto;
            unstock.ID = 1;
            Assert.AreEqual(newstock.EditarStock(unstock), true);

        }

        [TestMethod]
        public void SumarStock()// le paso un id_producto y la cantidad para sumar el stock relacionado a ese producto se utiliza para realizar orden de compra
        {
            Assert.AreEqual(newstock.AgregarStock(39, 20), true);
        }
        [TestMethod]
        public void QuitarStock()// le paso un id_producto y la cantidad para restar el stock relacionado a ese producto se utiliza para realizar orden de venta
        {
            Assert.AreEqual(newstock.RestarStock(39, 4), true);
        }
        [TestMethod]
        public void EliminarProductoDeStock()//elimina de forma logica un producto de la bdd deshabilitando el producto de stock 
        {
            Assert.AreEqual(newstock.EliminarStock(32), true);
        }
        //Este metodo sirve para listar todos los productos dentro de deposito 
        [TestMethod]
        public void ListaStockVista()//muestra los productos habilitados dentro de stock 
        {
            Assert.IsNotNull(newstock.ListarStockVista());
        }
        [TestMethod]
        //este metodo se utilizaria para quitar productos que se vendieron del stock 
        //deberia usarse luego de realizarse una venta 
        public void quitardedeposito()
        {
            OrdenDeCompra unaorden = new OrdenDeCompra();
            unaorden.ID = 2;
            Assert.AreEqual(undeposito.QuitarDeDeposito(unaorden),true);
        }
        [TestMethod]
        // Necesita el id de una orden de compra// este metodo sirve para agregar en el deposito los productos de el detalle orden utiliza id orden
        // para poder ingresar el producto con el id asociado y su cantidad, este metodo deberia ejecutarse luego de que la orden se realizo 
        public void agregardeposito()
        {
            OrdenDeCompra unaorden = new OrdenDeCompra();
            unaorden.ID = 2;
            Assert.AreEqual(undeposito.agregaradeposito(unaorden), true);
        }
        [TestMethod]
        //devuelve una lista de los productos dentro de deposito que esten habilitados 
        public void Listadeposito()
        {
            Assert.IsNotNull(undeposito.ListarDeposito());
        }



    }
}
