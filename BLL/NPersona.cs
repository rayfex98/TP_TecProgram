using Entidades;
using DAL;
using System.Data;

namespace BLL
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
