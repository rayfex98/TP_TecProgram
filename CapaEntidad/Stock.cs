using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Stock : EntidadPersistible
    {
        private int _cantidad;

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
        private Producto _producto;

        public Producto Producto
        {
            get { return _producto; }
            set { _producto = value; }
        }

    }
}