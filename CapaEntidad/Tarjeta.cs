using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Tarjeta : MetodoDePago
    {

        private string _nombreTarjeta;

        public string NombreTarjeta
        {
            get { return _nombreTarjeta; }
            set { _nombreTarjeta = value; }
        }

        private string _numeroTarjeta;

        public string NumeroTarjeta
        {
            get { return _numeroTarjeta; }
            set { _numeroTarjeta = value; }
        }


        private string _fechaVencimiento;

        public string FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set { _fechaVencimiento = value; }
        }

        private string _CVC;

        public string CVC
        {
            get { return _CVC; }
            set { _CVC = value; }
        }




    }
}