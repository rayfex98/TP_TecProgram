using System.Data;
using Entidades;

namespace ddl_modulo
{
    public class DCategoria
    {

        Conexion db = new Conexion();
        public bool Nuevo(Categoria unCategoria)
        {
            string query = string.Format(" CATEGORIAPROC @ID ={0},@DESCRIPCION ={1},@TIPO= 'INSERT' ;", unCategoria.ID, unCategoria.Nombre);
            if ( 1 != db.EscribirPorComando(query) )
            {
                return false;
            }
            return true;
        }

        public bool Editar(int idcategoria, string descripcionnueva)
        {
            string query = string.Format("CATEGORIAPROC @ID ={0},@DESCRIPCION ={1},@TIPO= 'UPDATE'", idcategoria, descripcionnueva);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;          
        }
        public bool Eliminar(short idCategoria)
        {
            string query = string.Format("CATEGORIAPROC @ID = {0} ,@DESCRIPCION =null,@TIPO= 'DELETE'", idCategoria);
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
           // return db.LeerPorStoreProcedure("CATEGORIAPROC @ID = NULL,@STOCK = NULL,@USUARIO = NULL,@MINIMO = NULL,@TIPO = 'SELECTALL'");           
            return db.LeerPorStoreProcedure("VISTACAT");
         
        }
    }
}