using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rol
    {
        private HashSet<Permiso> _permiso = new HashSet<Permiso>();
        private string _descripcion;


        public  string Descripcion 
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
