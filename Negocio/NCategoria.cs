using System.Data;
using Datos;
using Entidades;

namespace Negocio
{
    public class NCategoria
    {
        DCategoria unCategoria = new DCategoria();

        public string Nuevo(Categoria _unCategoria)
        {
            return unCategoria.Nuevo(_unCategoria);
        }
        public string Editar(Categoria _unCategoria)
        {
            return unCategoria.Editar(_unCategoria);
        }
        public Categoria Eliminar(int _idCategoria)
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
    }
}