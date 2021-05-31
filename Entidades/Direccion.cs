using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Direccion : EntidadPersistible
    {
        private string _calle;

        public string Calle
        {
            get { return _calle; }
            set { _calle = value; }
        }

        private string _altura;

        public string Altura
        {
            get { return _altura; }
            set { _altura = value; }
        }


        private string _provincia;

        public string Provincia
        {
            get { return _provincia; }
            set { _provincia = value; }
        }


        private string _localidad;

        public string Localidad
        {
            get { return _localidad; }
            set { _localidad = value; }
        }

        private string _codigoPostal;

        public string CodigoPostal
        {
            get { return _codigoPostal; }
            set { _codigoPostal = value; }
        }

    }
}