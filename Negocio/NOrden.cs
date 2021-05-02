using CapaEntidad;
using System;

namespace Negocio
{
    class NOrden
    {
        public void CreaOrden() /// :base(Nombre)
        {
            ///persiste en la base de datos
            ///en principio lo hardcodeariamos ahora 
            ///alter-add
        }

        public void Modifica() ///:base(id) se incluye en el caso de uso de busqueda 
        {
            ///persiste en la base de datos 
            ///alter modify

        }
        public void Elimina() ///:base(id) se incluye en el caso de uso de busqueda 
        {
            ///persiste en la base de datos
            ///en principio lo hardcodeariamos ahora 
            ///alter delete
        }
        public void Busca()///:base(id) 
        {
            ///en principio lo hardcodeariamos ahora 

        }
        public void habilita(Usuario _UsuarioHabilitador)///:base(id) se incluye en el caso de uso de busqueda 
        {
            ///habilita orden de compra 
            ///esto puede ser usado por generente unicamente hay que ver como usar la condicion con rol 

        }
    }
}
