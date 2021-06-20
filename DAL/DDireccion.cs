using Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DAL
{
    public class DDireccion
    {
        DataTable dt = new DataTable();
        Conexion db = new Conexion();
        public bool Nuevo(Direccion unDireccion)
        {

                string query = string.Format("EXEC DIRECCIONPROC @ID=NULL,@ALTURA={0},@CALLE={1},@CP={2},@LOCALIDAD={3},@PROVINCIA={4},@TIPO = 'INSERT';"
                    , unDireccion.Altura, unDireccion.Calle, unDireccion.CodigoPostal, unDireccion.Localidad, unDireccion.Provincia);
                if (1 != db.EscribirPorComando(query))
                {
                    return false;
                }
            return true;
            
        }
        public bool Editar(Direccion unDireccion)
        {
            try
            {
                string query = string.Format("EXEC DIRECCIONPROC @ID={0},@ALTURA={1},@CALLE={2},@CP={3},@LOCALIDAD={4},@PROVINCIA={5},@TIPO = 'UPDATE';"
                , unDireccion.ID, unDireccion.Altura.ToString(), unDireccion.Calle.ToString(), unDireccion.CodigoPostal.ToString(), unDireccion.Localidad.ToString(), unDireccion.Provincia.ToString());
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
        public bool Eliminar(Direccion unDireccion)
        {
            try
            {
                string query = string.Format("EXEC DIRECCIONPROC @ID={0},@ALTURA=NULL,@CALLE=NULL,@CP=NULL,@LOCALIDAD=NULL,@PROVINCIA=NULL,@TIPO = 'DELETE';", unDireccion.ID);
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
        public DataTable listadirecion()
        {
            string query = string.Format("listadirecion");
            dt = db.LeerPorComando(query);
            //busco en tabla
            return dt;
        }

    }
}
