using System;

namespace CapaEntidad
{
    public class Permiso
    {
        private string _descripcion;


        public string Descripcion
        {
            get { return this._descripcion; }
            set { _descripcion = value; }
        }
    }
}
