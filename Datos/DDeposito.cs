using System.Data;
using Entidades;

namespace Datos
{
    public class DDeposito
    {
        public string Nuevo(Deposito unDeposito)
        {
            //conexion con bbdd
            return "Ok";
        }
        public string Editar(Deposito unDeposito)
        {
            //conexion con bbdd
            return "Ok";
        }
        public Deposito Eliminar(int idDeposito)
        {
            Deposito eliminado = new Deposito();
            //conexion con bbdd
            return eliminado;
        }
        public int ID_Deposito()
        {
            return 0;
        }
        public DataTable ListadeDeposito()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}