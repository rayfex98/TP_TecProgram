using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class DStock
    {
        DataTable dt = new DataTable();
        readonly Conexion db = new Conexion();
        public bool CargarProductoEnStock(Stock unStock)
        {
            try
            {
                string query = string.Format("STOCKPROC @ID=null,@PRODUCTO={0},@CANTIDAD={1},@HABILITADO = null,@TIPO='INSERT';", unStock.Producto.ID, unStock.Cantidad);
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
                string query = string.Format("STOCKPROC @ID={0},@PRODUCTO=null,@CANTIDAD=null,@HABILITADO = null,@TIPO='DELETE';", idProducto);
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
                string query = string.Format("exec sumarstock @ID = {0} , @cantidad= {1};", ID_producto, cantidad);
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
        public bool RestarStock(int ID_producto, int cantidad)
        {
            try
            {
                string query = string.Format("exec restarstock @ID = {0} , @cantidad= {1};", ID_producto, cantidad);
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
        public DataTable ListarStockVista()
        {
            string query = string.Format("vista_stock");
            dt = db.LeerPorComando(query);
            //busco en tabla
            return dt;
        }
    }
}
