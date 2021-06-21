using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class DCategoria
    {
        readonly Conexion db = new Conexion();
        DataTable dt = new DataTable();

        public bool AgregarCategoria(Categoria unCategoria)
        {
            try
            {
                string query = string.Format("EXEC CATEGORIAPROC @ID = null,@DESCRIPCION = {0},@HABILITADO = null,@TIPO =  'INSERT';", unCategoria.Nombre);
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
        public bool EliminarCategoria(Categoria unCat)
        {
            try
            {
                string query = string.Format("EXEC CATEGORIAPROC @ID = {0},@DESCRIPCION = NULL,@HABILITADO = null,@TIPO = 'DELETE';", unCat.ID);
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
            string query = string.Format("ListaCategorias");
            dt = db.LeerPorComando(query);
            return dt;
        }

        public DataTable ListadeCategoriaPorCategoria(string descripcion)
        {
            string query = string.Format("Exec ListaCategoriasCondicion @descripcion = {0}", descripcion);
            dt = db.LeerPorComando(query);
            return dt;
        }
    }
}
