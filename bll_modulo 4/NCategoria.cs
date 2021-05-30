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
        public bool Eliminar(int _idCategoria)
        {
            return unCategoria.Eliminar(_idCategoria);
        }
        public bool ID_Categoria(string descripcion) //crear nuevo que retorne el id?
        {
            return unCategoria.ID_Categoria(descripcion);
        }
        public DataTable ListarCategoria() //nuevo metodo devuelve tabla de categorias
        {
            return unCategoria.ListadeCategoria();
        }
    }
}