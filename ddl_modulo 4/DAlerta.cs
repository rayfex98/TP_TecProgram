using System.Data;
using Entidades;

namespace ddl_modulo
{
    public class DAlerta
    {
        public bool Nuevo(Alerta unAlerta, Persona unapersona , Stock stock)
        {
            Conexion db = new Conexion();
            string query = string.Format("insert into ALERTA(CANTIDADMINIMA, IDPERSONA, IDSTOCK)" + 
                "values({0}, {1}, {2})",unAlerta.CantidadMinima, unapersona.ID, stock.ID);
                db.EscribirPorComando(query);
      
            //conexion con bbdd
            return true;
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