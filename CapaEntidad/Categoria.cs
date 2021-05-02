using System;

namespace CapaEntidad
{
    public class Categoria
    {
        private int _idCategoria;
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
    }
}
