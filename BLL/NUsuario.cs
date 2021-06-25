using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAL;
using Entidades;

namespace BLL
{
    public class NUsuario
    {
        DUsuario unUsuario = new DUsuario();

        public bool Nuevo(Usuario _unUsuario)
        {
            return unUsuario.Nuevo(_unUsuario);
        }

        public DataTable ListarUsuario()
        {
            return unUsuario.ListadeUsuario();
        }
    }
}
