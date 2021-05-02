using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Categoria : EntidadPersistible
    {
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

    }
}