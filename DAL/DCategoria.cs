using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

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
                    new SqlParameter("@DESCRIPCION",SqlDbType.NVarChar),
                    new SqlParameter("@TIPO",SqlDbType.NVarChar)
                };
                parametros[0].Value = nombre;
                parametros[1].Value = "INSERT";
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


        public DataTable ListadeCategoria()
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
    }
}
