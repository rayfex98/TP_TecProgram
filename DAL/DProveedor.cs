using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class DProveedor
    {
        readonly Conexion db = new Conexion();
        DataTable dt = new DataTable();
        public bool Nuevo(Proveedor ObjProveedor)
        {
                string query = string.Format("EXEC PROVEEDORPROC @ID=NULL,@DIRECCION={0},@CUIL={1},@RAZONSOCIAL={2},@HABILITADO = null,@TIPO = 'INSERT';"
                        , ObjProveedor.Direccion.ID, ObjProveedor.CUIL, ObjProveedor.RazonSocial);
                if (1 != db.EscribirPorComando(query))
                {
                    return false;
                }
                return true;
        }
        public bool Editar(Proveedor ObjProveedor)
        {
            try
            {
                string query = string.Format("EXEC PROVEEDORPROC @ID={0},@DIRECCION={1},@CUIL={2},@RAZONSOCIAL={3},@HABILITADO = NULL,@TIPO = 'UPDATE';"
                            , ObjProveedor.ID, ObjProveedor.Direccion.ID, ObjProveedor.CUIL, ObjProveedor.RazonSocial);
                if (1 != db.EscribirPorComando(query))
                {
                    return false;
                }
                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
            catch (System.NullReferenceException)
            {
                return false;
            }
        }
        public bool habilitar(Proveedor unproveedor)
        {
            try
            {
                string query = string.Format("EXEC PROVEEDORPROC @ID={0},@DIRECCION=NULL,@CUIL=NULL,@RAZONSOCIAL=NULL,@HABILITADO = null,@TIPO = 'HABILITAR';", unproveedor.ID);
                if (1 != db.EscribirPorComando(query))
                {
                    return false;
                }
                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
            catch (System.NullReferenceException)
            {
                return false;
            }
        }


        public DataTable ListaProveedores()
        {
            string query = string.Format("ListaProveedores");
            dt = db.LeerPorComando(query);
            //busco en tabla
            return dt;

        }
        public DataTable ListaProveedoresPorProvincia(string Provincia)
        {
            string query = string.Format("exec BuscarProveedorProvincia @provincia= {0};",Provincia);
            dt = db.LeerPorComando(query);
            return dt;

        }
        public DataTable ListaProveedoreshabilitados()
        {
            string query = string.Format("ListaProveedoresHabilitados");
            dt = db.LeerPorComando(query);
            //busco en tabla
            return dt;

        }


    }
}
