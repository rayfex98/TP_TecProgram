using Entidades;
using System.Data;

namespace DAL
{
    public class DDireccion
    {
        DataTable dt = new DataTable();
        readonly Conexion db = new Conexion();
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
        public bool Eliminar(int unDireccion)
        {
            try
            {
                string query = string.Format("EXEC DIRECCIONPROC @ID={0},@ALTURA=NULL,@CALLE=NULL,@CP=NULL,@LOCALIDAD=NULL,@PROVINCIA=NULL,@TIPO = 'DELETE';", unDireccion);
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
        public DataTable ListaDirecion()
        {
            string query = string.Format("listadirecion");
            dt = db.LeerPorComando(query);
            return dt;
        }
        public int UltimaDireccion()
        {
            try
            {
                string query = string.Format("SELECT MAX([ID]) FROM [dbo].[direccion]");
                dt = db.LeerPorComando(query);
                return int.Parse(dt.Rows[0].ItemArray[0].ToString());

            }
            catch (System.Data.SqlClient.SqlException)
            {
                return -1;
            }
            catch (System.NullReferenceException)
            {
                return -1;
            }
        }
    }
}
