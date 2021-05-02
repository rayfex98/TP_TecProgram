using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Proveedor : EntidadPersistible
    {
        private string _razonSocial;

        public string RazonSocial
        {
            get { return _razonSocial; }
            set { _razonSocial = value; }
        }

        private string _cuil;

        public string CUIL
        {
            get { return _cuil; }
            set { _cuil = value; }
        }

        private Direccion _direccion;

        public Direccion Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }



    }
}