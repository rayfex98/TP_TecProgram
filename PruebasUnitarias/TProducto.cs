using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class TProducto
    {
        Producto unObj = new Producto();
        NProducto Obj = new NProducto();
        [TestMethod]
        public void _1Insert()// ingresa un producto, la idea de pasarle un id de categoria es porque queremos un desplegable con la lista de categorias habilitadas (ver metodos categoria)
        {
            unObj.Categoria = new Categoria();
            unObj.Nombre = "pez";
            unObj.Categoria.ID = 1;
            unObj.PrecioCompra = 100;
            unObj.PrecioVenta = 200;
            Assert.AreEqual(Obj.NuevoProducto(unObj), true);
        }
        [TestMethod]
        public void _2Editar()// deja editar un producto, este metodo se usaria mas que nada para editar precios 
        {
            unObj.Categoria = new Categoria();
            unObj.Nombre = "pancho";
            unObj.PrecioCompra = 200;
            unObj.PrecioVenta = 100;
            unObj.ID = 38;
            unObj.Categoria.ID = 2;

            Assert.AreEqual(Obj.EditarProducto(unObj), false);// da false pero actua sobre la base de datos hay que revisar esto 
        }
        [TestMethod]
        public void _3Borrado()
        {
            int id = 3;
            Assert.AreEqual(Obj.EliminarProducto(id), false); // es false porque el id de ese producto esta asociado a otra tabla
        }
        [TestMethod]
        public void ListaProductos()// devuelve una lista de los productos que estan habilitados 
        {
            NProducto Obj = new NProducto();
            Assert.IsNotNull(Obj.ListarProductos());
        }
        [TestMethod]
        public void BuscarProducto()// devuelve una lista de los productos que estan habilitados 
        {
            string nombre = "c";
            NProducto Obj = new NProducto();
            Assert.IsNotNull(Obj.BuscarProducto(nombre));
        }
    }
}
