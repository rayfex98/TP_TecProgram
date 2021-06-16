using System.Data;
using Entidades;
using ExcepcionesControladas;

namespace ddl_modulo
{

    public class DAlerta
    {
        DataTable dt = new DataTable();
        Conexion db = new Conexion();
        public bool CrearAlerta(Alerta unAlerta)
        {
            try
            {
           
                    string query = string.Format("EXEC ALERTAPROC @ID = NULL, @STOCK = {0},@USUARIO = {1},@MINIMO = {2},@TIPO = 'INSERT' ", unAlerta.Stock.ID, unAlerta.UsuarioCreador.ID, unAlerta.CantidadMinima);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                return true;
            
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }
        public bool EditarAlerta(Alerta unAlerta)
        {
            int idstock = unAlerta.Stock.ID;
            int idusuario = unAlerta.UsuarioCreador.ID;



            string query = string.Format(" ALERTAPROC @ID = {0}, @STOCK = {1}, @USUARIO = {2}, @MINIMO = {3}, @TIPO = 'UPDATE' ", unAlerta.ID, idstock, idusuario, unAlerta.CantidadMinima);
            if (1 == db.EscribirPorComando(query))
            {
                return true;
            }
            return false;

        }
        public bool EliminarAlerta(Alerta unAlerta)
        {
            try
            {

                    string query = string.Format("ALERTAPROC @ID = {0},@STOCK = null,@USUARIO = null,@MINIMO = null ,@TIPO = 'DELETE';", unAlerta.ID);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
            catch (System.NullReferenceException)
            {
                return false;
            }
        }


        public DataTable ListadeAlertas()
        {

            string query = string.Format("AlertasList");
            dt = db.LeerPorComando(query);
            //busco en tabla
            return dt;
        }
    }
}