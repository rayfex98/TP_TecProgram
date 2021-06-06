using System;
using System.Data;
using Entidades;
using ExcepcionesControladas;

namespace ddl_modulo
{
    public class DProveedor
    {
        public int Nuevo(Proveedor ObjProveedor)
        {
            ObjProveedor.ID = -1;
            try
            {
                Conexion db = new Conexion();
                string query = string.Format("EXEC PROVEEDORPROC @ID=NULL,@DIRECCION={0},@CUIL={1},@RAZONSOCIAL={2},@HABILITADO = {3},@TIPO = 'INSERT';"
                        , ObjProveedor.Direccion.ID, ObjProveedor.CUIL, ObjProveedor.RazonSocial, DateTime.Now);
                if (1 != db.EscribirPorComando(query))
                {
                    return ObjProveedor.ID;
                }
                //query = string.Format("SELECT MAX([IDPROVEEDOR]) FROM [dbo].[PROVEEDOR]");
                //llamdo a bbdd y guardar el id que devuelva
                return ObjProveedor.ID;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return ObjProveedor.ID;
            }
        }
        public bool Editar(Proveedor ObjProveedor)
        {
            try
            {
                Conexion db = new Conexion();
                string query = string.Format("EXEC PROVEEDORPROC @ID={0},@DIRECCION={1},@CUIL={2},@RAZONSOCIAL={3},@HABILITADO = NULL,@TIPO = 'UPDATE';"
                            , ObjProveedor.ID, ObjProveedor.Direccion, ObjProveedor.CUIL, ObjProveedor.RazonSocial);
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
        public bool Estado(int id, DateTime? hoy)
        {
            try
            {
                Conexion db = new Conexion();
                string query = string.Format("EXEC PROVEEDORPROC @ID={0},@DIRECCION=NULL,@CUIL=NULL,@RAZONSOCIAL=NULL,@HABILITADO = {1},@TIPO = 'ESTADO';", id, hoy);
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
        
        public DataTable ListadeProveedores(string filtro)
        {
            DataTable dt = new DataTable();
            //busco en tabla los que coincidan
            return dt;
        }
    }
}
