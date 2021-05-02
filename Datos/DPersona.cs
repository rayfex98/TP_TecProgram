using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace Datos
{
    public class DPersona
    {
        public string Nuevo(Persona unPersona)
        {
            //conexion con bbdd
            return "Ok";
        }
        public string Editar(Persona unPersona)
        {
            //conexion con bbdd
            return "Ok";
        }
        public Persona Eliminar(int DNI)
        {
            Persona eliminado = new Persona();
            //conexion con bbdd
            return eliminado;
        }
        public int ID_Persona()
        {
            return 0;
        }
        public DataTable ListadePersona()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}
