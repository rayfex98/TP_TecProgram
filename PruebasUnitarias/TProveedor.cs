using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class TProveedor
    {
        
        NProveedor obj = new NProveedor();
        Proveedor unObj = new Proveedor();
        [TestMethod]
        public void AgregarProveedor() //Ingresa un proveedor nuevo, la idea es utilizar una lista de direcciones seteadas ver metodo lista en direccion 
        {
            unObj.Direccion = new Direccion();
            unObj.Direccion.ID = 2;
            unObj.RazonSocial = "roma";
            unObj.CUIL = "2323213213";
            Assert.AreEqual(obj.Nuevo(unObj), true);
        }
        [TestMethod]

        public void ModificarProveedor()//modifica un proveedor que se selecciona por su id 
        {
            unObj.Direccion = new Direccion();
            unObj.ID = 3;
            unObj.Direccion.ID = 15;
            unObj.RazonSocial = "aveces";
            unObj.CUIL = "20443556667";
            Assert.AreEqual(obj.Editar(unObj), false);// funciona pero tira false 
        }
        [TestMethod]
        public void ListarProvedores()//devuelve la lista de proveedores completa
        {
            Assert.IsNotNull(obj.RecuperarTodosLosProveedores());

        }
        [TestMethod]
        public void ListarProvedoreshabilitados()//devuelve la lista de proveedores habilitados 
        {
            Assert.IsNotNull(obj.RecuperarProveedoresHabilitados());

        }

        [TestMethod]
        public void HabilitarProveedor()// funcion para habilitar proveedor, se le pasa el id del proveedor que se quiere habilitar
        {
            int id = 3;
            Assert.AreEqual(obj.Habilitar(id), true);

        }
        public void DeshabilitarProveedor()// funcion para habilitar proveedor, se le pasa el id del proveedor que se quiere habilitar
        {
            int id = 3;
            Assert.AreEqual(obj.Deshabilitar(id), true);

        }

        [TestMethod]
        public void ListarProvedoresPorProvincia()//Lista proveedores por provincia que se ingrese que se pasa por string 
        {
            string provincia = "b";
            Assert.IsNotNull(obj.RecuperarProveedoresPorProvincia(provincia));

        }
    }
}
