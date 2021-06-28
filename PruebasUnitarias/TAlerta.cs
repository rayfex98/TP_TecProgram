using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class TAlerta
    {

        [TestMethod]
        public void NuevaAlerta()// crea una alerta nueva necesita un id de producto y una cantidad // y un usuario que la cree 
        {
            Alerta unaAlerta = new Alerta();
            NAlerta MetodoAlerta = new NAlerta();
            unaAlerta.Stock = new Stock();
            unaAlerta.Stock.Producto = new Producto();
            unaAlerta.UsuarioCreador = new Usuario();
            unaAlerta.UsuarioCreador.ID = 1;
            unaAlerta.CantidadMinima = 100;
            unaAlerta.Stock.ID = 1;
            Assert.AreEqual(MetodoAlerta.CrearAlerta(unaAlerta), true);//ya esta creada con este id
        }

        [TestMethod]
        public void EditarAler()// edita una alerta ya existente, y se renueva el usuario que la cambio 
        {
            Alerta unaAlerta = new Alerta();
            NAlerta MetodoAlerta = new NAlerta();
            unaAlerta.Stock = new Stock();
            unaAlerta.UsuarioCreador = new Usuario();
            unaAlerta.UsuarioCreador.ID = 1;
            unaAlerta.CantidadMinima = 10;
            unaAlerta.Stock.ID = 1;
            unaAlerta.ID = 1;
            Assert.AreEqual(MetodoAlerta.EditarAlerta(unaAlerta), false);// da false pero actua sobre la base de datos hay que revisar esto 
        }


        [TestMethod]
        public void BorrarAlerta()// elimina una alerta // no es borrado logico 
        {
            NAlerta MetodoAlerta = new NAlerta();
            int id = 2;
            Assert.AreEqual(MetodoAlerta.EliminarAlerta(id), false);// no existe alerta con id 2 
        }
        [TestMethod]
        public void ListarAlertas()// lista todas las alertas 
        {
            NAlerta MetodoAlerta = new NAlerta();
            Assert.IsNotNull(MetodoAlerta.RecuperarAlerta());
        }
        [TestMethod]
        public void ListarAlertasCriticas()// lista alertas que se encuentren por debajo de la cantidad minimas de producto 
        {
            NAlerta MetodoAlerta = new NAlerta();
            Assert.IsNotNull(MetodoAlerta.RecuperarAlertasCriticas());
        }
    }
}
