using DAL;
using Entidades;
using System;
using System.Data;

namespace BLL
{
    public class NProveedor
    {
        DProveedor ObjProveedor = new DProveedor();
        //Metodo que carga lista proveedores

        public bool Nuevo(Proveedor _proveedor)
        {
            return ObjProveedor.Nuevo(_proveedor);
        }
        public bool Editar(Proveedor _proveedor)
        {
            return ObjProveedor.Editar(_proveedor);
        }
        public bool Estado(int id, DateTime? hoy)
        {
            return ObjProveedor.Estado(id, hoy);
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

        #region listaProvedorespordatatable
        public DataTable listarproveedores()
        {
            return ObjProveedor.ListaProveedores();
        }
        #endregion


        public DataTable ListarProveedoresPorProvincia(string provincia)
        {
            return ObjProveedor.ListaProveedoresPorProvincia(provincia);
        }
    }
}
