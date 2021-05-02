using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Stock
    {
        int _cantidad;
        Producto _producto;


        public  Producto Producto
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
