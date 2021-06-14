﻿using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
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
            if(_unCategoria.Nombre != "") _unCategoria.Nombre = _unCategoria.Nombre.ToUpper();
            return unCategoria.EditarCategoria(_unCategoria);
        }
        public bool EliminarCategoria(Categoria _unCategoria)
        {
            return unCategoria.EliminarCategoria(_unCategoria);
        }
        public DataTable ListarCategoria() //nuevo metodo devuelve tabla de categorias
        {
            return unCategoria.ListadeCategoria();
        }
    }
}