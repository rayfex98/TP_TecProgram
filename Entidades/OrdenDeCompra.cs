using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class OrdenDeCompra : Orden
    {
        private Usuario _usuarioAprobador;

        public Usuario UsuarioAprobador
        {
            get { return _usuarioAprobador; }
            set { _usuarioAprobador = value; }
        }


        private DateTime? _fechaAprobacion;

        public DateTime? FechaAprobacion
        {
            get {  return _fechaAprobacion; }
            set { _fechaAprobacion = value; }
        }



        private Proveedor _proveedor;

        public Proveedor Proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
        }


        public bool EstaAprobada
        {
            get { return FechaAprobacion.HasValue; }
        }

    }
}