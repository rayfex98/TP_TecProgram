using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Orden_compra : Orden
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
