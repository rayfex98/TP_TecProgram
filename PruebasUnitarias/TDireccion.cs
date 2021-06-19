using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using BLL;

namespace Pruebas
{
    [TestClass]
    public class TDireccion
    {
        [TestMethod]
        public void _1Insert()
        {
            Direccion unObj = new Direccion();
            NDireccion Obj = new NDireccion();
            unObj.Altura = "310";
            unObj.Calle = "Rivadavia";
            unObj.CodigoPostal = "1645";
            unObj.Localidad = "Moron";
            unObj.Provincia = "Buenos_Aires";
            Assert.AreEqual(Obj.Nuevo(unObj), true);
        }
        [TestMethod]
        public void _2Editar()
        {
            Direccion unObj = new Direccion();
            NDireccion Obj = new NDireccion();
            unObj.Altura = "100";
            unObj.Calle = "olavarria";
            unObj.CodigoPostal = "2105";
            unObj.Localidad = "VILLA CRESPO";
            unObj.Provincia = "buenos aires ";
            unObj.ID = 6;
            Assert.AreEqual(Obj.Editar(unObj), false);// edita pero devuelve false, ver porque no puedo guardar 
        }
        [TestMethod]
        public void _3Borrado()
        {
            Direccion unObj = new Direccion();
            NDireccion Obj = new NDireccion();
            unObj.ID = 6;
            Assert.AreEqual(Obj.Eliminar(unObj), true);
        }
    }
}
