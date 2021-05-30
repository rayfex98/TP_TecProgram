using System.Data;
using Entidades;

namespace ddl_modulo
{
    public class DAlerta
    {
        public bool Nuevo(Alerta unAlerta)
        {
            Conexion db = new Conexion();
            if (!ID_Alerta(unAlerta.Stock.ID)) //si tupla unica no existe ya dentro de la bbdd
            {
                string query = string.Format("EXEC ALERTAPROC @ID = NULL,@STOCK = {0},@USUARIO = {1},@MINIMO = {2},@TIPO = 'INSERT';", unAlerta.Stock.ID, unAlerta.UsuarioCreador.ID, unAlerta.CantidadMinima);
                if (1 != db.EscribirPorComando(query))
                {
                    return false;
                }
            }
            return true;
        }
        public bool Editar(Alerta unAlerta) //
        {
            Conexion db = new Conexion();
            if (ID_Alerta(unAlerta.ID) && !ID_Alerta(unAlerta.Stock.ID))
            {
                string query = string.Format("ALERTAPROC @ID = {0},@STOCK = null,@USUARIO = null,@MINIMO = {1},@TIPO = 'UPDATE';", unAlerta.ID, unAlerta.CantidadMinima);
                if (1 != db.EscribirPorComando(query))
                {
                    return false;
                }
            }
            return true;
        }
        public bool Eliminar(Alerta unAlerta)
        {
            Conexion db = new Conexion();
            if (ID_Alerta(unAlerta.ID))
            {
                string query = string.Format("ALERTAPROC @ID = {0},@STOCK = null,@USUARIO = null,@MINIMO = null ,@TIPO = 'DELETE';", unAlerta.ID);
                if (1 != db.EscribirPorComando(query))
                {
                    return false;
                }
            }
            return true;
        }
        public bool ID_Alerta(int id) //SI EXISTE RETORNA TRUE
        {
            Conexion db = new Conexion();
            string query;
            query = string.Format("EXEC ALERTAPROC @ID = NULL,@STOCK = {0},@USUARIO = NULL,@MINIMO = NULL,@TIPO = 'SELECTONE';", id);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            query = string.Format("EXEC ALERTAPROC @ID = NULL,@STOCK = {0},@USUARIO = NULL,@MINIMO = NULL,@TIPO = 'SELECTID';", id);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;
        }

        public DataTable ListadeAlertas()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}