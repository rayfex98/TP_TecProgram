using System.Data;
using Entidades;

namespace ddl_modulo
{
    public class DOrden
    {
        public bool Nuevo(Orden unOrden)
        {
            try
            {
                Conexion db = new Conexion();
                string query = string.Format("EXEC CATEGORIAPROC @ID = NULL,@USUARIO={0},@FECHA={1},@TIPO = 'INSERT';", unOrden.UsuarioCreador.ID, unOrden.Fecha);
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
        public bool Editar(Orden unOrden)
        {
            try
            {
                Conexion db = new Conexion();
                if (ID_Orden(unOrden.ID))
                {
                    string query = string.Format("EXEC ORDENPROD @ID={0},@USUARIO={1},@FECHA={2},@TIPO = 'UPDATE';", unOrden.ID, unOrden.UsuarioCreador.ID, unOrden.Fecha);
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
        public bool Eliminar(int idOrden)
        {
            try
            {
                Conexion db = new Conexion();
                if (ID_Orden(idOrden))
                {
                    string query = string.Format("EXEC ORDENPROD @ID={0},@USUARIO=NULL,@FECHA=NULL,@TIPO = 'DELETE';", idOrden);
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
        public bool ID_Orden(int id)
        {
            try
            {
                Conexion db = new Conexion();
                string query = string.Format("EXEC ORDENPROD @ID={0},@USUARIO=NULL,@FECHA=NULL,@TIPO = 'SELECTONE';", id);
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
        public DataTable ListadeOrden()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}
