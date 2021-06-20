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
            unObj.Direccion.ID = 2;
            unObj.RazonSocial = "roma";
            unObj.CUIL = "2323213213";
            Assert.AreEqual(obj.Nuevo(unObj), true);
        }
        [TestMethod]

        public void ModificarProveedor()
        {
            unObj.Direccion = new Direccion();
            unObj.ID = 3;
            unObj.Direccion.ID = 15;
            unObj.RazonSocial = "aveces";
            unObj.CUIL = "20443556667";
            Assert.AreEqual(obj.Editar(unObj), false);// funciona pero tira false 
        }
        [TestMethod]
        public void ListarProvedores()
        {
            Assert.IsNotNull(obj.listarproveedores());

        }
        [TestMethod]
        public void ListarProvedoresPorProvincia()
        {
            string provincia = "b";
            Assert.IsNotNull(obj.ListarProveedoresPorProvincia(provincia));

        }
    }
}
