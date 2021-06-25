using DAL;
using Entidades;
using Excepciones;
using System.Data;

namespace BLL
{
    public class NCategoria
    {
        DCategoria unCategoria = new DCategoria();

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
        public DataTable ListarCategoria()
        {
            DataTable dt = unCategoria.ListadeCategoria();
            if(dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
        public DataTable ListadeCategoriaPorCategoria(string descripcion)
        {
            DataTable dt = unCategoria.ListadeCategoriaPorCategoria(descripcion);
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
    }
}
