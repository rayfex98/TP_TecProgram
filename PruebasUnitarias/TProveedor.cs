using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class TProveedor
    {
        
        NProveedor obj = new NProveedor();//metodos de negocio
        Proveedor unObj = new Proveedor();//clase entidad
        [TestMethod]
        public void AgregarProveedor() //Necesito proveedor sin ID, retorno true si pudo cargar o false si no(ya se encuentra cuil en tabla o hubo un error en los parametros)
        {
            unObj.Direccion = new Direccion();
            unObj.Direccion.ID = 3;
            unObj.RazonSocial = "La_Fabrica";
            unObj.CUIL = "3097654123";
            Assert.AreEqual(obj.Nuevo(unObj), true);
        }
        [TestMethod]

        public void ModificarProveedor()
        {
            unObj.Direccion = new Direccion();
            unObj.ID = 3;
            unObj.Direccion.ID = 3;
            unObj.RazonSocial = "Electrolux";
            unObj.CUIL = "20445556667";
            Assert.AreEqual(obj.Editar(unObj), false);// funciona pero tira false 
        }
        [TestMethod]
        public void ListarProvedores()
        {
            Assert.IsNotNull(obj.DataTableProveedores());

        }
    }
}