using System;

namespace Excepciones
{
    public class FallaEnEdicion : ExcepcionNegocio
    {
        public FallaEnEdicion()
        {
            this.Descripcion = "Error: No se pudo editar el registro";
        }
    }
}
