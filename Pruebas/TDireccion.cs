using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using bll_modulo;
using System;

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
            unObj.Provincia = "Buenos Aires";
            Assert.AreEqual(Obj.Nuevo(unObj), true);
            unObj.Altura = "4654";
            unObj.Calle = "Nazca";
            unObj.CodigoPostal = "1405";
            unObj.Localidad = "Flores";
            unObj.Provincia = "Buenos Aires";
            Assert.AreEqual(Obj.Nuevo(unObj), true);
            unObj.Altura = "243";
            unObj.Calle = "Bahia Blanca";
            unObj.CodigoPostal = "X5172AIE";
            unObj.Localidad = "La Falda";
            unObj.Provincia = "Cordoba";
            Assert.AreEqual(Obj.Nuevo(unObj), true);
            Assert.AreEqual(Obj.Nuevo(unObj), false); //no vuelve a agregar si tiene el mismo nombre
        }
        [TestMethod]
        public void _2Editar()
        {
            Direccion unObj = new Direccion();
            NDireccion Obj = new NDireccion();
            unObj.Altura = "NULL";
            unObj.Calle = "NULL";
            unObj.CodigoPostal = "2105";
            unObj.Localidad = "VILLA CRESPO";
            unObj.Provincia = "NULL";
            unObj.ID = 2;
            Assert.AreEqual(Obj.Editar(unObj), true);
        }
        [TestMethod]
        public void _3Borrado()
        {
            Direccion unObj = new Direccion();
            NDireccion Obj = new NDireccion();
            unObj.ID = 3;
            Assert.AreEqual(Obj.Eliminar(unObj), true);
        }
    }
}
