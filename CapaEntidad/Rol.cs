using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Rol : EntidadPersistible
    {
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }


        private List<Permiso> _permisos = new List<Permiso>();

        public List<Permiso> Permisos
        {
            get { return _permisos; }
            set { _permisos = value; }
        }

    }
}