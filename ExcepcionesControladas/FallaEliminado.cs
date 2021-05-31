using System;

namespace ExcepcionesControladas
{
    class FallaEliminado : ExcepcionControlada
    {
        public FallaEliminado()
        {
            this.Descripcion = "No se pudo eliminar registro";
        }
    }
}
