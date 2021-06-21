using System;
using Entidades;

namespace DAL
{
    public class DPersona
    {
        public bool Nuevo(Persona unPersona) //para carga de usuarios
        {
            try
            {
                Conexion db = new Conexion();
                string query = string.Format("EXEC PERSONAPROC @ID=NULL,@DIRECCION={0},@DNI={1},@NOMBRE={2},@APELLIDO={3},@TIPO = 'INSERT';"
                            , unPersona.Direccion, unPersona.DNI, unPersona.Nombre, unPersona.Apellido);
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
    }
}
