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
                DOrden ord = new DOrden();
                Orden nueva = new Orden
                {
                    UsuarioCreador = unOrdenCompra.UsuarioCreador
                };
                if (ord.Nuevo(nueva))
                {
                    int id_orden = ord.UltimaOrden();
                    if (id_orden == -1)
                    {
                        return false;
                    }
                    unOrdenCompra.FechaAprobacion = DateTime.Now;
                    string query = string.Format("EXEC ORDENCOMPRAPROC @ID={0},@PROVEEDOR={1},@USUARIO=NULL,@FECHA=NULL cast(@FECHA as datetime),@TIPO = 'INSERT';"
                    , id_orden, unOrdenCompra.Proveedor.ID);
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
            string query = string.Format("OrdenCompraVista");
            dt = db.LeerPorComando(query);
            return dt;
        }
        public DataTable OrdenPendiente()
        {
            string query = string.Format("OrdenCompraPendientes");
            dt = db.LeerPorComando(query);
            return dt;

        }
        public bool AprobarOrden(int id_orden, int id_usuario)
        {
            try
            {
                string query = string.Format("EXEC ORDENCOMPRAPROC @ID={0},@PROVEEDOR=null,@USUARIO={1},@FECHA=null,@TIPO = 'APROBAR';"
                , id_orden, id_usuario);
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
        public DataTable CalcularTotal(int idOrden)
        {
            string query = string.Format("exec sumartotalorden @orden= {0};", idOrden);
            dt = db.LeerPorComando(query);
            return dt;
        }
        public DataTable ListaPorProducto(string nombre)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@producto",SqlDbType.NVarChar)

            };
            parametros[0].Value = nombre;
            dt = db.LeerPorStoreProcedure("leer_compra_por_producto", parametros);
            return dt;
        }
        public DataTable ListaPorProveedor(string nombre)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@proveedor",SqlDbType.NVarChar)
            };
            parametros[0].Value = nombre;
            dt = db.LeerPorStoreProcedure("leer_compra_por_proveedor", parametros);
            return dt;
        }
    }
}
