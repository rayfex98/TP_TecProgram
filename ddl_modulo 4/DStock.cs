using Entidades;
using System.Data;
using ExcepcionesControladas;

namespace ddl_modulo
{
    public class DStock
    {
        public bool Nuevo(Stock unStock)
        {
            try
            {
                Conexion db = new Conexion();
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
                Conexion db = new Conexion();
                if (!ID_Stock(unStock.ID))
                {
                    string query = string.Format("EXEC STOCKPROC @ID={0},@PRODUCTO={1},@CANTIDAD={3},@TIPO = 'UPDATE';", unStock.ID, unStock.Producto.ID, unStock.Cantidad);
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
                Conexion db = new Conexion();
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
                Conexion db = new Conexion();
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
    }
}
