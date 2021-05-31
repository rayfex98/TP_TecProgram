using System.Data;
using Entidades;
using ExcepcionesControladas;

namespace ddl_modulo
{
    public class DProveedor
    {
        public bool Nuevo(Proveedor ObjProveedor)
        {
            try
            {
                Conexion db = new Conexion();
                if (!ID_Proveedor(false, -1, int.Parse(ObjProveedor.CUIL)))
                {
                    string query = string.Format("EXEC PROVEEDORPROC @ID=NULL,@DIRECCION={0},@CUIL={1},@RAZONSOCIAL={2},@TIPO = 'INSERT';"
                        , ObjProveedor.Direccion, ObjProveedor.CUIL, ObjProveedor.RazonSocial);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }
        public bool Editar(Proveedor ObjProveedor)
        {
            try
            {
                Conexion db = new Conexion();
                if (!ID_Proveedor(true, ObjProveedor.ID, -1))
                {
                    if (!ID_Proveedor(false, -1, int.Parse(ObjProveedor.CUIL)))
                    {
                        string query = string.Format("EXEC PROVEEDORPROC @ID={0},@DIRECCION={1},@CUIL={2},@RAZONSOCIAL={3},@TIPO = 'UPDATE';"
                            , ObjProveedor.ID, ObjProveedor.Direccion, ObjProveedor.CUIL, ObjProveedor.RazonSocial);
                        if (1 != db.EscribirPorComando(query))
                        {
                            return false;
                        }
                        return true;
                    }
                }
                return false;
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
        public bool Eliminar(Proveedor ObjProveedor)
        {
            try
            {
                Conexion db = new Conexion();
                if (ID_Proveedor(true, ObjProveedor.ID, int.Parse(ObjProveedor.CUIL)))
                {
                    string query = string.Format("EXEC PROVEEDORPROC @ID={0},@DIRECCION=NULL,@CUIL=NULL,@RAZONSOCIAL=NULL,@TIPO = 'DELETE';", ObjProveedor.ID);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
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
        public bool ID_Proveedor(bool metodo, int id, int cuil)
        {
            try
            {
                Conexion db = new Conexion();
                string query;
                if (metodo == true)
                {
                    query = string.Format("EXEC PROVEEDORPROC @ID={0},@DIRECCION=NULL,@CUIL=NULL,@RAZONSOCIAL=NULL,@TIPO = 'SELECTONE';", id);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                }
                else
                {
                    query = string.Format("EXEC PROVEEDORPROC @ID=NULL,@DIRECCION=NULL,@CUIL={0},@RAZONSOCIAL=NULL,@TIPO = 'SELECTID';", cuil);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
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

        public DataTable ListadeProveedores()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}
