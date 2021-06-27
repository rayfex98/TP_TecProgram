using System;

namespace Excepciones
{
    public class FallaEnEliminacion : ExcepcionNegocio
    {
        public FallaEnEliminacion()
        {
            this.Descripcion = "Error: No se pudo eliminar el registro";
        }
    }
}
