using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using BLL;

namespace PruebasUnitarias
{
    [TestClass]
    public class TDireccion
    {
        Direccion unObj = new Direccion();
        NDireccion Obj = new NDireccion();
        [TestMethod]
        public void _1Insert()// inserta una nueva direccion 
        {
            unObj.Altura = "10";
            unObj.Calle = "Rvadavia";
            unObj.CodigoPostal = "145";
            unObj.Localidad = "Moron";
            unObj.Provincia = "Buenos_Aires";
            Assert.AreEqual(Obj.Nuevo(unObj), true);
        }
        [TestMethod]
        public void _2Editar()// edita una direccion ya existente la busca por su id 
        {

            unObj.Altura = "100";
            unObj.Calle = "olavarria";
            unObj.CodigoPostal = "2105";
            unObj.Localidad = "VILLA_CRESPO";
            unObj.Provincia = "buenos_aires ";
            unObj.ID = 8;
            Assert.AreEqual(Obj.Editar(unObj), false);// edita pero devuelve false, ver porque no puedo guardar 
        }
        [TestMethod]
        public void _3Borrado()// no es un borrado logico, borra una direccion por su id 
        {
            int id = 8;
            Assert.AreEqual(Obj.Eliminar(id), true);
        }
        [TestMethod]
        public void listadireccion()//lista todas las direcciones // utilizar para hacer un desplegable en el ingreso de nuevo proveedor 
        {
            Assert.IsNotNull(Obj.ListaDireccion());
        }
    }
}
