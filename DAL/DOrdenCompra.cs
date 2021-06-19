using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
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
                unOrdenCompra.FechaAprobacion = DateTime.Now;
                string query = string.Format("EXEC ORDENCOMPRAPROC @ID=NULL,@PROVEEDOR={0},@USUARIO={1},@FECHA={2} cast(@FECHA as datetime),@TIPO = 'INSERT';"
                , unOrdenCompra.Proveedor.ID, unOrdenCompra.UsuarioAprobador.ID, unOrdenCompra.FechaAprobacion);
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
    }
}
