using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    public abstract class Orden
    {
        protected int _idOrden;
        private HashSet<DetalleOrden> _detalle = new HashSet<DetalleOrden>();
        private DateTime _fecha;
        private Usuario _usuarioCreador;

        public DateTime GetFecha()
        { return this._fecha; }
        public void SetFecha(DateTime value)
        { _fecha = value; }

        public Usuario Usuario
        {
            get { return this._usuarioCreador; }
            set { _usuarioCreador = value; }
        }
    }
}
