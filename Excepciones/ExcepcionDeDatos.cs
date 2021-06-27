using System;

namespace Excepciones
{
    public class ExcepcionDeDatos : ExcepcionNegocio
    {
        public ExcepcionDeDatos()
        {
            this.Descripcion = "Error: Valide los campos y vuelva a intentar";
        }
    }
}
