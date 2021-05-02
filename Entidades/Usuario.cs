using System;

namespace Entidades
{
    public class Usuario : Persona
    {
        private int _legajo;
        private Rol _rol;
        

        public Usuario ()
        {
            Console.Write("\n se crea un usuario");
        }
        public int Legajo
        {
            get { return _legajo;  }
            set { _legajo = value; }
        }
        public  Rol Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }
    }
}
