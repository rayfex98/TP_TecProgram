using System.Data;
using Entidades;
using ExcepcionesControladas;

namespace ddl_modulo
{
    public class DPersona
    {
        public bool Nuevo(Persona unPersona)
        {
            try
            {
                Conexion db = new Conexion();
                if (!ID_Persona(false, -1, unPersona.DNI))
                {
                    string query = string.Format("EXEC PERSONAPROC @ID=NULL,@DIRECCION={0},@DNI={1},@NOMBRE={2},@APELLIDO={3},@TIPO = 'INSERT';"
                            , unPersona.Direccion, unPersona.DNI, unPersona.Nombre, unPersona.Apellido);
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
        public bool Editar(Persona unPersona)
        {
            try
            {
                Conexion db = new Conexion();
                if (!ID_Persona(true, unPersona.ID, -1))
                {
                    if (!ID_Persona(false, -1, unPersona.DNI))
                    {
                        string query = string.Format("EXEC PERSONAPROC @ID={0},@DIRECCION={1},@DNI={2},@NOMBRE={3},@APELLIDO={4},@TIPO = 'UPDATE';"
                            , unPersona.ID, unPersona.Direccion, unPersona.DNI, unPersona.Nombre, unPersona.Apellido);
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
        public bool Eliminar(Persona unPersona)
        {
            try
            {
                Conexion db = new Conexion();
                if (ID_Persona(true, unPersona.ID, -1))
                {
                    string query = string.Format("EXEC PERSONAPROC @ID={0},@DIRECCION=NULL,@DNI=NULL,@NOMBRE=NULL,@APELLIDO=NULL,@TIPO = 'DELETE';", unPersona.ID);
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
        public bool ID_Persona(bool metodo, int id, int dni)
        {
            try
            {
                Conexion db = new Conexion();
                string query;
                if (metodo == true)
                {
                    query = string.Format("EXEC PERSONAPROC @ID={0},@DIRECCION=NULL,@DNI=NULL,@NOMBRE=NULL,@APELLIDO=NULL,@TIPO = 'SELECTONE';", id);
                    if (1 != db.EscribirPorComando(query))
                    {
                        return false;
                    }
                }
                else
                {
                    query = string.Format("EXEC PERSONAPROC @ID=NULL,@DIRECCION=NULL,@DNI={0},@NOMBRE=NULL,@APELLIDO=NULL,@TIPO = 'SELECTID';", dni);
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
        public DataTable ListadePersona()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}
