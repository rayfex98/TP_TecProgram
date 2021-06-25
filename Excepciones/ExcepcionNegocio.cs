using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class ExcepcionNegocio : Exception
    {
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

    }
}
