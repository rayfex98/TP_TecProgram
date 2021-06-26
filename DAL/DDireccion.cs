using Entidades;
using System.Data;
using System.Data.SqlClient;

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
                SqlParameter[] parametros =
                {
                    new SqlParameter("@ALTURA",SqlDbType.NVarChar),
                    new SqlParameter("@CALLE",SqlDbType.NVarChar),
                    new SqlParameter("@CP",SqlDbType.NVarChar),
                    new SqlParameter("@LOCALIDAD",SqlDbType.NVarChar),
                    new SqlParameter("@PROVINCIA",SqlDbType.NVarChar),
                    new SqlParameter("@TIPO",SqlDbType.NVarChar)
                };
                parametros[0].Value = unDireccion.Altura.ToString();
                parametros[1].Value = unDireccion.Calle.ToString();
                parametros[2].Value = unDireccion.CodigoPostal.ToString();
                parametros[3].Value = unDireccion.Localidad.ToString();
                parametros[3].Value = unDireccion.Provincia.ToString();
                parametros[4].Value = "INSERT";
                if (db.EscribirPorStoreProcedure("DIRECCIONPROC", parametros) > 0)
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
            string query = string.Format("listadireccion");
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
