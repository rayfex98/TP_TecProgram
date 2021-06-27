using DAL;
using Entidades;
using Excepciones;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class NProveedor
    {
        List<Proveedor> _proveedores = new List<Proveedor>();
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
                _proveedores.Add(_proveedor);
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
        /// <summary>
        /// Cargar la lista a utilizar de proveedores
        /// </summary>
        /// <param name="filtro">false Para todos, true para habilitado</param>
        public Proveedor ConvertirProveedor(DataRow item)
        {
            Proveedor nuevoprov = new Proveedor();
            Direccion nuevacdir = new Direccion();
            nuevoprov.ID = (int)item["ID Proveedor"];
            nuevoprov.RazonSocial = item["Razon social"].ToString();
            nuevoprov.CUIL = item["CUIL"].ToString();
            nuevacdir.ID = (int)item["Direccion"];
            nuevacdir.Calle = item["Calle"].ToString();
            nuevacdir.CodigoPostal = item["Codigo postal"].ToString();
            nuevacdir.Localidad = item["Localidad"].ToString();
            nuevacdir.Provincia = item["Provincia"].ToString();
            nuevoprov.Direccion = nuevacdir;

            return nuevoprov;
        }

        #region listas de Provedores

        /// <summary>
        /// columnas: 'Razon social','Direccion','Provincia','Cuil','Calle','Localidad','Codigo postal','Habilitado'
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado</returns>
        public List<Proveedor> RecuperarTodosLosProveedores()
        {
            _proveedores.Clear();
            DataTable proveedores = ObjProveedor.ListaProveedores();
            if (proveedores == null)
            {
                throw new NoEncontrado();

            }
            foreach (DataRow row in proveedores.Rows)//carga lo de data table a row(que es un data row)
            {
                _proveedores.Add(ConvertirProveedor(row));//se agrega a ListaProducto un producto
            }
            return _proveedores;
        }
        /// <summary>
        /// columnas: 'Razon social','Direccion','Provincia','Cuil','Calle','Localidad','Codigo postal','Habilitado'
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado</returns>
        public List<Proveedor> RecuperarProveedoresHabilitados()
        {
            _proveedores.Clear();
            DataTable proveedores = ObjProveedor.ListaProveedoresHabilitados();
            if (proveedores == null)
            {
                throw new NoEncontrado();

            }
            foreach (DataRow row in proveedores.Rows)//carga lo de data table a row(que es un data row)
            {
                _proveedores.Add(ConvertirProveedor(row));//se agrega a ListaProducto un producto
            }
            return _proveedores;
        }
        /// <summary>
        /// columnas: 'Razon social','Direccion','Provincia','Cuil','Calle','Localidad','Codigo postal','Habilitado'
        /// </summary>
        /// <param name="provincia"></param>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public List<Proveedor> RecuperarProveedoresPorProvincia(string provincia)
        {
            try
            {
                _proveedores.Clear();
                DataTable proveedores = ObjProveedor.ListaProveedoresPorProvincia(provincia);
                if (proveedores == null)
                {
                    throw new NoEncontrado();

                }
                foreach (DataRow row in proveedores.Rows)//carga lo de data table a row(que es un data row)
                {
                    _proveedores.Add(ConvertirProveedor(row));//se agrega a ListaProducto un producto
                }
                return _proveedores;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return _proveedores;
            }
        }
        #endregion

        /// <summary>
        /// columnas: 'Razon social','Direccion','Provincia','Cuil','Calle','Localidad','Codigo postal','Habilitado'
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado</returns>
        public DataTable UltimoProveedor()
        {
            DataTable dt = ObjProveedor.UltimoProveedor();
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
    }
}
