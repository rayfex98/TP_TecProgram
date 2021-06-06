using System;
using System.Collections.Generic;
using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
{
    public class NProveedor
    {
        private List<Proveedor> proveedores;
        DProveedor ObjProveedor = new DProveedor();
        //Metodo que carga lista proveedores

        #region MetodosPrivados
        private int Nuevo(Proveedor _proveedor)
        {
            return ObjProveedor.Nuevo(_proveedor);
        }
        private bool Editar(Proveedor _proveedor)
        {
            return ObjProveedor.Editar(_proveedor);
        }
        private bool Estado(int id, DateTime? hoy)
        {
            return ObjProveedor.Estado(id, hoy);
        }
        private bool ID_Proveedor(int id, string cuil) //metodo propio, busca filtro en una lista de proveedores
        {
            //if(id == -1) Busqueda por cuil, else busqueda por id
            //recorre lista y busca id, cuando lo encuentre, retorno true, si no lo encuentra, retorna false
            return true; 
        }
        #endregion

        #region Listar
        /// <summary>
        /// Puede ser todos los proveedores o necesito parametro de filtro proveedores habilitados, deshabilitados(borrado logico), o por cuit
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public DataTable ListarProveedores(string filtro)
        {
            if (string.Compare(filtro, "TODOS") == 0)
            {
                return ObjProveedor.ListadeProveedores(filtro);
            }
            DataTable dt = new DataTable();
            filtro.ToUpper();
            if (string.Compare(filtro, "CUIL") == 0)
            {
                foreach (Proveedor prov in proveedores)
                {

                }
                //busco en lista y cargo al dt
            }
            else if (string.Compare(filtro, "DESHABILITADO") == 0)
            {
                foreach (Proveedor prov in proveedores)
                {

                }
                //busco en lista y cargo al dt
            }
            else if (string.Compare(filtro, "HABILITADO") == 0)
            {
                foreach (Proveedor prov in proveedores)
                {

                }
                //busco en lista y cargo al dt
            }
            return dt;
        }
        #endregion

        #region Alta
        /// <summary>
        /// Requiero una direccion o su id. Tambien string(13) cuil y string(30) razon social 
        /// </summary>
        /// <returns></returns>
        public bool AltaProveedor(Proveedor obj)
        {
            if (ID_Proveedor(-1, obj.CUIL))
                if (Nuevo(obj) != -1)
                {
                    //Agregar en lista
                    return true;
                }
            return false;
        }
        #endregion

        #region Estado
        /// <summary>
        /// Permite hacer un "borrado logico". Deshabilitado  o habilitado mediante el id
        /// </summary>
        /// <returns></returns>
        public bool EstadoProveedor(int ID, bool opcion)//opcion es alta o baja
        {
            if (ID_Proveedor(ID, "")) //busco en lista por id
            {
                DateTime? hoy = null;
                if (opcion) //para alta necesito fecha actual
                {
                    hoy = DateTime.Now;
                }
                if (opcion && Estado(ID, hoy))
                {
                    //Dar de alta en lista
                    return true;
                }
                else if(Estado(ID, hoy))
                {
                    //Dar de baja en lista
                    return true;
                }
            }
            return false;
        }
        #endregion

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

    }
}
