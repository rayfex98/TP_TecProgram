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
            _unCategoria.Nombre = _unCategoria.Nombre.ToUpper();
            return unCategoria.Nuevo(_unCategoria);
        }
        public bool Editar(Categoria _unCategoria)
        {
            if(_unCategoria.Nombre != "") _unCategoria.Nombre = _unCategoria.Nombre.ToUpper();
            return unCategoria.Editar(_unCategoria);
        }
        public bool Eliminar(Categoria _unCategoria)
        {
            return unCategoria.Eliminar(_unCategoria);
        }
        public DataTable ListarCategoria() //nuevo metodo devuelve tabla de categorias
        {
            return unCategoria.ListadeCategoria();
        }
    }
}