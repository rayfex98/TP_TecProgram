using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DProducto
    {
        readonly Conexion db = new Conexion();
        DataTable dt = new DataTable();
        public bool NuevoProducto(Producto unProducto)
        {
            try
            {
                SqlParameter[] parametros =
                {
                    new SqlParameter("@CATEGORIA",SqlDbType.Int),
                    new SqlParameter("@NOMBRE",SqlDbType.VarChar),
                    new SqlParameter("@COMPRA",SqlDbType.Float),
                    new SqlParameter("@VENTA",SqlDbType.Float),
                    new SqlParameter("@TIPO",SqlDbType.NVarChar)
                };
                parametros[0].Value = unProducto.Categoria.ID;
                parametros[1].Value = unProducto.Nombre;
                parametros[2].Value = unProducto.PrecioCompra;
                parametros[3].Value = unProducto.PrecioVenta;
                parametros[4].Value = "INSERT";
                if (db.EscribirPorStoreProcedure("PRODUCTOPROC", parametros) > 0)
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
        public bool EditarProducto(Producto unProducto)
        {
            int idcategoria = unProducto.Categoria.ID;
            string query = string.Format("PRODUCTOPROC @ID = {0} ,@CATEGORIA = {1} ,@NOMBRE = {2} ,@COMPRA = {3} ,@VENTA = {4} ,@HABILITADO = NULL ,@TIPO = 'UPDATE' "
                        , unProducto.ID, idcategoria, unProducto.Nombre, unProducto.PrecioCompra, unProducto.PrecioVenta);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;

        }
        public bool EliminarProducto(int unProducto)
        {
            try
            {
                string query = string.Format("EXEC PRODUCTOPROC @ID = {0},@CATEGORIA=NULL,@NOMBRE=NULL,@COMPRA = NULL,@VENTA = NULL,@HABILITADO = NULL,@TIPO = 'DELETE';", unProducto); ///
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

        public DataTable ListadeProductos()
        {
            string query = string.Format("EXEC ListaProductos");
            dt = db.LeerPorComando(query);
            return dt;
        }

        public DataTable ListaPorCategoria(string nombre)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@categoria",SqlDbType.VarChar)
            };
            parametros[0].Value = nombre;
            dt = db.LeerPorStoreProcedure("BuscarProductoCategoria", parametros);
            return dt;
        }
        public DataTable ListaPorNombre(string nombre)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre",SqlDbType.VarChar)
            };
            parametros[0].Value = nombre;
            dt = db.LeerPorStoreProcedure("BuscarProductoNombre", parametros);
            return dt;
        }
    }
}
