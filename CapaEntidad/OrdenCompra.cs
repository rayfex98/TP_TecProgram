using System;

namespace CapaEntidad
{
    public class OrdenCompra : Orden
    {
        private DateTime _fechaAprobacion;
        private Proveedor _proveedor;
        private Usuario _usuarioAprovador;


        public DateTime FechaAprobacion
        {
            get { return this._fechaAprobacion; }
            set { _fechaAprobacion = value; }
        }
        public Proveedor Proveedor
        {
            get { return this._proveedor; }
            set { _proveedor = value; }
        }
        public Usuario UsuarioAprobador
        {
            get { return this._usuarioAprovador; }
            set { _usuarioAprovador = value; }
        }
    }
}
