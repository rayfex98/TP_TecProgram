using System;
using System.Data;
using Datos;
using Entidades;

namespace Negocio
{
    public class NProveedor 
    {
        Proveedor ObjProveedor = new Proveedor();

        public string Nuevo()
        {
            return ObjProveedor.Nuevo(ObjProveedor);
        }
        public string Editar()
        {
            return ObjProveedor.Editar(ObjProveedor);
        }
        public string Eliminar(string idProveedor)
        {
            ObjProveedor.Cuil = idProveedor;
            return ObjProveedor.Eliminar(ObjProveedor);
        }
        public int ID_Proveedor()
        {
            return ObjProveedor.Cuil();
        }
    }
}
