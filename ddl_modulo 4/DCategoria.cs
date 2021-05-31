using System.Data;
using Entidades;
using ExcepcionesControladas;

namespace ddl_modulo
{
    public class DCategoria
    {
        public bool Nuevo(Categoria unCategoria)
        {
            try {
                Conexion db = new Conexion();
                if (!ID_Categoria(false, unCategoria.Nombre))
                {
                    string query = string.Format("EXEC CATEGORIAPROC @ID = NULL,@DESCRIPCION = '{0}',@TIPO = 'INSERT';", unCategoria.Nombre);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch(System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }
        public bool Editar(Categoria unaCat) //
        {
            try
            {
                Conexion db = new Conexion();
                if (!ID_Categoria(true, unaCat.ID.ToString()))
                {
                    string query = string.Format("EXEC CATEGORIAPROC @ID = {0},@DESCRIPCION = '{1}',@TIPO = 'UPDATE';", unaCat.ID.ToString(), unaCat.Nombre);
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
        public bool Eliminar(Categoria unCat)
        {
            try
            {
                Conexion db = new Conexion();
                if (ID_Categoria(true, unCat.ID.ToString()))
                {
                    string query = string.Format("EXEC CATEGORIAPROC @ID = {0},@DESCRIPCION = NULL,@TIPO = 'DELETE';", unCat.ID);
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
        public bool ID_Categoria(bool metodo,string descripcion) //SI EXISTE RETORNA TRUE
        {
            try
            {
                Conexion db = new Conexion();
                string query;
                if (metodo == true)
                {
                    query = string.Format("EXEC CATEGORIAPROC @ID = {0},@DESCRIPCION = NULL,@TIPO = 'SELECTONE';", descripcion);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                }
                else
                {
                    query = string.Format("EXEC CATEGORIAPROC @ID = NULL,@DESCRIPCION = {0},@TIPO = 'SELECTID';", descripcion);
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

        public DataTable ListadeCategoria()
        {
            Conexion db = new Conexion();
            return db.LeerPorStoreProcedure("mostrarcategoria");
        }
    }
}