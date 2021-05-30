using System.Data;
using Entidades;

namespace ddl_modulo
{
    public class DAlerta
    {
            Conexion db = new Conexion();
        public bool Nuevo(Alerta unAlerta, Persona unapersona , Stock stock)
        {
            string query = string.Format("ALERTAPROC @ID = null,@STOCK = {0},@USUARIO = {1},@MINIMO = {2},@TIPO = 'INSERT';",stock.ID,unapersona.ID,unAlerta.CantidadMinima);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;
        }
        public bool Editar(Alerta unAlerta, int id_alerta)
        {
            string query = string.Format("ALERTAPROC @ID = {0},@STOCK = null,@USUARIO = null,@MINIMO = {1},@TIPO = 'UPDATE';",id_alerta,unAlerta.CantidadMinima);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;
        }
        public bool Eliminar(int id_alerta)
        {
            string query = string.Format("ALERTAPROC @ID = {0},@STOCK = null,@USUARIO = null,@MINIMO = null ,@TIPO = 'DELETE';", id_alerta);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;
        }
        public int ID_Alerta()
        {
            return 0;
        }

        public DataTable ListadeAlertas()
        {
            return db.LeerPorStoreProcedure("VISTAALERTA");
        }
    }
}