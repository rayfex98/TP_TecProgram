using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        private Categoria _categoria;
        private int _idProducto;
        private float _precioCompra;
        private float _precioVenta;
        private string _nombre;


        public  Categoria Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public float PrecioCompra
        {
            get { return this._precioCompra; }
            set { _precioCompra = value; }
        }
        public float PrecioVenta
        {
            get { return this._precioVenta;  }
            set { _precioVenta = value; }
        }
        public int IdProducto 
        {
            get { return this._idProducto; }
            set { _idProducto = value; }
        }
    }
}
