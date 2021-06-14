using Entidades;
using System.Data;
using ExcepcionesControladas;
using System.Collections.Generic;
using System;

namespace ddl_modulo
{
    public class DStock
    {
        List<Stock> stocks;
        DataTable dt = new DataTable();
        Conexion db = new Conexion();
        public bool CargarProductoEnStock(Stock unStock)
        {
            try
            {
                string query = string.Format("EXEC STOCKPROC @ID=null,@PRODUCTO={0},@CANTIDAD={1},@HABILITADO = null,@TIPO='INSERT';", unStock.Producto.ID, unStock.Cantidad);
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
                if (!ID_Stock(unStock.ID))
                {
                    string query = string.Format("EXEC STOCKPROC @ID = {0},@PRODUCTO = {1} ,@CANTIDAD = null,@HABILITADO =null,@TIPO ='UPDATE';", unStock.ID, unStock.Producto.ID);
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
        public bool EliminarStock(int idProducto)
        {
            try
            {
                if (ID_Stock(idProducto))
                {
                    string query = string.Format("EXEC STOCKPROC @ID={0},@PRODUCTO=null,@CANTIDAD=null,@HABILITADO = null,@TIPO='DELETE';", idProducto);
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
        public bool ID_Stock(int idStock)
        {
            try
            {
                string query;
                query = string.Format("EXEC STOCKPROC @ID={0},@PRODUCTO=NULL,@CANTIDAD=NULL,@TIPO = 'SELECTONE';", idStock);
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
        public bool RestarStock (int ID_producto, int cantidad)
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
        public Stock cargarObj(object[] obj)
        {
            string query = string.Format("SELECT IDSTOCK, IDPRODUCTO, CANTIDAD" +
                        "FROM [dbo].[STOCK] where IDSTOCK = {0}", obj[0]);
            dt = db.LeerPorComando(query);
            Stock unStock = new Stock();
            unStock.ID = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            unStock.Producto.ID = int.Parse(dt.Rows[0].ItemArray[1].ToString());
            unStock.Cantidad = int.Parse(dt.Rows[0].ItemArray[2].ToString());
            return unStock;
        }
        public List<Stock> ListadoStock()
        {
            string query = string.Format("EXEC STOCKPROC @ID=null,@PRODUCTO=null,@CANTIDAD=null,@HABILITADO = null,@TIPO='SELECT' ;");
            dt = db.LeerPorComando(query);
            foreach (DataRow item in dt.Rows)
            {
                stocks.Add(cargarObj(item.ItemArray));
            }

            return stocks;
        }

    }

}


