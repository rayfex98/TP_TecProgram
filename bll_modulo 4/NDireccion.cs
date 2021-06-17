using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
{
    public class NDireccion
    {
        DDireccion unDireccion = new DDireccion();

        public bool Nuevo(Direccion _unDireccion)
        {
            return unDireccion.Nuevo(_unDireccion);
        }
        public bool Editar(Direccion _unDireccion)
        {
            return unDireccion.Editar(_unDireccion);
        }
        public bool Eliminar(Direccion _unDireccion)
        {
            return unDireccion.Eliminar(_unDireccion);
        }
    }
}