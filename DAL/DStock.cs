using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DStock
    {
        readonly Conexion db = new Conexion();
        public bool CargarProductoEnStock(Stock unStock)
        {
            try
            {
                SqlParameter[] parametros =
                {
                    new SqlParameter("@ID",SqlDbType.Int),
                    new SqlParameter("@PRODUCTO",SqlDbType.Int),
                    new SqlParameter("@CANTIDAD",SqlDbType.Int),
                    new SqlParameter("@HABILITADO",SqlDbType.DateTime),
                    new SqlParameter("@TIPO",SqlDbType.NVarChar)
                };
                parametros[0].Value = 0;
                parametros[1].Value = unStock.Producto.ID;
                parametros[2].Value = unStock.Cantidad;
                parametros[3].Value = System.DateTime.Now;
                parametros[4].Value = "INSERT";
                if (1 != db.EscribirPorStoreProcedure("STOCKPROC", parametros))
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
        public bool EditarStock(Stock unStock)
        {
            try
            {
                string query = string.Format("EXEC STOCKPROC @ID = {0},@PRODUCTO = {1} ,@CANTIDAD = null,@HABILITADO =null,@TIPO ='UPDATE';", unStock.ID, unStock.Producto.ID);
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
        public bool EliminarStock(int idProducto)
        {
            try
            {
                string query = string.Format("EXEC STOCKPROC @ID={0},@PRODUCTO=null,@CANTIDAD=null,@HABILITADO = null,@TIPO='DELETE';", idProducto);
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

        public bool AgregarStock(int ID_producto, int cantidad)
        {
            try
            {
                SqlParameter[] parametros =
                {
                    new SqlParameter("@ID",SqlDbType.Int),
                    new SqlParameter("@cantidad",SqlDbType.Int)
                };
                parametros[0].Value = ID_producto;
                parametros[1].Value = cantidad;
                if (1 != db.EscribirPorStoreProcedure("sumarstock", parametros))
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

        public bool RestarStock(int ID_producto, int cantidad)
        {
            try
            {
                SqlParameter[] parametros =
                {
                    new SqlParameter("@ID",SqlDbType.Int),
                    new SqlParameter("@cantidad",SqlDbType.Int)
                };
                parametros[0].Value = ID_producto;
                parametros[1].Value = cantidad;
                if (1 != db.EscribirPorStoreProcedure("restarstock", parametros))
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
    }
}
