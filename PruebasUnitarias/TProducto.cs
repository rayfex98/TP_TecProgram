using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    public class TProducto
    {
        Producto unObj = new Producto();
        NProducto Obj = new NProducto();
        [TestMethod]
        public void _1Insert()
        {
            unObj.Categoria = new Categoria();
            unObj.Nombre = "lavavajilla";
            unObj.Categoria.ID = 1;
            unObj.PrecioCompra = 100;
            unObj.PrecioVenta = 200;
            Assert.AreEqual(Obj.NuevoProducto(unObj), false);
            unObj.Nombre = "coches";
            unObj.Categoria.ID = 1;
            unObj.PrecioCompra = 100;
            unObj.PrecioVenta = 200;
            Assert.AreEqual(Obj.NuevoProducto(unObj), false);
            unObj.Nombre = "VINOS";
            unObj.Categoria.ID = 1;
            unObj.PrecioCompra = 100;
            unObj.PrecioVenta = 200;
            Assert.AreEqual(Obj.NuevoProducto(unObj), false);
            Assert.AreEqual(Obj.NuevoProducto(unObj), false); //no vuelve a agregar si tiene el mismo nombre
        }
        [TestMethod]
        public void _2Editar()
        {
            unObj.Categoria = new Categoria();
            unObj.Nombre = "heladera";
            unObj.PrecioCompra = 200;
            unObj.PrecioVenta = 100;
            unObj.ID = 9;
            unObj.Categoria.ID = 2;

            Assert.AreEqual(Obj.EditarProducto(unObj), false);// da false pero actua sobre la base de datos hay que revisar esto 
        }
        [TestMethod]
        public void _3Borrado()
        {
            unObj.ID = 2;
            Assert.AreEqual(Obj.EliminarProducto(unObj), false); // es false porque el id de ese producto esta asociado a otra tabla
        }
        [TestMethod]
        public void ListaProductos()
        {
            NProducto Obj = new NProducto();
            Assert.IsNotNull(Obj.ListarProductos());
        }
    }
}
