using DAL;
using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class NCategoria
    {
        private readonly DCategoria unCategoria = new DCategoria();
        private readonly List<Categoria> _categorias = new List<Categoria>();

        #region Agregar,Editar,Eliminar,Habilitar
        /// <summary>
        /// Carga categoria en bbdd,
        /// Requiero descripcion
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>True o Excepcion "FallaEnInsercion"</returns>
        public bool AgregarCategoria(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ExcepcionDeDatos();
            }
            nombre = nombre.ToUpper();
            if (unCategoria.AgregarCategoria(nombre)) 
            {
                Categoria nueva = new Categoria
                {
                    Nombre = nombre,
                    ID = unCategoria.UltimaCategoria()
                };
                _categorias.Add(nueva);
                return true;
            } 
            throw new FallaEnInsercion();
        }
        public bool EditarCategoria(Categoria _unCategoria)
        {
            if (string.IsNullOrEmpty(_unCategoria.Nombre))
            {
                throw new ExcepcionDeDatos();
            } 
            _unCategoria.Nombre = _unCategoria.Nombre.ToUpper();
            if (unCategoria.EditarCategoria(_unCategoria))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        public bool EliminarCategoria(int _unCategoria)
        {
            if (_unCategoria < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unCategoria.EliminarCategoria(_unCategoria))
            {
                return true;
            }
            throw new FallaEnEliminacion();
        }
        public bool HabilitarCategoria(int _unCategoria)
        {
            if (_unCategoria < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unCategoria.HabilitarCategoria(_unCategoria))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        #endregion

        #region Listas
        public void CargarLista()
        {
            _categorias.Clear();
            DataTable products = unCategoria.RecuperarCategorias();
            foreach (DataRow item in products.Rows)
            {
                Categoria nuevacat = new Categoria
                {
                    ID = (int)Convert.ToSingle(item["id categoria"]),
                    Nombre = item["descripcion"].ToString()
                };
                _categorias.Add(nuevacat);
            }
        }
        /// <summary>
        /// IMPORTANTE usar CargarLista() primero
        /// columnas: 'descripcion','id categoria'
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public List<Categoria> RecuperarCategoria()
        {
            if (_categorias.Count == 0)
            {
                throw new NoEncontrado();
            }
            return _categorias;
        }
        #endregion
    }
}
