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
        public bool Editar(Direccion _unDireccion, short id)
        {
            return unDireccion.Editar(_unDireccion,id);
        }
        public bool Eliminar(short _idDireccion)
        {
            return unDireccion.Eliminar(_idDireccion);
        }
        public int ID_Direccion()
        {
            return unDireccion.ID_Direccion();
        }
        public DataTable ListarDireccion()
        {
            return unDireccion.ListadeDireccion();
        }
    }
}