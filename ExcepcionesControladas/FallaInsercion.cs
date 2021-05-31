using System;

namespace ExcepcionesControladas
{
    class FallaInsercion : ExcepcionControlada
    {
        public FallaInsercion()
        {
            this.Descripcion = "No se pudo agregar registro";
        }
    }
}
