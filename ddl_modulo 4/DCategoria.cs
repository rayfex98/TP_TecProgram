using System.Data;
using Entidades;

namespace ddl_modulo
{
    public class DCategoria
    {
        public bool Nuevo(Categoria unCategoria)
        {
            Conexion db = new Conexion();
            string query = string.Format("insert into CATEGORIA(DESCRIPCION)" +
                "values ('{0}')",unCategoria.Nombre);
            if ( 1 != db.EscribirPorComando(query) )
            {
                return false;
            }
            return true;
        }
        public bool Editar(int idcategoria, string descripcionnueva)
        {
            Conexion db = new Conexion();
            string query = string.Format("update[dbo].[CATEGORIA] set DESCRIPCION = '{0}' where IDCATEGORIA like '{1}'",descripcionnueva,idcategoria);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;          
        }
        public bool Eliminar(int idCategoria)
        {
            Conexion db = new Conexion();
            string query = string.Format("delete from CATEGORIA where IDCATEGORIA = {0};",idCategoria);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;
        }
        public int ID_Categoria()
        {
            return 0;
        }

        public DataTable ListadeCategoria()
        {
            Conexion db = new Conexion();
            return db.LeerPorStoreProcedure("mostrarcategoria");
         
        }
    }
}