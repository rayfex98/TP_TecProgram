using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Producto : EntidadPersistible
    {
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        private Categoria _categoria;

        public Categoria Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }


        private float _precioVenta;

        public float PrecioVenta
        {
            get { return _precioVenta; }
            set { _precioVenta = value; }
        }

        private float _precioCompra;

        public float PrecioCompra
        {
            get { return _precioCompra; }
            set { _precioCompra = value; }
        }




    }
}