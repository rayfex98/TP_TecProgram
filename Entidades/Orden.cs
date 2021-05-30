using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Orden : EntidadPersistible
    {
        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private Usuario _usuarioCreador;

        public Usuario UsuarioCreador
        {
            get { return _usuarioCreador; }
            set { _usuarioCreador = value; }
        }

        private List<DetalleOrden> _detalles = new List<DetalleOrden>();

        public List<DetalleOrden> Detalles
        {
            get { return _detalles; }
            set { _detalles = value; }
        }

    }
}