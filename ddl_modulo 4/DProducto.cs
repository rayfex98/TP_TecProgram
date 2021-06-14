using System.Data;
using Entidades;
using ExcepcionesControladas;

namespace ddl_modulo
{
    public class DProducto
    {
        public bool NuevoProducto(Producto unProducto)
        {
            try
            {
                Conexion db = new Conexion();
                if (!ID_Producto(false,-1,unProducto.Nombre))
                {
                    string query = string.Format("EXEC PRODUCTOPROC @ID=NULL,@CATEGORIA={0},@NOMBRE={1},@COMPRA = {2} ,@VENTA = {3},@TIPO='INSERT';"
                        ,unProducto.Categoria.ID, unProducto.Nombre, unProducto.PrecioCompra, unProducto.PrecioVenta);
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
        }
        public bool EditarProducto(Producto unProducto)
        {
            try
            {
                Conexion db = new Conexion();
                if (!ID_Producto(true, unProducto.ID,"NULL")) //id debe existir
                {
                    string query = string.Format("EXEC PRODUCTOPROC @ID={0},@CATEGORIA={1},@NOMBRE={2},@COMPRA = {3} ,@VENTA = {4},@TIPO='UPDATE';"
                        ,unProducto.ID, unProducto.Categoria.ID, unProducto.Nombre, unProducto.PrecioCompra, unProducto.PrecioVenta);
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
        public bool EliminarProducto(Producto unProducto)
        {
            try
            {
                Conexion db = new Conexion();
                if (unProducto.ID.ToString() != null)
                {
                    if (ID_Producto(true, unProducto.ID,"NULL"))
                    {

                        string query = string.Format("EXEC PRODUCTOPROC @ID = {0},@CATEGORIA=NULL,@NOMBRE=NULL,@COMPRA = NULL,@VENTA = NULL,@TIPO = 'DELETE';",unProducto.ID); ///
                        if (1 != db.EscribirPorComando(query))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if (ID_Producto(false,-1, unProducto.Nombre))
                    {
                        string query = string.Format("EXEC PRODUCTOPROC @ID = NULL,@CATEGORIA={1},@NOMBRE={0},@COMPRA = NULL,@VENTA = NULL,@TIPO = 'DELETE';",unProducto.Nombre, unProducto.Categoria.ID);
                        if (1 != db.EscribirPorComando(query))
                        {
                            return false;
                        }
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
        public bool ID_Producto(bool metodo, int id, string nombre)
        {
            try
            {
                Conexion db = new Conexion();
                string query;
                if (metodo == true)
                {
                    query = string.Format("EXEC PRODUCTOPROC @ID = {0},@CATEGORIA=NULL,@NOMBRE=NULL,@COMPRA = NULL,@VENTA = NULL,@TIPO = 'SELECTONE';", id, null);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                }
                else
                {
                    query = string.Format("EXEC PRODUCTOPROC @ID = NULL,@CATEGORIA={0},@NOMBRE={1},@COMPRA = NULL ,@VENTA = NULL,@TIPO = 'SELECTID';", id, nombre);
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

        public DataTable ListadeProductos()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}
