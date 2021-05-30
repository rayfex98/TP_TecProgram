using System.Data;
using Entidades;

namespace ddl_modulo
{
    public class DDireccion
    { 
        Conexion db = new Conexion();
        public bool Nuevo(Direccion unDireccion)
        {
           
            string query = string.Format("DIRECCIONPROC  @ID=null,@ALTURA={0},@CALLE={1},@CP={2},@LOCALIDAD={3},@PROVINCIA={4},@TIPO='INSERT';", unDireccion.Altura,unDireccion.Calle,unDireccion.CodigoPostal,unDireccion.Localidad,unDireccion.Provincia);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;
        }
        public bool Editar(Direccion unDireccion, short id)
        {
            string query = string.Format("DIRECCIONPROC  @ID={0},@ALTURA={1},@CALLE={2},@CP={3},@LOCALIDAD={4},@PROVINCIA={5},@TIPO='UPDATE';",id, unDireccion.Altura, unDireccion.Calle, unDireccion.CodigoPostal, unDireccion.Localidad, unDireccion.Provincia);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;
        }
        public bool Eliminar(short idDireccion)
        {
            string query = string.Format("DIRECCIONPROC  @ID={0},@ALTURA=null,@CALLE=null,@CP=null,@LOCALIDAD=null,@PROVINCIA=null,@TIPO='DELETE';",idDireccion);
            if (1 != db.EscribirPorComando(query))
            {
                return false;
            }
            return true;
        }
        public int ID_Direccion()
        {
            return 0;
        }
        public DataTable ListadeDireccion()
        {
            return db.LeerPorStoreProcedure("VISTADIR");
        }
    }
}
