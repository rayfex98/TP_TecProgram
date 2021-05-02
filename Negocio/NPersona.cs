using System.Data;
using Datos;
using CapaEntidad;

namespace Negocio
{
    public class NPersona
    {
        DPersona unPersona = new DPersona();

        public string Nuevo(Persona _unPersona)
        {
            return unPersona.Nuevo(_unPersona);
        }
        public string Editar(Persona _unPersona)
        {
            return unPersona.Editar(_unPersona);
        }
        public Persona Eliminar(int _DNI) //verID
        {
            return unPersona.Eliminar(_DNI);
        }
        public int ID_Persona()
        {
            return unPersona.ID_Persona();
        }
        public DataTable ListarPersona()
        {
            return unPersona.ListadePersona();
        }
    }
}