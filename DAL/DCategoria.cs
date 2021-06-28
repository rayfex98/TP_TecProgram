using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DCategoria
    {
        readonly Conexion db = new Conexion();
        DataTable dt = new DataTable();

        public bool AgregarCategoria(string nombre)
        {
            try
            {
                SqlParameter[] parametros =
                {
                    new SqlParameter("@ID",SqlDbType.SmallInt),
                    new SqlParameter("@DESCRIPCION",SqlDbType.VarChar),
                    new SqlParameter("@HABILITADO",SqlDbType.DateTime),
                    new SqlParameter("@TIPO",SqlDbType.NVarChar)
                };
                parametros[0].Value = 0;
                parametros[1].Value = nombre;
                parametros[2].Value = System.DateTime.Now;
                parametros[3].Value = "INSERT";
                if(db.EscribirPorStoreProcedure("CATEGORIAPROC", parametros) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }
        public bool EditarCategoria(Categoria unaCat)
        {
            try
            {
                string query = string.Format("EXEC CATEGORIAPROC @ID = {0},@DESCRIPCION = {1},@HABILITADO = null,@TIPO ='UPDATE';", unaCat.ID.ToString(), unaCat.Nombre);
                int prueba = db.EscribirPorComando(query);
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
        public bool HabilitarCategoria(int id)
        {
            try
            {
                string query = string.Format("EXEC CATEGORIAPROC @ID = {0},@DESCRIPCION = null,@HABILITADO = null,@TIPO ='ESTADO';", id);
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
        public bool EliminarCategoria(int id)
        {
            try
            {
                string query = string.Format("EXEC CATEGORIAPROC @ID = {0},@DESCRIPCION = NULL,@HABILITADO = null,@TIPO = 'DELETE';", id);
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


        public DataTable RecuperarCategorias()
        {
            SqlParameter[] parametros =
            {
            };
            dt = db.LeerPorStoreProcedure("ListaCategorias", parametros);
            return dt;
        }

        public DataTable ListadeCategoriaPorCategoria(string descripcion)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@descripcion",SqlDbType.NVarChar)
            };
            parametros[0].Value = descripcion;
            dt = db.LeerPorStoreProcedure("ListaCategoriasCondicion", parametros);
            return dt;
        }
        public int UltimaCategoria()
        {
            string query = string.Format("Select MAX(id_categoria) FROM [dbo].[categoria]");
            dt = db.LeerPorComando(query);
            if (dt.Rows.Count == 0)
            {
                return -1;
            }
            return int.Parse(dt.Rows[0].ItemArray[0].ToString());
        }

    }
}
