using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Permiso : EntidadPersistible
    {
        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}