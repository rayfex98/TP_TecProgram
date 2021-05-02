using System;

namespace CapaEntidad
{
    public class Stock
    {
        int _cantidad;
        Producto _producto;


        public Producto Producto
        {
            get { return _producto; }
            set { _producto = value; }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
    }
}
