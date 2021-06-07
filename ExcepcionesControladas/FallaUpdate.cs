using System;

namespace ExcepcionesControladas
{
    class FallaUpdate : ExcepcionControlada
    {
        public FallaUpdate()
        {
            this.Descripcion = "No se pudo actualizar registro";
        }
    }
}
