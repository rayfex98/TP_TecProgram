using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public abstract class DetalleOrden: EntidadPersistible
    {

        private Producto _producto;

        public Producto Producto
        {
            get { return _producto; }
            set { _producto = value; }
        }

        private int _cantidad;

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
    }
}