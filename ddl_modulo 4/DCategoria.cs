using System;
using System.Data;
using Entidades;

namespace ddl_modulo
{
    public class DCategoria
    {
        public bool Nuevo(Categoria unCategoria)
        {
            Conexion db = new Conexion();
            if (!ID_Categoria(unCategoria.Nombre)) //si la nueva no existe ya dentro de la bbdd
            {
                string query = string.Format("IF NOT EXISTS (SELECT [IDCATEGORIA] FROM CATEGORIA WHERE [DESCRIPCION] = '{0}') EXEC CATEGORIAPROC @ID = NULL,@DESCRIPCION = '{0}',@TIPO = 'INSERT';", unCategoria.Nombre);
                if (1 != db.EscribirPorComando(query))
                {
                    return false;
                }
            }
            return true;
        }
        public bool Editar(int idcategoria, string descripcionnueva)
        {
            Conexion db = new Conexion();
            if (!ID_Categoria(descripcionnueva)) //si la nueva no existe ya dentro de la bbdd
            {
                string query = string.Format("IF EXISTS (SELECT [IDCATEGORIA] FROM CATEGORIA WHERE [IDCATEGORIA] = {0}) " +
                "EXEC CATEGORIAPROC @ID = {0},@DESCRIPCION = '{1}',@TIPO = 'UPDATE';", idcategoria, descripcionnueva);
                if (1 != db.EscribirPorComando(query))
                {
                    return false;
                }
            }
            return true;          
        }
        public bool Eliminar(int idCategoria)
        {
            Conexion db = new Conexion();
            string query = string.Format("IF EXISTS (SELECT [IDCATEGORIA] FROM CATEGORIA WHERE [IDCATEGORIA] = {0}) " +
                "EXEC CATEGORIAPROC @ID = {0},@DESCRIPCION = NULL,@TIPO = 'DELETE';", idCategoria);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;
        }
        public bool ID_Categoria(string descripcion) //SI EXISTE RETORNA TRUE
        {
            Conexion db = new Conexion();
            string query = string.Format("EXEC CATEGORIAPROC @ID = NULL,@DESCRIPCION = {0},@TIPO = 'SELECTID';",descripcion);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;
        }

        public DataTable ListadeCategoria()
        {
            Conexion db = new Conexion();
            return db.LeerPorStoreProcedure("mostrarcategoria");
         
        }
    }
}