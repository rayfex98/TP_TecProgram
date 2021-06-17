using System.Data;
using Entidades;
using ExcepcionesControladas;

namespace ddl_modulo
{
    public class DDireccion
    {
        Conexion db = new Conexion();
        public bool Nuevo(Direccion unDireccion)
        {
            try
            {

                string query = string.Format("EXEC DIRECCIONPROC @ID=NULL,@ALTURA={0},@CALLE={1},@CP={2},@LOCALIDAD={3},@PROVINCIA={4},@TIPO = 'INSERT';"
                    , unDireccion.Altura.ToString(), unDireccion.Calle, unDireccion.CodigoPostal.ToString(), unDireccion.Localidad, unDireccion.Provincia);
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
    }
}
