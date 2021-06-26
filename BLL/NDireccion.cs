using DAL;
using Entidades;
using Excepciones;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class NDireccion
    {
        DDireccion unDireccion = new DDireccion();

        public DataTable CargarProvincias()
        {
            DataTable prov = unDireccion.RecuperaProvincias();
            if(prov.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return prov;
        }
        private Direccion Estandarizar(Direccion _unDireccion)
        {
            _unDireccion.Calle.ToLower();
            _unDireccion.Altura.ToLower();
            _unDireccion.CodigoPostal.ToLower();
            _unDireccion.Localidad.ToLower();
            _unDireccion.Provincia.ToLower();
            return _unDireccion;
        }
        /// <summary>
        /// Cargo Direccion en bbdd,
        /// Requiero Calle, Altura, CodigoPostal, Localidad y Provincia
        /// </summary>
        /// <param name="_unDireccion"></param>
        /// <returns>True o Excepcion "FallaEnInsercion"</returns>
        public bool Nuevo(Direccion _unDireccion)
        {
            if (string.IsNullOrEmpty(_unDireccion.Calle) || string.IsNullOrEmpty(_unDireccion.Altura) || string.IsNullOrEmpty(_unDireccion.Localidad))
            {
                throw new ExcepcionDeDatos();
            }
            if (string.IsNullOrEmpty(_unDireccion.CodigoPostal) || string.IsNullOrEmpty(_unDireccion.Provincia))
            {
                throw new ExcepcionDeDatos();
            }
            _unDireccion = Estandarizar(_unDireccion);

            if (unDireccion.Nuevo(_unDireccion))
            {
                return true;
            }
            throw new FallaEnInsercion();
        }

        public bool Editar(Direccion _unDireccion)
        {
            _unDireccion = Estandarizar(_unDireccion);
            if (_unDireccion.ID < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unDireccion.Editar(_unDireccion))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        public bool Eliminar(int _unDireccion)
        {
            if (_unDireccion < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unDireccion.Eliminar(_unDireccion))
            {
                return true;
            }
            throw new FallaEnEliminacion();
        }
        /// <summary>
        /// Llena DT con Direcciones
        /// columnas: 'altura', 'calle', 'codigo postal', 'localidad', 'provincia'
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public DataTable ListaDireccion()
        {
            DataTable dt = unDireccion.ListaDirecion();
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
    }
}
