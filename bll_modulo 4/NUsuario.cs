using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
{
    public class NUsuario
    {
        DUsuario unUsuario = new DUsuario();

        public bool Nuevo(Usuario _unUsuario)
        {
            return unUsuario.Nuevo(_unUsuario);
        }
        public bool Editar(Usuario _unUsuario)
        {
            return unUsuario.Editar(_unUsuario);
        }
        public bool Eliminar(int _DNI)
        {
            return unUsuario.Eliminar(_DNI);
        }
        public DataTable ListarUsuario()
        {
            return unUsuario.ListadeUsuario();
        }
    }
}
