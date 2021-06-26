using System;

namespace Excepciones
{
    public class FallaEnInsercion : ExcepcionNegocio
    {
        public FallaEnInsercion()
        {
            this.Descripcion = "Error: No se pudo ingresar el nuevo registro";
        }
    }
}
