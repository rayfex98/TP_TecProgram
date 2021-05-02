using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Alerta : Reporte
    {
        private Stock _stock;

        public Stock Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        private int _cantidadMinima;

        public int CantidadMinima
        {
            get { return _cantidadMinima; }
            set { _cantidadMinima = value; }
        }

        private Usuario _usuarioCreador;

        public Usuario UsuarioCreador
        {
            get { return _usuarioCreador; }
            set { _usuarioCreador = value; }
        }



    }
}