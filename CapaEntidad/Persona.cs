using System;


namespace CapaEntidad
{
    public class Persona
    {
        public Persona()
        {
            Console.Write("\n crea una persona ");
        }

        private Direccion _direccion;
        protected int _dni;
        private string _apellido;
        private string _nombre;

        public Direccion Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }

    }
}
