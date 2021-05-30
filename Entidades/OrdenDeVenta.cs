using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class OrdenDeVenta : Orden
    {

        private MetodoDePago _metodoDePago;

        public MetodoDePago MetodoDePago
        {
            get { return _metodoDePago; }
            set { _metodoDePago = value; }
        }

        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }


    }
}