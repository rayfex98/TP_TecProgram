using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    
    public abstract class Orden
    {
        private int _idOrden;
        private HashSet<Detalle_orden> _detalle = new HashSet<Detalle_orden>();
        private DateTime _fecha;
        private Usuario _usuarioCreador;


        public DateTime Fecha
        {
            get { return this._fecha; }
            set { _fecha = value; }
        }
        public DateTime Fecha
        {
            get { return this._fecha; }
            set { _fecha = value; }
        }
        public Usuario Usuario
        {
            get { return this._usuarioCreador; }
            set { _usuarioCreador = value; }
        }
    }
}
