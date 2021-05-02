using System;

namespace CapaEntidad
{
    public class Detalle_orden
    {

        private int _cantidad;
        private string _producto;

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public string Producto
        {
            get { return _producto; }
            set { _producto = value; }
        }
    }
}
