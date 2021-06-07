using System;

namespace ExcepcionesControladas
{
    public class ExcepcionControlada : Exception
    {
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}
