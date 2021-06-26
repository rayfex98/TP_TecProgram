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
    }
}
