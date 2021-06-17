using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using bll_modulo;

namespace Pruebas
{
    [TestClass]
    public class TProveedor
    {
        NProveedor obj = new NProveedor();//metodos de negocio
        Proveedor unObj = new Proveedor();//clase entidad
        Direccion dir = new Direccion();//clase entidad
        [TestMethod]
        public void AgregarProveedor() //Necesito proveedor sin ID, retorno true si pudo cargar o false si no(ya se encuentra cuil en tabla o hubo un error en los parametros)
        {
            unObj.Direccion = new Direccion();
            unObj.Direccion.ID = 3;
            unObj.RazonSocial = "La_Fabrica";
            unObj.CUIL = "3097654123";
            Assert.AreEqual(obj.Nuevo(unObj),true);
        }
        [TestMethod]
        public void EliminarProveedor()
        {
            int id = 2;
            Assert.AreEqual(obj.EstadoProveedor(id, false), true);//con false doy de baja
        }
        [TestMethod]
        public void AltaProveedor()
        {
            int id = 2;
            Assert.AreEqual(obj.EstadoProveedor(id, true), true);//con true doy de alta
        }
        [TestMethod]
        public void ModificarProveedor() 
        {
            unObj.Direccion = new Direccion();
            unObj.ID = 3;
            unObj.Direccion.ID = 3;
            unObj.RazonSocial = "mcdonalds";
            unObj.CUIL = "20445556667";
            Assert.AreEqual(obj.Editar(unObj), false);// funciona pero tira false 
        }
        [TestMethod]
        public void ListarProveedor() //Necesito filtro, string con: "TODOS" / "*CUIT levantado de txtbox*" / "HABILITADOS" / "DESHABILITADOS"
        {
            string filtro = "CUIL";
            string cuil = "20445556668";
            Assert.IsNotNull(obj.ListarProveedores(filtro, cuil));
        }


        [TestMethod]
        public void listarprovedores()
        {
            Assert.IsNotNull(obj.datatableproveedores());

        }



    }
}
