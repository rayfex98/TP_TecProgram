using System.Data;
using Entidades;
using ExcepcionesControladas;

namespace ddl_modulo
{
    public class DAlerta
    {
        public bool CrearAlerta(Alerta unAlerta)
        {
            try
            {
                Conexion db = new Conexion();
                if (!ID_Alerta(false, unAlerta.Stock.ID))
                {
                    string query = string.Format("EXEC ALERTAPROC @ID = NULL, @STOCK = { 0},@USUARIO = { 1},@MINIMO = { 2},@TIPO = 'INSERT'; ", unAlerta.Stock.ID, unAlerta.UsuarioCreador.ID, unAlerta.CantidadMinima);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }
        public bool EditarAlerta(Alerta unAlerta) //
        {
            try
            {
                Conexion db = new Conexion();
                if (ID_Alerta(true, unAlerta.ID) && !ID_Alerta(false, unAlerta.Stock.ID)) //id debe existir
                {
                    string query = string.Format("ALERTAPROC @ID = {0},@STOCK = null,@USUARIO = null,@MINIMO = {1},@TIPO = 'UPDATE';", unAlerta.ID, unAlerta.CantidadMinima);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                    return true;
                }
                return false;
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
        public bool EliminarAlerta(Alerta unAlerta)
        {
            try
            {
                Conexion db = new Conexion();
                if (ID_Alerta(true, unAlerta.ID))
                {
                    string query = string.Format("ALERTAPROC @ID = {0},@STOCK = null,@USUARIO = null,@MINIMO = null ,@TIPO = 'DELETE';", unAlerta.ID);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
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

        public bool ID_Alerta(bool metodo, int id) //SI EXISTE RETORNA TRUE
        {
            try
            {
                Conexion db = new Conexion();
                string query;
                if (metodo == true)
                {
                    query = string.Format("EXEC ALERTAPROC @ID = NULL,@STOCK = {0},@USUARIO = NULL,@MINIMO = NULL,@TIPO = 'SELECTONE';", id);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                }
                else
                {
                    query = string.Format("EXEC ALERTAPROC @ID = NULL,@STOCK = {0},@USUARIO = NULL,@MINIMO = NULL,@TIPO = 'SELECTID';", id);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
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
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}