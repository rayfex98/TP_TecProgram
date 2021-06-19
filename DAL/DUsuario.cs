using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class DUsuario
    {
        readonly Conexion db = new Conexion();
        DataTable dt = new DataTable();
        public bool Nuevo(Usuario unUsuario) //la alta del usuario se da despues de la ultima persona, necesito un max de la columna id persona para crear usuario y asociarlos
        {
            try
            {
                string query = string.Format("EXEC USUARIOPROC @ID=NULL,@ROL= {0} ,@LEGAJO=NULL,@TIPO = 'INSERT';", unUsuario.Rol.ID);
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
                string query = string.Format("EXEC USUARIOPROC @ID={0},@ROL={1},@LEGAJO=NULL,@TIPO = 'UPDATE';", unUsuario.ID, unUsuario.Rol.ID);
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
        public bool Eliminar(int idUsuario)
        {
            try
            {
                string query = string.Format("EXEC USUARIOPROC @ID={0},@ROL=NULL,@LEGAJO=NULL,@TIPO = 'DELETE';", idUsuario);
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
        public DataTable ListadeUsuario() //FACU: Crear vista correspondiente o usar metodo de otro modulo para recuperar datos de usuario
        {
            string query = string.Format("VistaUsuarios");
            dt = db.LeerPorComando(query);
            //busco en tabla
            return dt;
        }
    }
}
