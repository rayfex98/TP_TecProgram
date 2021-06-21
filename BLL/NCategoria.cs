using DAL;
using Entidades;
using System;
using System.Data;

namespace BLL
{
    public class NCategoria
    {
        DCategoria unCategoria = new DCategoria();

        public bool AgregarCategoria(Categoria _unCategoria)
        {
            _unCategoria.Nombre = _unCategoria.Nombre.ToUpper();
            return unCategoria.AgregarCategoria(_unCategoria);
        }
        public bool EditarCategoria(Categoria _unCategoria)
        {
            if (_unCategoria.Nombre != "") _unCategoria.Nombre = _unCategoria.Nombre.ToUpper();
            return unCategoria.EditarCategoria(_unCategoria);
        }
        public bool EliminarCategoria(Categoria _unCategoria)
        {
            return unCategoria.EliminarCategoria(_unCategoria);
        }
        public DataTable ListarCategoria()
        {
            return unCategoria.ListadeCategoria();
        }
        public DataTable ListadeCategoriaPorCategoria(string descripcion)
        {
            
            return unCategoria.ListadeCategoriaPorCategoria(descripcion);
        }
    }
}
