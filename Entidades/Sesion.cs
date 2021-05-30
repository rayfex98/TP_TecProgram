using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Sesion : EntidadPersistible
    {
        private Usuario _usuario;

        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }


        private DateTime _fechaInicio;

        public DateTime Inicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }

        private DateTime _fechaFin;

        public DateTime Fin
        {
            get { return _fechaFin; }
            set { _fechaFin = value; }
        }


    }
}