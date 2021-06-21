using DAL;
using Entidades;
using System;
using System.Data;

namespace BLL
{
    public class NProveedor
    {
        DProveedor ObjProveedor = new DProveedor();

        public bool Nuevo(Proveedor _proveedor)
        {
            return ObjProveedor.Nuevo(_proveedor);
        }
        public bool Editar(Proveedor _proveedor)
        {
            return ObjProveedor.Editar(_proveedor);
        }
        public bool Habilitar(int id)
        {
            return ObjProveedor.Estado(id,true);
        }
        public bool Deshabilitar(int id)
        {
            return ObjProveedor.Estado(id,false);
        }

        #region Modificar
        /// <summary>
        /// Update, necesito una direccion o su id. Tambien CUIL string(13) y razon social string(30)
        /// </summary>
        /// <returns></returns>
        public bool ModificarProveedor(int id, Proveedor obj)
        {
            if (id < 0) return false; //llamar a listar. Ver si ID se encuentra y CUIL no se encuentran en lista de productos
            //ver si agrego o no la direccion a la bbdd antes de modificarla
            if (Editar(obj))
            {
                //modificar en lista
                return true;
            }
            return false;
        }
        #endregion

        #region listaProvedores
        public DataTable DataTableProveedores()
        {
            return ObjProveedor.ListaProveedores();
        }
        #endregion
        
        public DataTable ListarProveedoresHabilitados()
        {
            return ObjProveedor.ListaProveedoresHabilitados();
        }

        public DataTable ListarProveedoresPorProvincia(string provincia)
        {
            return ObjProveedor.ListaProveedoresPorProvincia(provincia);
        }
    }
}
