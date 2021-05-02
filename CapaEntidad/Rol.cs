using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    public class Rol
    {
        private int _idRol;
        private HashSet<Permiso> _permiso = new HashSet<Permiso>();
        private string _descripcion;


        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public bool AgregarPermiso(Permiso _permiso)
        {
            return this._permiso.Add(_permiso);
        }
    }
}
