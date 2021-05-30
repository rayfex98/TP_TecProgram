using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
{
    public class NDireccion
    {
        DDireccion unDireccion = new DDireccion();

        public string Nuevo(Direccion _unDireccion)
        {
            return unDireccion.Nuevo(_unDireccion);
        }
        public string Editar(Direccion _unDireccion)
        {
            return unDireccion.Editar(_unDireccion);
        }
        public Direccion Eliminar(int _idDireccion,int _DNI)
        {
            return unDireccion.Eliminar(_idDireccion, _DNI);
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