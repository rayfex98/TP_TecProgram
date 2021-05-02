using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace Datos
{
    public class DAlerta
    {
        public string Nuevo(Alerta unAlerta)
        {
            //conexion con bbdd
            return "Ok";
        }
        public string Editar(Alerta unAlerta)
        {
            //conexion con bbdd
            return "Ok";
        }
        public Alerta Eliminar(int idAlerta)
        {
            Alerta eliminado = new Alerta();
            //conexion con bbdd
            return eliminado;
        }
        public int ID_Alerta()
        {
            return 0;
        }

        public DataTable ListadeAlertas()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}