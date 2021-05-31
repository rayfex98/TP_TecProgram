using System;

namespace ExcepcionesControladas
{
    class RegistroNoEncontrado : ExcepcionControlada
    {
        public RegistroNoEncontrado()
        {
            this.Descripcion = "No se encontro el registro";
        }
    }
}
