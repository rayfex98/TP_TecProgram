using Entidades;
using System.Data;
using ExcepcionesControladas;
using System.Collections.Generic;

namespace ddl_modulo
{
    public class DStock
    {
        List<Stock> stocks;
        DataTable dt = new DataTable();
        Conexion db = new Conexion();
        public bool Nuevo(Stock unStock)
        {
            try
            {
                string query = string.Format("EXEC STOCKPROC @ID=NULL,@PRODUCTO={0},@CANTIDAD={1},@TIPO = 'INSERT';", unStock.Producto.ID, unStock.Cantidad);
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
        public bool Editar(Stock unStock)
        {
            try
            {
                if (!ID_Stock(unStock.ID))
                {
                    string query = string.Format("EXEC STOCKPROC @ID={0},@PRODUCTO={1},@CANTIDAD=null ,@TIPO = 'UPDATE';", unStock.ID, unStock.Producto.ID);
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
            catch (System.NullReferenceException)
            {
                return false;
            }
        }
        public bool Eliminar(int idProducto)
        {
            try
            {
                if (ID_Stock(idProducto))
                {
                    string query = string.Format("EXEC STOCKPROC @ID={0},@PRODUCTO=NULL,@CANTIDAD=NULL,@TIPO = 'DELETE';", idProducto);
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

        //public List<Stock> AgregarStock(int ID_producto, int cantidad)
        public bool AgregarStock(int ID_producto, int cantidad)
        {
            DataTable ListaStock = new DataTable();
            Producto product = new Producto();

            string query = string.Format("exec sumarstock @ID = {0} , @cantidad= {1};", ID_producto, cantidad);
            ListaStock = db.LeerPorComando(query);

            foreach (DataRow item in ListaStock.Rows)
            {
                ID_producto = int.Parse(item.ItemArray[0].ToString());

                stocks.Add(new Stock()
                {
                    Producto = product,
                    Cantidad = int.Parse(item.ItemArray[2].ToString())
                });
            }

            return true;
        }
        public List<Stock> RestarStock (int ID_producto, int cantidad)
        {
            DataTable ListaStock = new DataTable();
            Producto product = new Producto();

            string query = string.Format("exec restarstock @ID = {0} , @cantidad= {1};", ID_producto, cantidad);
            ListaStock = db.LeerPorComando(query);

            foreach (DataRow item in ListaStock.Rows)
            {
                ID_producto = int.Parse(item.ItemArray[0].ToString());

                stocks.Add(new Stock()
                {
                    Producto = product,
                    Cantidad = int.Parse(item.ItemArray[2].ToString())
                });
            }

            return stocks;
        }
        public Stock cargarObj(object[] obj)
        {

            // string query = string.Format("SELECT [IDSTOCK], [CANTIDAD], [NOMBRE]" +
            //   "FROM [DBO].[STOCK] AS S INNER JOIN[DBO].[PRODUCTO] AS P ON S.IDPRODUCTO = P.IDPRODUCTO WHERE IDSTOCK = {0}", obj[0]);
            string query = string.Format("SELECT IDSTOCK, IDPRODUCTO, CANTIDAD" +
                        "FROM [dbo].[STOCK] where IDSTOCK = {0}", obj[0]);
            dt = db.LeerPorComando(query);
            Stock unStock = new Stock();
            unStock.ID = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            unStock.Producto.ID = int.Parse(dt.Rows[1].ItemArray[0].ToString());
            unStock.Cantidad = int.Parse(dt.Rows[2].ItemArray[0].ToString());
            return unStock;
        }
        public List<Stock> ListadoStock()
        {
            string query = string.Format("EXEC STOCKPROC @ID=NULL,@PRODUCTO=NULL,@CANTIDAD=NULL,@TIPO = 'SELECTALL';");
            dt = db.LeerPorComando(query);
            foreach (DataRow item in dt.Rows)
            {
                stocks.Add(cargarObj(item.ItemArray));
            }

            return stocks;
        }

    }

}


