using System;
using System.Collections.Generic;
using System.Data;
using Entidades;
using ExcepcionesControladas;

namespace ddl_modulo
{
    public class DProveedor
    {
        List<Proveedor> proveedores;
        DataTable dt = new DataTable();
        Conexion db = new Conexion();
        public Proveedor cargarObj(object[] obj)
        {
            string query = string.Format("SELECT [IDPROVEEDOR], [CUIL], [RAZONSOCIAL], [ALTURA], [CALLE], [CODIGOPOSTAL], [LOCALIDAD], [PROVINCIA]" +
            "FROM[DBO].[PROVEEDOR] AS P INNER JOIN[DBO].[DIRECCION] AS D ON P.IDDIRECCION = D.IDDIRECCION WHERE ID = {0}", obj[0]);
            dt = db.LeerPorComando(query);
            Proveedor unProveedor = new Proveedor();
            unProveedor.ID = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            unProveedor.CUIL = dt.Rows[1].ItemArray.ToString();
            unProveedor.RazonSocial = dt.Rows[2].ItemArray.ToString();
            unProveedor.Direccion.Altura = dt.Rows[3].ItemArray.ToString();
            unProveedor.Direccion.Calle = dt.Rows[4].ItemArray.ToString();
            unProveedor.Direccion.CodigoPostal = dt.Rows[4].ItemArray.ToString();
            unProveedor.Direccion.Localidad = dt.Rows[4].ItemArray.ToString();
            unProveedor.Direccion.Provincia = dt.Rows[4].ItemArray.ToString();
            return unProveedor;
        }
        public bool Nuevo(Proveedor ObjProveedor)
        {
            try
            {
                string query = string.Format("EXEC PROVEEDORPROC @ID=NULL,@DIRECCION={0},@CUIL={1},@RAZONSOCIAL={2},@HABILITADO = {3},@TIPO = 'INSERT';"
                        , ObjProveedor.Direccion.ID, ObjProveedor.CUIL, ObjProveedor.RazonSocial, DateTime.Now);
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
        }
        public bool Editar(Proveedor ObjProveedor)
        {
            try
            {
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

        public List<Proveedor> ListadeProveedores()
        {
            string query = string.Format("EXEC PROVEEDORPROC @ID=NULL,@DIRECCION=NULL,@CUIL=NULL,@RAZONSOCIAL=NULL,@HABILITADO = NULL,@TIPO = 'SELECTALL';");
            dt = db.LeerPorComando(query);
            foreach (DataRow item in dt.Rows)
            {
                proveedores.Add(cargarObj(item.ItemArray));
            }

            return proveedores;
        }
    }
}
