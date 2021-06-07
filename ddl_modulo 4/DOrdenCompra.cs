using System;
using System.Data;
using Entidades;
using ExcepcionesControladas;

namespace ddl_modulo
{
    public class DOrdenCompra
    {
        public bool Nuevo(OrdenDeCompra unOrdenCompra)
        {
            try
            {
                Conexion db = new Conexion();
                unOrdenCompra.FechaAprobacion = DateTime.Now;
                string query = string.Format("EXEC ORDENCOMPRAPROC @ID=NULL,@PROVEEDOR={0},@USUARIO={1},@FECHA={2},@TIPO = 'INSERT';"
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
        public bool Editar(OrdenDeCompra unOrdenCompra)
        {
            try
            {
                Conexion db = new Conexion();
                if (!ID_OrdenCompra(true, unOrdenCompra.ID, -1))
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
        public bool Eliminar(int idOrden)
        {
            try
            {
                Conexion db = new Conexion();
                if (ID_OrdenCompra(true, idOrden, -1))
                {
                    string query = string.Format("EXEC ORDENCOMPRAPROC @ID={0},@PROVEEDOR=NULL,@USUARIO=NULL,@FECHA=NULL,@TIPO = 'DELETE';", idOrden);
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
        public bool ID_OrdenCompra(bool metodo, int id, int proveedor ) //casi siempre se da solo por ID o muestro todo, seria raro que acierte con SMALLDATE
        {
            try
            {
                Conexion db = new Conexion();
                string query;
                if (metodo == true)
                {
                    query = string.Format("EXEC ORDENCOMPRAPROC @ID={0},@PROVEEDOR=NULL,@USUARIO=NULL,@FECHA=NULL,@TIPO = 'SELECTONE';", id);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                }
                else
                {
                    query = string.Format("EXEC ORDENCOMPRAPROC @ID=NULL,@PROVEEDOR={1},@USUARIO={0},@FECHA=NULL,@TIPO = 'SELECTID';", id, proveedor);
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
        public DataTable ListadeOrdenCompra()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
        public bool EstaAprobada(Usuario UsuarioAprovador)
        {
            return true;
        }
        public DataTable OrdenPendiente()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}