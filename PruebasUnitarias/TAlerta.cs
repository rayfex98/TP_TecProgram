using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class TAlerta
    {

        [TestMethod]
        public void NuevaAlerta()
        {
            Alerta unaAlerta = new Alerta();
            NAlerta MetodoAlerta = new NAlerta();
            unaAlerta.Stock = new Stock();
            unaAlerta.Stock.Producto = new Producto();
            unaAlerta.UsuarioCreador = new Usuario();
            unaAlerta.Stock.ID = 31;
            unaAlerta.UsuarioCreador.ID = 1;
            unaAlerta.CantidadMinima = 100;
            Assert.AreEqual(MetodoAlerta.CrearAlerta(unaAlerta), true);//ya esta creada con este id
            /* unaAlerta.Stock.ID = 4;
             unaAlerta.UsuarioCreador.ID = 1;
             unaAlerta.CantidadMinima = 200;
             Assert.AreEqual(MetodoAlerta.CrearAlerta(unaAlerta), true);
             unaAlerta.Stock.ID = 5;
             unaAlerta.UsuarioCreador.ID = 1;
             unaAlerta.CantidadMinima = 20;
             Assert.AreEqual(MetodoAlerta.CrearAlerta(unaAlerta), true);
             Assert.AreEqual(MetodoAlerta.CrearAlerta(unaAlerta), false); //no vuelve a agregar si tiene el mismo nombre*/
        }

        [TestMethod]
        public void EditarAler()
        {
            Alerta unaAlerta = new Alerta();
            NAlerta MetodoAlerta = new NAlerta();
            unaAlerta.Stock = new Stock();
            unaAlerta.UsuarioCreador = new Usuario();
            unaAlerta.UsuarioCreador.ID = 1;
            unaAlerta.CantidadMinima = 10;
            unaAlerta.Stock.ID = 1;
            unaAlerta.ID = 16;
            Assert.AreEqual(MetodoAlerta.EditarAlerta(unaAlerta), false);// da false pero actua sobre la base de datos hay que revisar esto 
        }


        [TestMethod]
        public void BorrarAlerta()
        {
            Alerta unaAlerta = new Alerta();
            NAlerta MetodoAlerta = new NAlerta();
            unaAlerta.ID = 21;
            Assert.AreEqual(MetodoAlerta.EliminarAlerta(unaAlerta), false);// no existe alerta con id 2 
        }
        [TestMethod]
        public void ListarAlertas()
        {
            NAlerta MetodoAlerta = new NAlerta();
            Assert.IsNotNull(MetodoAlerta.ListarAlerta());
        }
        [TestMethod]
        public void ListarAlertasCriticas()
        {
            NAlerta MetodoAlerta = new NAlerta();
            Assert.IsNotNull(MetodoAlerta.ListarAlertasCriticas());
        }
    }
}
