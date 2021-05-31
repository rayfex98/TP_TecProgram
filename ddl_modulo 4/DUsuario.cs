using System.Data;
using Entidades;

namespace ddl_modulo
{
    public class DUsuario
    {
        public bool Nuevo(Usuario unUsuario) //la alta del usuario se da despues de la ultima persona, necesito un max de la columna id persona para crear usuario y asociarlos
        {
            try
            {
                Conexion db = new Conexion();
                string query = string.Format("EXEC USUARIOPROC @ID=NULL,@ROL={1},@LEGAJO=NULL,@TIPO = 'INSERT';", unUsuario.Rol.ID);
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
        public bool Editar(Usuario unUsuario)
        {
            try
            {
                Conexion db = new Conexion();
                if (ID_Usuario(true, unUsuario.ID, -1))
                {
                    string query = string.Format("EXEC USUARIOPROC @ID={0},@ROL={1},@LEGAJO=NULL,@TIPO = 'UPDATE';", unUsuario.ID, unUsuario.Rol.ID);
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
        public bool Eliminar(int idUsuario)
        {
            try
            {
                Conexion db = new Conexion();
                if (ID_Usuario(true, idUsuario, -1))
                {
                    string query = string.Format("EXEC USUARIOPROC @ID={0},@ROL=NULL,@LEGAJO=NULL,@TIPO = 'DELETE';", idUsuario);
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
        public bool ID_Usuario(bool metodo, int id, int legajo)
        {
            try
            {
                Conexion db = new Conexion();
                string query;
                if (metodo == true)
                {
                    query = string.Format("EXEC USUARIOPROC @ID={0},@ROL=NULL,@LEGAJO={1},@TIPO = 'SELECTONE';", id, legajo);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                }
                else
                {
                    query = string.Format("USUARIOPROC @ID=NULL,@ROL=TINYINT,@LEGAJO=INT,@TIPO = 'SELECTID';", legajo);
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
        public DataTable ListadeUsuario()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}