using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
{
    public class NCategoria
    {
        DCategoria unCategoria = new DCategoria();

        public bool Nuevo(Categoria _unCategoria)
        {
            return unCategoria.Nuevo(_unCategoria);
        }
        public bool Editar(int idcategoria, string descripcionnueva)
        {
            return unCategoria.Editar(idcategoria,descripcionnueva);
        }
        public bool Eliminar(short _idCategoria)
        {
            return unCategoria.Eliminar(_idCategoria);
        }
        public int ID_Categoria()
        {
            return unCategoria.ID_Categoria();
        }
        public DataTable ListarCategoria()
        {
            return unCategoria.ListadeCategoria();
        }
        //nuevo metodo devuelve tabla de categorias
    }
}