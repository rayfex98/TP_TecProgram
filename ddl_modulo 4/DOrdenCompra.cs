﻿using System;
using System.Data;
using Entidades;
using ExcepcionesControladas;

namespace ddl_modulo
{
    public class DOrdenCompra
    {
        Conexion db = new Conexion();
        public bool NuevoOrden(OrdenDeCompra unOrdenCompra)
        {
            try
            {
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