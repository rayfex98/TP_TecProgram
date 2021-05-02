using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Usuario : Persona
    {
        private int _legajo;

        public int Legajo
        {
            get { return _legajo; }
            set { _legajo = value; }
        }

        private Rol _rol;

        public Rol Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }


    }
}