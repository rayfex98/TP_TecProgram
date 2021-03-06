using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DOrdenCompra
    {
        readonly Conexion db = new Conexion();
        DataTable dt = new DataTable();
        public bool NuevoOrden(OrdenDeCompra unOrdenCompra)
        {
            try
            {
                SqlParameter[] parametros =
                    {
                        new SqlParameter("@ID",SqlDbType.Int),
                        new SqlParameter("@PROVEEDOR",SqlDbType.Int),
                        new SqlParameter("@TIPO",SqlDbType.NVarChar),
                        new SqlParameter("@FECHA",SqlDbType.DateTime),
                        new SqlParameter("@USUARIO",SqlDbType.Int)
                    };
                parametros[0].Value = unOrdenCompra.ID;
                parametros[1].Value = unOrdenCompra.Proveedor.ID;
                parametros[2].Value = "INSERT";
                parametros[3].Value = System.DateTime.Now;
                parametros[4].Value = 0;
                if (db.EscribirPorStoreProcedure("ORDENCOMPRAPROC", parametros) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }
        public bool EditarOrden(OrdenDeCompra unOrdenCompra)
        {
            try
            {
                unOrdenCompra.FechaAprobacion = DateTime.Now;
                string query = string.Format("EXEC ORDENCOMPRAPROC @ID={0},@PROVEEDOR={1},@USUARIO={2},@FECHA={3},@TIPO = 'UPDATE';"
                    , unOrdenCompra.ID, unOrdenCompra.Proveedor.ID, unOrdenCompra.UsuarioAprobador.ID, unOrdenCompra.FechaAprobacion);
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
        public bool EliminarOrden(int idOrden)
        {
            try
            {
                string query = string.Format("EXEC ORDENCOMPRAPROC @ID={0},@PROVEEDOR=NULL,@USUARIO=NULL,@FECHA=NULL,@TIPO = 'DELETE';", idOrden);
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

        public DataTable ListadeOrdenCompra()
        {
            string query = string.Format("SELECT DISTINCT OC.id_orden as 'Orden', U.nombre + ' ' + U.apellido as 'Creador', O.fecha as 'Creacion', " +
                "OC.id_persona as 'Aprobador', OC.fecha_aprobacion as 'Fecha Aprobacion', P.razonsocial as 'Proveedor' from dbo.orden_compra AS OC " +
                "inner join dbo.orden as O on O.id = OC.id_orden inner join dbo.persona as U on O.id_persona = U.id inner join dbo.proveedor as P on OC.id_proveedor = P.id_proveedor");
            dt = db.LeerPorComando(query);
            return dt;
        }
        public DataTable OrdenPendiente()
        {
            string query = string.Format("SELECT DISTINCT OC.id_orden as 'Orden', U.nombre + ' ' + U.apellido as 'Creador', O.fecha as 'Creacion', " +
                "OC.id_persona as 'Aprobador', OC.fecha_aprobacion as 'Fecha Aprobacion', P.razonsocial as 'Proveedor' from dbo.orden_compra AS OC " +
                "inner join dbo.orden as O on O.id = OC.id_orden inner join dbo.persona as U on O.id_persona = U.id inner join dbo.proveedor as P on OC.id_proveedor = P.id_proveedor " +
                "WHERE fecha_aprobacion is null");
            dt = db.LeerPorComando(query);
            return dt;

        }
        public bool AprobarOrden(int id_orden, int id_usuario)
        {
            try
            {
                SqlParameter[] parametros =
                    {
                        new SqlParameter("@ID",SqlDbType.Int),
                        new SqlParameter("@PROVEEDOR",SqlDbType.Int),
                        new SqlParameter("@TIPO",SqlDbType.NVarChar),
                        new SqlParameter("@FECHA",SqlDbType.DateTime),
                        new SqlParameter("@USUARIO",SqlDbType.Int)
                    };
                parametros[0].Value = id_orden;
                parametros[1].Value = 0;
                parametros[2].Value = "APROBAR";
                parametros[3].Value = System.DateTime.Now;
                parametros[4].Value = id_usuario;
                if (db.EscribirPorStoreProcedure("ORDENCOMPRAPROC", parametros) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }
        }
        public DataTable CalcularTotal(int idOrden)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@orden",SqlDbType.Int)
            };
            parametros[0].Value = idOrden;
            dt = db.LeerPorStoreProcedure("sumartotalorden", parametros);
            return dt;
        }
        public DataTable ListaPorProducto(string nombre)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@producto",SqlDbType.VarChar)

            };
            parametros[0].Value = nombre;
            dt = db.LeerPorStoreProcedure("OrdenCompraBuscarProducto", parametros);
            return dt;
        }
        public DataTable ListaPorProveedor(string razonSocial)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@proveedor",SqlDbType.VarChar)
            };
            parametros[0].Value = razonSocial;
            dt = db.LeerPorStoreProcedure("OrdenCompraBuscarProveedor", parametros);
            return dt;
        }
    }
}
