using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
{
    public class NPersona
    {
        DPersona unPersona = new DPersona();
        public bool Nuevo(Persona _unPersona)
        {
            return unPersona.Nuevo(_unPersona);
        }
        public bool Editar(Persona _unPersona)
        {
            return unPersona.Editar(_unPersona);
        }
        public bool Eliminar(Persona _unPersona) //elimino con DNI o ID
        {
            return unPersona.Eliminar(_unPersona);
        }
        public DataTable ListarPersona()
        {
            return unPersona.ListadePersona();
        }
    }
}