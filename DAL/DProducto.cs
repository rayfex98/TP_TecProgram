using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
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
                string query = string.Format(" EXEC PRODUCTOPROC @ID = NULL, @CATEGORIA = {0}, @NOMBRE = {1}, @COMPRA = {2}, @VENTA = {3}, @HABILITADO = NULL, @TIPO = 'INSERT' ; "
                    , unProducto.Categoria.ID, unProducto.Nombre, unProducto.PrecioCompra, unProducto.PrecioVenta);
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
            string query = string.Format("ListaProductosHabilitados");
            dt = db.LeerPorComando(query);
            return dt;
        }
    }
}
