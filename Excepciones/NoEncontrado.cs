using System;

namespace Excepciones
{
    public class NoEncontrado : ExcepcionNegocio
    {
        public NoEncontrado()
        {
            this.Descripcion = "Error: No se Encontraron registros coincidentes";
        }
    }
}
