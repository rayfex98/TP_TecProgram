using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DProveedor
    {
        readonly Conexion db = new Conexion();
        DataTable dt = new DataTable();
        public bool Nuevo(Proveedor ObjProveedor)
        {
            try
            {
                DDireccion nueva = new DDireccion();
                Direccion dir = new Direccion 
                {
                    Calle = ObjProveedor.Direccion.Calle,
                    Altura = ObjProveedor.Direccion.Altura,
                    Localidad = ObjProveedor.Direccion.Localidad,
                    CodigoPostal = ObjProveedor.Direccion.CodigoPostal,
                    Provincia = ObjProveedor.Direccion.Provincia
                };
                if (nueva.Nuevo(dir))
                {
                    ObjProveedor.Direccion.ID = nueva.UltimaDireccion();
                    if (ObjProveedor.Direccion.ID == -1)
                    {
                        return false;
                    }
                    SqlParameter[] parametros =
                    {
                        new SqlParameter("@DIRECCION",SqlDbType.Int),
                        new SqlParameter("@CUIL",SqlDbType.NVarChar),
                        new SqlParameter("@RAZONSOCIAL",SqlDbType.NVarChar),
                        new SqlParameter("@TIPO",SqlDbType.NVarChar)
                    };
                    parametros[0].Value = ObjProveedor.Direccion.ID;
                    parametros[1].Value = ObjProveedor.CUIL;
                    parametros[2].Value = ObjProveedor.RazonSocial;
                    parametros[3].Value = "INSERT";
                    if (db.EscribirPorStoreProcedure("PROVEEDORPROC", parametros) > 0)
                    {
                        return true;
                    }
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
        public bool Estado(int id, bool opcion)
        {
            try
            {
                string query;
                if (opcion)
                {
                    query = string.Format("EXEC PROVEEDORPROC @ID={0},@DIRECCION=NULL,@CUIL=NULL,@RAZONSOCIAL=NULL,@HABILITADO = NULL,@TIPO = 'HABILITAR';", id);
                }
                else
                {
                    query = string.Format("EXEC PROVEEDORPROC @ID={0},@DIRECCION=NULL,@CUIL=NULL,@RAZONSOCIAL=NULL,@HABILITADO = NULL,@TIPO = 'DESHABILITAR';", id);
                }
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
            return dt;
        }
        public DataTable ListaProveedoresPorProvincia(string Provincia)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@provincia",SqlDbType.NVarChar)
            };
            parametros[0].Value = Provincia;
            dt = db.LeerPorStoreProcedure("BuscarProveedorProvincia", parametros);
            return dt;
        }
        public DataTable ListaProveedoresHabilitados()
        {
            string query = string.Format("ListaProveedoresHabilitados");
            dt = db.LeerPorComando(query);
            return dt;
        }
        public DataTable UltimoProveedor()
        {
            string query = string.Format("UltimoProveedor");
            dt = db.LeerPorComando(query);
            return dt;
        }
    }
}
