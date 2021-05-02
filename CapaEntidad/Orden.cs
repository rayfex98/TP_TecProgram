using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    public abstract class Orden
    {
        protected int _idOrden;
        private HashSet<Detalle_orden> _detalle = new HashSet<Detalle_orden>();
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
