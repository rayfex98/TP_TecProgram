using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public abstract class Persona : EntidadPersistible
    {
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private int _dni;

        public int DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }

        private string _apellido;

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }


        private Direccion _direccion;

        public Direccion Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }



    }
}