using System.Data;
using Entidades;
using ExcepcionesControladas;

namespace ddl_modulo
{
    public class DDireccion
    {
        public bool Nuevo(Direccion unDireccion)
        {
            try
            {
                Conexion db = new Conexion();
                if (ID_Direccion(false,-1, unDireccion.Altura, unDireccion.Calle,int.Parse(unDireccion.CodigoPostal)))
                {
                    string query = string.Format("EXEC DIRECCIONPROC @ID=NULL,@ALTURA={0},@CALLE={1},@CP={2},@LOCALIDAD={3},@PROVINCIA={4},@TIPO = 'INSERT';"
                        , unDireccion.Altura, unDireccion.Calle, int.Parse(unDireccion.CodigoPostal), unDireccion.Localidad, unDireccion.Provincia);
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
        public bool Editar(Direccion unDireccion)
        {
            try
            {
                Conexion db = new Conexion();
                if (ID_Direccion(true, unDireccion.ID,"NULL","NULL",-1))
                {
                    if(!ID_Direccion(false,-1, unDireccion.Altura, unDireccion.Calle, int.Parse(unDireccion.CodigoPostal)))
                    {
                        string query = string.Format("EXEC DIRECCIONPROC @ID=NULL,@ALTURA={0},@CALLE={1},@CP={2},@LOCALIDAD={3},@PROVINCIA={4},@TIPO = 'UPDATE';"
                        , unDireccion.Altura, unDireccion.Calle, int.Parse(unDireccion.CodigoPostal), unDireccion.Localidad, unDireccion.Provincia);
                        if (1 != db.EscribirPorComando(query))
                        {
                            return false;
                        }
                        return true;
                    }
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
        public bool Eliminar(Direccion unDireccion)
        {
            try
            {
                Conexion db = new Conexion();
                if (ID_Direccion(true, unDireccion.ID, "NULL", "NULL", -1))
                {
                    string query = string.Format("EXEC DIRECCIONPROC @ID={0},@ALTURA=NULL,@CALLE=NULL,@CP=NULL,@LOCALIDAD=NULL,@PROVINCIA=NULL,@TIPO = 'DELETE';", unDireccion.ID);
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
        public bool ID_Direccion(bool metodo, int id, string altura, string calle, int codigopostal)
        {
            try
            {
                Conexion db = new Conexion();
                string query;
                if (metodo == true)
                {
                    query = string.Format("EXEC DIRECCIONPROC @ID={0},@ALTURA=NULL,@CALLE=NULL,@CP=NULL,@LOCALIDAD=NULL,@PROVINCIA=NULL,@TIPO='SELECTONE';", id);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                }
                else
                {
                    query = string.Format("EXEC DIRECCIONPROC @ID=NULL,@ALTURA={0},@CALLE={1},@CP={2},@LOCALIDAD=NULL,@PROVINCIA=NULL,@TIPO='SELECTID';", altura, calle, codigopostal);
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
        public DataTable ListadeDireccion()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}
