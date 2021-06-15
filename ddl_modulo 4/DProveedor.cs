using System;
using System.Collections.Generic;
using System.Data;
using Entidades;
using ExcepcionesControladas;

namespace ddl_modulo
{
    public class DProveedor
    {
        DataTable dt = new DataTable();
        Conexion db = new Conexion();
        
        public bool Nuevo(Proveedor ObjProveedor)
        {
            try
            {
                DDireccion dir = new DDireccion();
                if (dir.Nuevo(ObjProveedor.Direccion))
                {
                    ObjProveedor.Direccion.ID = dir.RecuperarUltimoID();
                    string query = string.Format("EXEC PROVEEDORPROC @ID=NULL,@DIRECCION={0},@CUIL={1},@RAZONSOCIAL={2},@HABILITADO = {3},@TIPO = 'INSERT';"
                            , ObjProveedor.Direccion.ID, ObjProveedor.CUIL, ObjProveedor.RazonSocial, DateTime.Now);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                    return true;
                }
                return false;
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

        public Proveedor cargarObj(object[] obj)
        {
            string query = string.Format("SELECT [id_proveedor], [cuil], [razonsocial], [altura], [calle], [codigo_postal], [localidad], [provincia]" +
            "FROM[dbo].[proveedor] AS P INNER JOIN[dbo].[direccion] AS D ON P.id_direccion = D.id_direccion WHERE ID = {0}", obj[0]);
            dt = db.LeerPorComando(query);
            Proveedor unProveedor = new Proveedor();
            unProveedor.ID = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            unProveedor.CUIL = dt.Rows[0].ItemArray[2].ToString();
            unProveedor.RazonSocial = dt.Rows[0].ItemArray[3].ToString();
            unProveedor.Direccion.Altura = dt.Rows[0].ItemArray[4].ToString();
            unProveedor.Direccion.Calle = dt.Rows[0].ItemArray[5].ToString();
            unProveedor.Direccion.CodigoPostal = dt.Rows[0].ItemArray[6].ToString();
            unProveedor.Direccion.Localidad = dt.Rows[0].ItemArray[7].ToString();
            unProveedor.Direccion.Provincia = dt.Rows[0].ItemArray[8].ToString();
            return unProveedor;
        }

        public List<Proveedor> ListadeProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            string query = string.Format("EXEC PROVEEDORPROC @ID=NULL,@DIRECCION=NULL,@CUIL=NULL,@RAZONSOCIAL=NULL,@HABILITADO = NULL,@TIPO = 'SELECT';");
            dt = db.LeerPorComando(query);
            foreach (DataRow item in dt.Rows)
            {
                proveedores.Add(cargarObj(item.ItemArray));
            }
            return proveedores;
        }

        public int RecuperarUltimoID()
        {
            int id;
            string query = string.Format("SELECT MAX(id_proveedor) FROM [dbo].[proveedor]");
            dt = db.LeerPorComando(query);
            id = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            return id;
        }
    }
}
