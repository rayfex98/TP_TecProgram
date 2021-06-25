using DAL;
using Entidades;
using Excepciones;
using System.Data;

namespace BLL
{
    public class NProveedor
    {
        DProveedor ObjProveedor = new DProveedor();

        private Proveedor Estandarizar(Proveedor obj)
        {
            obj.CUIL.ToLower();
            obj.RazonSocial.ToLower();
            return obj;
        }
        /// <summary>
        /// Carga de nuevo Proveedor en la bbdd,
        /// Requiero direccion completa, CUIL y razon social
        /// </summary>
        /// <param name="_proveedor"></param>
        /// <returns>True o Excepcion "FallaEnInsercion"</returns>
        public bool Nuevo(Proveedor _proveedor)
        {
            if (_proveedor.Direccion.ID < 0 || string.IsNullOrEmpty(_proveedor.CUIL) || string.IsNullOrEmpty(_proveedor.RazonSocial))
            {
                throw new ExcepcionDeDatos();
            }
            _proveedor = Estandarizar(_proveedor);
            if (ObjProveedor.Nuevo(_proveedor))
            {
                return true;
            }
            throw new FallaEnInsercion();
        }
        public bool Editar(Proveedor _proveedor)
        {
            if (_proveedor.ID < 0)
            {
                throw new ExcepcionDeDatos();
            }
            _proveedor = Estandarizar(_proveedor);
            if (ObjProveedor.Editar(_proveedor))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        public bool Habilitar(int id)
        {
            if (id < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (ObjProveedor.Estado(id, true))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        public bool Deshabilitar(int id)
        {
            if(id < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (ObjProveedor.Estado(id, false))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }

        #region listaProvedores
        public DataTable ListaProveedoresTodos()
        {
            DataTable dt = ObjProveedor.ListaProveedores();
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
        #endregion
        
        public DataTable ListarProveedoresHabilitados()
        {
            DataTable dt = ObjProveedor.ListaProveedoresHabilitados();
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }

        public DataTable ListarProveedoresPorProvincia(string provincia)
        {
            DataTable dt = ObjProveedor.ListaProveedoresPorProvincia(provincia);
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
    }
}
