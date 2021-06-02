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
            dir.Altura = "";
            dir.Calle = "";
            dir.CodigoPostal = "";
            dir.Localidad = "";
            dir.Provincia = "";
            unObj.Direccion = dir;
            unObj.RazonSocial = "";
            unObj.CUIL = "";
            Assert.AreEqual(obj.AltaProveedor(unObj),true);
        }
        [TestMethod]
        public void EliminarProveedor()
        {
            int id = 2;
            Assert.AreEqual(obj.EstadoProveedor(id), true);
        }
        [TestMethod]
        public void ModificarProveedor() //Necesito ID a buscar y los campos a modificar con sus datos o con NULL
        {
            int id = 1;
            dir.Altura = "";
            dir.Calle = "";
            dir.CodigoPostal = "";
            dir.Localidad = "";
            dir.Provincia = "";
            unObj.Direccion = dir;
            unObj.RazonSocial = "";
            unObj.CUIL = "";
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
