using System;

namespace CapaEntidad
{
    public class Alerta
    {
        private int _cantidadMinima;
        private Stock _stock;
        private Usuario _usuarioCreador;

        public int CantidadMinima
        {
            get { return this._cantidadMinima; }
            set { _cantidadMinima = value; }
        }
        public Stock Stock
        {
            get { return this._stock; }
            set { _stock = value; }
        }
        public Usuario UsuarioCreador
        {
            get { return this._usuarioCreador; }
            set { _usuarioCreador = value; }
        }

    }
}
