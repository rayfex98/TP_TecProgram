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
            dir.Altura = "1245";
            dir.Calle = "San Martin";
            dir.CodigoPostal = "1642";
            dir.Localidad = "Quilmes";
            dir.Provincia = "Buenos Aires";
            unObj.Direccion = dir;
            unObj.RazonSocial = "La Fabrica";
            unObj.CUIL = "3097654123";
            Assert.AreEqual(obj.AltaProveedor(unObj),true);
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
        public void ModificarProveedor() //Necesito ID a buscar y los campos a modificar con sus datos o con NULL
        {
            int id = 1;
            dir.Altura = "1345";
            dir.Calle = "Belgrano";
            dir.CodigoPostal = "";
            dir.Localidad = "";
            dir.Provincia = "";
            unObj.Direccion = dir;
            unObj.RazonSocial = "La Anonima";
            unObj.CUIL = "20445556668";
            Assert.AreEqual(obj.ModificarProveedor(id, unObj), true);
        }
        [TestMethod]
        public void ListarProveedor() //Necesito filtro, string con: "TODOS" / "*CUIT levantado de txtbox*" / "HABILITADOS" / "DESHABILITADOS"
        {
            string filtro = "20445556668";
            Assert.IsNotNull(obj.ListarProveedores(filtro));
        }
    }
}
