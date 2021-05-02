﻿using System.Data;
using Datos;
using CapaEntidad;

namespace Negocio
{
    public class NUsuario
    {
        DUsuario unUsuario = new DUsuario();

        public string Nuevo(Usuario _unUsuario)
        {
            return unUsuario.Nuevo(_unUsuario);
        }
        public string Editar(Usuario _unUsuario)
        {
            return unUsuario.Editar(_unUsuario);
        }
        public Usuario Eliminar(int _DNI)
        {
            return unUsuario.Eliminar(_DNI);
        }
        public int ID_Usuario()
        {
            return unUsuario.ID_Usuario();
        }
        public DataTable ListarUsuario()
        {
            return unUsuario.ListadeUsuario();
        }
    }
}
